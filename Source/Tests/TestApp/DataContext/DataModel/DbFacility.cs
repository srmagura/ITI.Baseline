﻿using ITI.Baseline.Audit;
using ITI.DDD.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestApp.Domain.ValueObjects;

namespace TestApp.DataContext.DataModel
{
    public class DbFacility : DbEntity, IDbAudited
    {
        public DbFacility() { }

        [MaxLength(64)]
        public string? Name { get; set; }

        public FacilityContact? Contact { get; set; }

        public string AuditEntityName => "Facility";
        public string AuditEntityId => Id.ToString();
    }
}
