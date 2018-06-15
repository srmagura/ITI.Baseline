﻿using System;
using Iti.Exceptions;

namespace Iti.Authentication
{
    public class LoginFailedException : DomainException
    {
        public LoginFailedException(string message) : base(message)
        {
        }

        public LoginFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}