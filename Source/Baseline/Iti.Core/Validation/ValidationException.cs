﻿using System;
using Iti.Exceptions;

namespace Iti.Core.Validation
{
    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message, false)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException, false)
        {
        }
    }
}