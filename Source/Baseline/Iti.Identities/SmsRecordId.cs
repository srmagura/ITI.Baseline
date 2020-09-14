﻿using System;
using Iti.Baseline.Core.Entities;

namespace Iti.Baseline.Identities
{
    public class SmsRecordId : Identity
    {
        public SmsRecordId() { }
        public SmsRecordId(Guid guid) : base(guid) { }
        public SmsRecordId(Guid? guid) : base(guid ?? default(Guid)) { }
    }
}