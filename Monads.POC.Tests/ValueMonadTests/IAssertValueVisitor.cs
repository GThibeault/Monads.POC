﻿using Monads.POC.Common.Monads.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.ValueMonadTests
{
    public class AssertValueVisitor<TValue> : IMonadVisitor<TValue, Boolean>
    {
        public TValue ExpectedValue { get; set; }
        public Boolean AreEqual { get; set; }

        public Boolean VisitValue(TValue value)
        {
            if (AreEqual)
                Assert.AreEqual(ExpectedValue, value);
            else
                Assert.AreNotEqual(ExpectedValue, value);

            return true;
        }
    }
}
