using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;

namespace Monads.POC.Tests.UnauthorizedMonadTests
{
    public class ReturnUnauthorizedMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnTypeIsCorrect()
        {
            var monad = new UnauthorizedMonad<String>();

            var asserterVisitor = new AssertUnauthorizedVisitor<String>();

            monad.Accept(asserterVisitor);
        }
    }
}