using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.VisitorImplementations
{
    public class StringifierVisitor<TValue> : IMonadVisitor<TValue, String>
    {
        public String VisitError(String errorMessage) => $"Error monad. Message: <{errorMessage}>.";

        public String VisitUnauthorized() => $"Unauthorized monad.";

        public String VisitValue(TValue value) => $"Value monad. Value: <{value}>.";
    }
}
