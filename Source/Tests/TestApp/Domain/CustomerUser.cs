﻿using ITI.Baseline.Util.Validation;
using ITI.Baseline.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain.Enums;
using TestApp.Domain.Identities;

namespace TestApp.Domain
{
    public class CustomerUser : User
    {
        [Obsolete("Persistence use only")]
        protected CustomerUser() { }

        public CustomerUser(CustomerId customerId, EmailAddress email)
            : base(UserType.Customer, email)
        {
            CustomerId = customerId;
        }

        public CustomerId? CustomerId { get; set; }
    }
}