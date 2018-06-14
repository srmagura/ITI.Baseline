﻿using Iti.Inversion;
using Microsoft.EntityFrameworkCore;

namespace Iti.Core.Sequences
{
    public static class Sequence
    {
        public const string SequenceSchema = "sequences";

        public static long Next(string name = "Default")
        {
            var res = IOC.Resolve<ISequenceResolver>();
            return res.GetNextValue(name);
        }

        public static void Initialize(ModelBuilder modelBuilder)
        {
            Define(modelBuilder, "Default");
        }

        public static void Define(ModelBuilder modelBuilder, string sequenceName, long initialValue = 1, int incrementBy = 1)
        {
            modelBuilder.HasSequence<long>(sequenceName, SequenceSchema)
                .StartsAt(initialValue)
                .IncrementsBy(incrementBy);
        }
    }
}
