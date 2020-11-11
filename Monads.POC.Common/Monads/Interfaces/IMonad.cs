using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Interfaces
{
    /// <summary>
    /// Monads are generic types which wrap values and provide a bind method to chain sequential operations on those values.
    /// Different implementations can modify the handling of sequential bind execution, the wrapped value, errors and so on, as well as adding context to each operation.
    /// 
    /// A visitor pattern is used to extract the wrapped value, handling each type of monad accordingly.
    /// 
    /// Several aspects of execution can be encapsulated in monads, greatly reducing boilerplate code in business logic.
    /// 
    /// Examples of monads provided by later versions of C# are nullable value types.
    /// The type TValue? is a monad over the underlying type TValue, with the null-conditional operator (?.) implementing the bind operation.
    /// The underlying value is extracted through the null-coalescing operator (??) rather than the visitor pattern favored in this solution.
    /// 
    /// Monads also provide far stronger compile-time guarantees than traditional imperative programming.
    /// In many cases, the fact that monadic code compiles ensures certain runtime behavior won't happen, such as attempting to access a null or erroroneous value.
    /// 
    /// In functional programming, Monads are required to provide a "return" method (with a signature similar to static IMonad<TValue> Return(TValue value)) to create a monadic value from a plain one.
    /// In this scenario, each monad implementation is left to define its own constructor, more closely following OOP principles.
    /// Consider adding the return method to the interface if more traditional FP monadic functionality is desired.
    /// 
    /// A common addition to the interface is a "sequence" method, with similar functionality to "bind" but discarding the wrapped value.
    /// Its signature would be similar to IMonad<TNext> Sequence<TNext>(Func<IMonad<TNext>> sequenceFunc).
    /// 
    /// See https://en.wikipedia.org/wiki/Monad_%28functional_programming%29 for more info.
    /// </summary>
    /// <typeparam name="TValue">The wrapped value</typeparam>
    public interface IMonad<TValue>
    {
        /// <summary>
        /// Executes an operation taking a value of the wrapped type as a parameter.
        /// Used to chain sequential operations.
        /// </summary>
        /// <typeparam name="TNext">Type of the value wrapped by the monad returned by the bound function.</typeparam>
        /// <param name="bindFunc">Function to be executed on a value of the wrapped type.</param>
        /// <returns>A new monad, wrapping a value of a possibly new type.</returns>
        public IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc);

        /// <summary>
        /// Accept method used in the Visitor pattern.
        /// Used to properly handle the wrapped value.
        /// </summary>
        /// <typeparam name="TReturn">Return type of all the visitor's visit methods.</typeparam>
        /// <param name="visitor">Visitor implementing handling methods for the different monadic types.</param>
        /// <returns>The result of the visitor's corresponding visit.</returns>
        public TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor);
    }
}
