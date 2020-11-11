using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.LoggerMonadTests
{
    public class NullVisitor<TValue> : IMonadVisitorWithDefault<TValue, Boolean>
    {
        public Boolean VisitDefault() => true;
    }
}
