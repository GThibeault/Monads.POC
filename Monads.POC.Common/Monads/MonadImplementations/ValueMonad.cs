using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    /// <summary>
    /// A monad wrapping a value, which is passed as the argument of the bind function or when accepting a visitor.
    /// </summary>
    /// <typeparam name="TValue">The type of the wrapped value.</typeparam>
    public class ValueMonad<TValue> : IMonad<TValue>
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        protected TValue Value { get; }

        public ValueMonad(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// Executes the input function to return a new monad, passing the current wrapped value as a parameter.
        /// </summary>
        /// <typeparam name="TNext">Type of the returned monad's value.</typeparam>
        /// <param name="bindFunc"></param>
        /// <returns></returns>
        public virtual IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            return bindFunc(Value);
        }

        /// <summary>
        /// Calls the "VisitValue" method on the visitor, passing the wrapped value as a parameter. 
        /// </summary>
        /// <typeparam name="TReturn">Return type of the input visitor.</typeparam>
        /// <param name="visitor">Monad visitor to accept.</param>
        /// <returns>Result of the value visit.</returns>
        public virtual TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor)
        {
            return visitor.VisitValue(Value);
        }
    }
}
