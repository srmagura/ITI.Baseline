﻿using System;
using System.Data;
using Iti.Core.UnitOfWorkBase;
using Iti.Core.UnitOfWorkBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iti.Core.Sequences
{
    public class EfSequenceResolver<TDbContext> : ISequenceResolver
        where TDbContext : DbContext
    {
        private readonly IUnitOfWork _uow;

        public EfSequenceResolver(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public long GetNextValue(string name)
        {
            var db = _uow.Current<TDbContext>();

            var sql = $"SELECT NEXT VALUE FOR [{Sequence.SequenceSchema}].[{name}]";

            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                db.Database.OpenConnection();

                using (var result = cmd.ExecuteReader())
                {
                    result.Read();
                    var value = (long)result[0];

                    return value;
                }
            }
        }
    }
}