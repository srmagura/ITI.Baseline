﻿using ITI.DDD.Domain.Entities;
using ITI.DDD.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.DDD.Infrastructure.DataMapping
{
    public interface IDbEntityMapper
    {
        TDb ToDb<TDb>(Entity entity) where TDb : DbEntity;
        TEntity ToEntity<TEntity>(DbEntity dbEntity) where TEntity : Entity;
    }
}
