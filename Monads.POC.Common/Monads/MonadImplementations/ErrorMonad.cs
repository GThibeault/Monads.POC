using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    public class ErrorMonad<TValue> : IMonad<TValue>
    {
        protected String ErrorMessage { get; }

        public ErrorMonad(String errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor)
        {
            return visitor.VisitError(ErrorMessage);
        }

        public IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            return new ErrorMonad<TNext>(ErrorMessage);
        }
    }
}
