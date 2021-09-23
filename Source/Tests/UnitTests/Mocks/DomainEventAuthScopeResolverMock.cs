﻿using Autofac;
using ITI.DDD.Domain.DomainEvents;

namespace UnitTests.Mocks
{
    internal class DomainEventAuthScopeResolverMock : IDomainEventAuthScopeResolver
    {
        private readonly ILifetimeScope _scope;

        public DomainEventAuthScopeResolverMock(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ILifetimeScope BeginLifetimeScope()
        {
            return _scope.BeginLifetimeScope();
        }
    }

}
