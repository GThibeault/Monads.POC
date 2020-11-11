using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    /// <summary>
    /// A monad representing an authorization error in execution.
    /// Bind operations propagate the error without calling the input functions.
    /// </summary>
    /// <typeparam name="TValue">The underlying type of the monad. 
    /// Keep in mind no value is actually stored by the monad, though.
    /// </typeparam>
    public class UnauthorizedMonad<TValue> : IMonad<TValue>
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public virtual TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor)
        {
            return visitor.VisitUnauthorized();
        }

        /// <summary>
        /// Propagates the error without calling the input function.
        /// </summary>
        /// <typeparam name="TNext">Type of the following monad.</typeparam>
        /// <param name="bindFunc">The bound function, though it won't actually be called.</param>
        /// <returns>An error monad of the corresponding type with the same error message.</returns>
        public virtual IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            return new UnauthorizedMonad<TNext>();
        }
    }
}
