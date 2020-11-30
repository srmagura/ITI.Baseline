﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Application.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public AddressDto? Address { get; set; }
        public PersonNameDto? ContactName { get; set; }
        public PhoneNumberDto? ContactPhone { get; set; }

        public List<LtcPharmacyDto> LtcPharmacies { get; set; } = new List<LtcPharmacyDto>();
        public List<int> SomeInts { get; set; } = new List<int>();

        public decimal SomeMoney { get; set; }
        public long SomeNumber { get; set; }
    }
}
