using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    /// <summary>
    /// A monad wrapping a value (like the base ValueMonad), but encasing the bind execution within a try/catch block.
    /// If an exception is caught, an ErrorMonad is returned with the exception message as its error.
    /// </summary>
    /// <typeparam name="TValue">The type of the wrapped value.</typeparam>
    public class SafeValueMonad<TValue> : ValueMonad<TValue>
    {
        public SafeValueMonad(TValue value) : base(value) {}

        /// <summary>
        /// Executes the bind operation, but returns an ErrorMonad rather than throwing an exception if one arises.
        /// </summary>
        /// <typeparam name="TNext">The type of the value returned by the bound function.</typeparam>
        /// <param name="bindFunc">Function applied to the value held by the monad, returning another monad.</param>
        /// <returns>The result of executing the bound function, or an ErrorMonad if it throws an exception.</returns>
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
