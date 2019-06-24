﻿using Iti.Core.Entites;
using Iti.ValueObjects;

namespace Domain
{
    public class ValObjHolder : AggregateRoot
    {
        public ValObjHolderId Id { get; protected set; } = new ValObjHolderId();

        public string Name { get; set; }

        public Address Address { get; set; }
        public PersonName PersonName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public ValueParent ValueParent { get; set; }
    }
}