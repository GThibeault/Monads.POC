using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Interfaces
{
    public interface IMonad<T>
    {
        public IMonad<TNext> Bind<TNext>(Func<T, IMonad<TNext>> bindFunc);
    }
}
