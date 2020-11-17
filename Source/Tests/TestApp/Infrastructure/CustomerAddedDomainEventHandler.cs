﻿using ITI.DDD.Auth;
using ITI.DDD.Domain.DomainEvents;
using ITI.DDD.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain.Events;

namespace TestApp.Infrastructure
{
    public class CustomerAddedDomainEventHandler : IDomainEventHandler<CustomerAddedEvent>
    {
        private readonly ILogger _logger;
        private readonly IAuthContext _authContext;

        public CustomerAddedDomainEventHandler(ILogger logger, IAuthContext authContext)
        {
            _logger = logger;
            _authContext = authContext;
        }

        public void Handle(CustomerAddedEvent domainEvent)
        {
            _logger.Info($"Customer added: {domainEvent.Name} (by {_authContext.UserName})");
        }
    }
}