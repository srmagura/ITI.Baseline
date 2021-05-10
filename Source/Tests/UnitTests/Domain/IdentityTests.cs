﻿using System;
using System.Collections.Generic;
using ITI.DDD.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Domain
{
    [TestClass]
    public class IdentityTests
    {
        [TestMethod]
        public void NullIdentityComparisons()
        {
            var id1 = new TestId();
            var id2 = new TestId();
            var id1_copy = new TestId(id1.Guid);
            TestId id_null1 = null;
            TestId id_null2 = null;

            Assert.IsTrue(id1 == id1);
            Assert.IsFalse(id1 == id2);
            Assert.IsTrue(id1 == id1_copy);

            Assert.IsFalse(id1 == null);
            Assert.IsFalse(null == id1);

            Assert.IsFalse(id1 == id_null1);
            Assert.IsFalse(id_null1 == id1);

            Assert.IsTrue(id_null1 == id_null2);
        }

        [TestMethod]
        public void HashSet()
        {
            var id1 = new TestId();
            var id2 = new TestId();
            var id1_copy = new TestId(id1.Guid);

            var set = new HashSet<TestId> { id1 };

            Assert.IsTrue(set.Contains(id1));
            Assert.IsTrue(set.Contains(id1_copy));

            set.Add(id1);
            set.Add(id1_copy);
            Assert.AreEqual(1, set.Count);

            set.Add(id2);
            Assert.AreEqual(2, set.Count);
        }
    }

    internal class TestId : Identity
    {
        public TestId() { }
        public TestId(Guid guid) : base(guid) { }
        public TestId(Guid? guid) : base(guid ?? default) { }
    }
}