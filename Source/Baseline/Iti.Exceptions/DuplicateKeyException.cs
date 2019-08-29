﻿using System;

namespace Iti.Exceptions
{
    public class DuplicateKeyException : DomainException
    {
        public DuplicateKeyException(string table, string value)
            : base($"Duplicate Key: {table} value '{value}'", false)
        {
            Table = table;
            Value = value;
        }

        public DuplicateKeyException(string table, string value, Exception innerException)
            : base($"Duplicate Key: {table} value '{value}'", innerException, false)
        {
            Table = table;
            Value = value;
        }

        public string Table { get; protected set; }
        public string Value { get; protected set; }
    }
}