using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    public class ValueMonad<TValue> : IMonad<TValue>
    {
        protected TValue Value { get; }

        public ValueMonad(TValue value)
        {
            Value = value;
        }

        public virtual IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            return bindFunc(Value);
        }

        public virtual TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor)
        {
            return visitor.VisitValue(Value);
        }
    }
}
