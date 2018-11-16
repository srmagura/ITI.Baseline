﻿using System;
using Iti.Exceptions;

namespace Iti.Auth
{
    public class NotAuthorizedException : DomainException
    {
        public NotAuthorizedException() 
            : base("Permission Denied", false)
        {
        }

        public NotAuthorizedException(Exception innerException) 
            : base("Permission Denied", innerException, false)
        {
        }
    }
}