using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.LoggerMonadTests
{
    public class NullVisitor<TValue> : IMonadVisitor<TValue, Boolean>
    {
        public Boolean VisitError(String errorMessage) => true;
        public Boolean VisitValue(TValue value) => true;
    }
}
