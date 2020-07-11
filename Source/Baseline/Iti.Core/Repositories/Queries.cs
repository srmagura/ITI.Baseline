﻿using Iti.Core.UnitOfWorkBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iti.Core.Repositories
{
    public abstract class Queries<TDbContext>
        where TDbContext : DbContext, new()
    {
        private readonly IUnitOfWork _uow;

        protected Queries(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected TDbContext Context => _uow.Current<TDbContext>();
    }
}