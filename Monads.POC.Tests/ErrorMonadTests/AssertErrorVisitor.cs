using Monads.POC.Common.Monads.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.ErrorMonadTests
{
    public class AssertErrorVisitor<TValue> : IMonadVisitorWithDefault<TValue, Boolean>
    {
        public String ExpectedError { get; set; }
        public Boolean AreEqual { get; set; }

        public Boolean VisitDefault()
        {
            Assert.Fail();

            return false;
        }

        public Boolean VisitError(String errorMessage)
        {
            if (AreEqual)
                Assert.AreEqual(ExpectedError, errorMessage);
            else
                Assert.AreNotEqual(ExpectedError, errorMessage);

            return true;
        }
    }
}
