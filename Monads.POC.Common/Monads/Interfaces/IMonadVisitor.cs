using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.Interfaces
{
    /// <summary>
    /// Visitor pattern used to safely extract values from monads, handling each monadic type accordingly.
    /// </summary>
    /// <typeparam name="TValue">The type of the visited monad's value.</typeparam>
    /// <typeparam name="TReturn">The return type of all visits.</typeparam>
    public interface IMonadVisitor<TValue, TReturn>
    {
        /// <summary>
        /// Visits a value wrapped by a ValueMonad.
        /// </summary>
        /// <param name="value">The wrapped value.</param>
        public TReturn VisitValue(TValue value);

        /// <summary>
        /// Visits the error propagated by an ErrorMonad.
        /// </summary>
        /// <param name="errorMessage">The propagated error message.</param>
        public TReturn VisitError(String errorMessage);
    }
}
