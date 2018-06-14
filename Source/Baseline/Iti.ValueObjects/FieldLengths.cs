﻿namespace Iti.ValueObjects
{
    public static class FieldLengths
    {
        public static class EmailAddress
        {
            public const int Value = 256;
        }

        public class PersonName
        {
            public const int Prefix = 64;
            public const int First = 64;
            public const int Last = 64;
            public const int Middle = 64;
        }

        public class Address
        {
            public const int Line1 = 64;
            public const int Line2 = 64;
            public const int City = 64;
            public const int State = 16;
            public const int Zip = 16;
        }

        public class PhoneNumber
        {
            public const int Value = 16;
        }

        public class TimeZone
        {
            public const int Value = 64;
        }
    }
}
