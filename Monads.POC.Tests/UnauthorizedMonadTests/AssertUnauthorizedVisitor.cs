using Monads.POC.Common.Monads.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.UnauthorizedMonadTests
{
    public class AssertUnauthorizedVisitor<TValue> : IMonadVisitorWithDefault<TValue, Boolean>
    {
        public Boolean VisitDefault()
        {
            Assert.Fail();

            return false;
        }

        public Boolean VisitUnauthorized() => true;
    }
}
