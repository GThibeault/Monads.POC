using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    public class SafeValueMonad<TValue> : ValueMonad<TValue>
    {
        public SafeValueMonad(TValue value) : base(value) {}

        public override IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            try
            {
                return base.Bind(bindFunc);
            }
            catch (Exception ex)
            {
                return new ErrorMonad<TNext>(ex.Message);
            }
        }
    }
}
