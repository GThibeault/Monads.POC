using Monads.POC.Common.Monads.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.ProcessMonadTests
{
    public class AssertProcessVisitor<TValue> : IMonadVisitor<TValue, Boolean>
    {
        public ExpectedMonad ExpectedMonadType { get; set; }
        public Object ExpectedValue { get; set; }

        public Boolean VisitValue(TValue value)
        {
            Assert.AreEqual(ExpectedMonad.Value, ExpectedMonadType);
            Assert.AreEqual(ExpectedValue, value);

            return true;
        }

        public Boolean VisitError(String errorMessage)
        {
            Assert.AreEqual(ExpectedMonad.Error, ExpectedMonadType);
            Assert.AreEqual(ExpectedValue, errorMessage);

            return true;
        }

        public Boolean VisitUnauthorized()
        {
            Assert.AreEqual(ExpectedMonad.Unauthorized, ExpectedMonadType);

            return true;
        }
    }
}
