using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.Interfaces
{
    public interface IMonadVisitor<TValue, TReturn>
    {
        public TReturn VisitValue(TValue value);
    }
}
