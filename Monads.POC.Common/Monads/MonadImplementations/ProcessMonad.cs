using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    /// <summary>
    /// Wraps other monads, adding a unique process identifier which is propagated throughout the monads' execution.
    /// </summary>
    /// <typeparam name="TValue">The type of the underlying monad.</typeparam>
    public class ProcessMonad<TValue> : IMonad<TValue>
    {
        public Guid ProcessId { get; }
        protected IMonad<TValue> InnerMonad { get; }

        public ProcessMonad(IMonad<TValue> innerMonad, Guid? processId = null)
        {
            ProcessId = processId ?? Guid.NewGuid();
            InnerMonad = innerMonad;
        }

        public IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            IMonad<TNext> nextMonad = InnerMonad.Bind(bindFunc);

            return new ProcessMonad<TNext>(nextMonad, ProcessId);
        }

        public TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor)
        {
            return InnerMonad.Accept(visitor);
        }

        /// <summary>
        /// Fluent and lazy alternative to the constructor.
        /// </summary>
        /// <typeparam name="TNext">The type of the returned monad.</typeparam>
        /// <param name="sequenceFunc">Function to be executed, returning a monad to be wrapped.</param>
        /// <returns>A new ProcessMonad with the result of the function's execution as its inner monad.</returns>
        public static ProcessMonad<TNext> With<TNext>(Func<IMonad<TNext>> sequenceFunc)
        {
            IMonad<TNext> nextMonad = sequenceFunc();

            return new ProcessMonad<TNext>(nextMonad);
        }
    }
}
