﻿using System;
using Iti.Exceptions;

namespace Iti.Auth
{
    public class NotAuthenticatedException : DomainException
    {
        public NotAuthenticatedException() 
            : base("User not authenticated", false)
        {
        }

        public NotAuthenticatedException(Exception innerException) 
            : base("User not authenticated", innerException, false)
        {
        }
    }
}