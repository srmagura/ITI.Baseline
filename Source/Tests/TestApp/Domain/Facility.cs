﻿using ITI.DDD.Domain.Entities;
using System;
using TestApp.Domain.Identities;
using TestApp.Domain.ValueObjects;

namespace TestApp.Domain
{
    // Test of nested value objects
    public class Facility : AggregateRoot
    {
        [Obsolete]
        protected Facility() { }

        public Facility(string name, FacilityContact? contact)
        {
            Name = name;
            SetContact(contact);
        }

        public FacilityId Id { get; set; } = new FacilityId();
        public string? Name { get; set; }
        public FacilityContact? Contact { get; set; }

        public void SetContact(FacilityContact? contact)
        {
            Contact = contact;
        }
    }
}
