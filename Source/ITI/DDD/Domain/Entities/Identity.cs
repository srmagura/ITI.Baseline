﻿using System;

namespace ITI.DDD.Domain.Entities
{
    public abstract class Identity : IEquatable<Identity>
    {
        protected Identity()
        {
            Guid = SequentialGuid.Next();
        }

        protected Identity(Guid guid)
        {
            Guid = guid;
        }

        public Guid Guid { get; protected set; }

        public override string ToString()
        {
            return $"{GetType().Name}:{Guid}";
        }

        public bool Equals(Identity? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Guid.Equals(other.Guid);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}