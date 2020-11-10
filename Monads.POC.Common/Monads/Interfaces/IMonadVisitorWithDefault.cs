using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.Interfaces
{
    public interface IMonadVisitorWithDefault<TValue, TReturn> : IMonadVisitor<TValue, TReturn>
    {
        TReturn IMonadVisitor<TValue, TReturn>.VisitValue(TValue value) => VisitDefault();
        TReturn IMonadVisitor<TValue, TReturn>.VisitError(String errorMessage) => VisitDefault();

        public TReturn VisitDefault();
    }
}
