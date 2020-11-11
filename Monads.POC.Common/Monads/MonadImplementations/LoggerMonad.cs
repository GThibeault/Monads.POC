using Microsoft.Extensions.Logging;
using Monads.POC.Common.Interfaces;
using Monads.POC.Common.Monads.Interfaces;
using Monads.POC.Common.Monads.VisitorImplementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Common.Monads.MonadImplementations
{
    /// <summary>
    /// Wraps other monads, logging data for each operation.
    /// </summary>
    /// <typeparam name="TValue">The type of the underlying monad.</typeparam>
    public class LoggerMonad<TValue> : IMonad<TValue>
    {
        protected ILogger Logger { get; }
        protected IMonad<TValue> InnerMonad { get; }

        public LoggerMonad(IMonad<TValue> innerMonad, ILogger logger)
        {
            Logger = logger;
            InnerMonad = innerMonad;

            String stringified = StringifyMonad(InnerMonad);
            Logger.LogInformation($"Constructing logger monad: <{stringified}>.");
        }

        /// <summary>
        /// Delegates the bind operation to the wrapped monad.
        /// </summary>
        public IMonad<TNext> Bind<TNext>(Func<TValue, IMonad<TNext>> bindFunc)
        {
            IMonad<TNext> nextMonad = InnerMonad.Bind(bindFunc);

            String stringified = StringifyMonad(InnerMonad);
            Logger.LogInformation($"Binding result: <{stringified}>.");

            return new LoggerMonad<TNext>(nextMonad, Logger);
        }

        /// <summary>
        /// Delegates the accept operation to the wrapped monad.
        /// </summary>
        public TReturn Accept<TReturn>(IMonadVisitor<TValue, TReturn> visitor)
        {
            String stringified = StringifyMonad(InnerMonad);
            Logger.LogInformation($"Accepting visitor with monad: <{stringified}>.");

            return InnerMonad.Accept(visitor);
        }

        /// <summary>
        /// Instantiates a visitor to stringify the input monad.
        /// </summary>
        /// <typeparam name="TMonadValue">Value type of the monad.</typeparam>
        /// <param name="monad">Monad to serialize.</param>
        /// <returns>The stringified input monad.</returns>
        protected String StringifyMonad<TMonadValue>(IMonad<TMonadValue> monad)
        {
            IMonadVisitor<TMonadValue, String> stringifier = new StringifierVisitor<TMonadValue>();
            return monad.Accept(stringifier);
        }
    }
}
