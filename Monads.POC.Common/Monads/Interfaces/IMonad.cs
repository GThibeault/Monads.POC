using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Interfaces
{
    public interface IMonad<TValue>
    {
        public IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc);

        public TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor);
    }
}
