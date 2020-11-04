﻿using Autofac;
using ITI.DDD.Auth;
using ITI.DDD.Core;
using ITI.DDD.Domain.DomainEvents;
using ITI.DDD.Domain.Entities;
using ITI.DDD.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.Mocks;

namespace UnitTests.Domain
{
    [TestClass]
    public class DomainEventsTests
    {
        public class CustomerAddedEvent : BaseDomainEvent
        {
            public Guid CustomerId { get; set; }

            public CustomerAddedEvent(Guid customerId)
            {
                CustomerId = customerId;
            }
        }

        public class VendorAddedEvent : BaseDomainEvent
        {
            public Guid VendorId { get; set; }

            public VendorAddedEvent(Guid vendorId)
            {
                VendorId = vendorId;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            DomainEvents.ClearRegistrations();
        }

        private IOC GetIOC(out ILogger logger)
        {
            var ioc = new IOC();
            logger = Substitute.For<ILogger>();
            ioc.RegisterInstance(logger);
            var authContext = Substitute.For<IAuthContext>();
            ioc.RegisterInstance(authContext);
            var authScopeResolver = new DomainEventAuthScopeResolverMock(ioc);
            ioc.RegisterInstance<IDomainEventAuthScopeResolver>(authScopeResolver);

            return ioc;
        }

        [TestMethod]
        public async Task ProcessSuccess()
        {
            var ioc = GetIOC(out var logger);

            DomainEvents.Register<CustomerAddedEvent, IDomainEventHandler<CustomerAddedEvent>>();
            var eventHandler = Substitute.For<IDomainEventHandler<CustomerAddedEvent>>();
            ioc.RegisterInstance(eventHandler);

            var domainEvents = ioc.ResolveForTest<DomainEvents>();
            var ev = new CustomerAddedEvent(Guid.NewGuid());
            domainEvents.Raise(ev);
            await domainEvents.HandleAllRaisedEventsAsync();

            eventHandler.Received(1).Handle(Arg.Any<CustomerAddedEvent>());
            eventHandler.Received().Handle(ev);

            logger.DidNotReceive().Error(Arg.Any<string>());
        }

        [TestMethod]
        public async Task ProcessFailure()
        {
            var ioc = GetIOC(out var logger);

            DomainEvents.Register<CustomerAddedEvent, IDomainEventHandler<CustomerAddedEvent>>();
            var eventHandler = Substitute.For<IDomainEventHandler<CustomerAddedEvent>>();
            eventHandler
                .When(x => x.Handle(Arg.Any<CustomerAddedEvent>()))
                .Do(x => { throw new Exception("myException"); });
            ioc.RegisterInstance(eventHandler);

            var domainEvents = ioc.ResolveForTest<DomainEvents>();
            var ev = new CustomerAddedEvent(Guid.NewGuid());
            domainEvents.Raise(ev);
            await domainEvents.HandleAllRaisedEventsAsync();

            eventHandler.Received(1).Handle(Arg.Any<CustomerAddedEvent>());
            eventHandler.Received().Handle(ev);

            logger.Received().Error(
                Arg.Any<string>(), 
                Arg.Is<Exception>(e => e.InnerException != null && e.InnerException.Message == "myException")
            );
        }

        [TestMethod]
        public async Task NoHandlerRegistered()
        {
            var ioc = GetIOC(out var logger);

            var domainEvents = ioc.ResolveForTest<DomainEvents>();
            var ev = new CustomerAddedEvent(Guid.NewGuid());
            domainEvents.Raise(ev);
            await domainEvents.HandleAllRaisedEventsAsync();

            logger.DidNotReceive().Error(Arg.Any<string>());
        }

        [TestMethod]
        public async Task FirstHandlerFailsSecondHandlerSucceeds()
        {
            var ioc = GetIOC(out var logger);

            // CustomerAddedEvent handler (fails)
            DomainEvents.Register<CustomerAddedEvent, IDomainEventHandler<CustomerAddedEvent>>();
            var customerEventHandler = Substitute.For<IDomainEventHandler<CustomerAddedEvent>>();
            customerEventHandler
                .When(x => x.Handle(Arg.Any<CustomerAddedEvent>()))
                .Do(x => { throw new Exception("myException"); });
            ioc.RegisterInstance(customerEventHandler);

            // VendorAddedEvent handler (succeeds)
            DomainEvents.Register<VendorAddedEvent, IDomainEventHandler<VendorAddedEvent>>();
            var vendorEventHandler = Substitute.For<IDomainEventHandler<VendorAddedEvent>>();
            ioc.RegisterInstance(vendorEventHandler);

            // Raise events
            var domainEvents = ioc.ResolveForTest<DomainEvents>();
            var customerEvent = new CustomerAddedEvent(Guid.NewGuid());
            var vendorEvent = new VendorAddedEvent(Guid.NewGuid());
            domainEvents.Raise(customerEvent);
            domainEvents.Raise(vendorEvent);
            await domainEvents.HandleAllRaisedEventsAsync();

            customerEventHandler.Received(1).Handle(customerEvent);
            vendorEventHandler.Received(1).Handle(vendorEvent);

            logger.Received().Error(
                Arg.Any<string>(),
                Arg.Is<Exception>(e => e.InnerException != null && e.InnerException.Message == "myException")
            );
        }
    }
}