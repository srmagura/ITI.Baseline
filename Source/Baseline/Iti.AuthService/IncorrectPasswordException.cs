﻿using System;
using Iti.Exceptions;

namespace Iti.AuthService
{
    public class IncorrectPasswordException : DomainException
    {
        public IncorrectPasswordException() : base("Incorrect password", false)
        {
        }

        public IncorrectPasswordException(Exception innerException) : base("Incorrect password", innerException, false)
        {
        }
    }
}