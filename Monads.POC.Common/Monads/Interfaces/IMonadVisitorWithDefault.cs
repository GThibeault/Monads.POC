using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.Interfaces
{
    /// <summary>
    /// Visitor pattern for monads, with a generic visit method.
    /// Each particular visit method provides a default implementation calling the generic visit.
    /// </summary>
    /// <typeparam name="TValue">Value of the visited monad.</typeparam>
    /// <typeparam name="TReturn">The return type of all visits.</typeparam>
    public interface IMonadVisitorWithDefault<TValue, TReturn> : IMonadVisitor<TValue, TReturn>
    {
        TReturn IMonadVisitor<TValue, TReturn>.VisitValue(TValue value) => VisitDefault();
        TReturn IMonadVisitor<TValue, TReturn>.VisitError(String errorMessage) => VisitDefault();
        TReturn IMonadVisitor<TValue, TReturn>.VisitUnauthorized() => VisitDefault();

        /// <summary>
        /// Default visit called when a specific visit type is not implemented.
        /// </summary>
        public TReturn VisitDefault();
    }
}
