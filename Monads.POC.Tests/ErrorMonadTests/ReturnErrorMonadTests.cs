using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;

namespace Monads.POC.Tests.ErrorMonadTests
{
    public class ReturnErrorMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnErrorIsEqual()
        {
            var value = "error";
            var monad = new ErrorMonad<String>(value);

            var asserterVisitor = new AssertErrorVisitor<String>
            {
                ExpectedError = value,
                AreEqual = true
            };

            monad.Accept(asserterVisitor);
        }

        [Test]
        public void ReturnErrorIsEqualEvenForInt()
        {
            var value = "error";
            var monad = new ErrorMonad<Int32>(value);

            var asserterVisitor = new AssertErrorVisitor<Int32>
            {
                ExpectedError = value,
                AreEqual = true
            };

            monad.Accept(asserterVisitor);
        }

        [Test]
        public void DifferentReturnErrorIsNotEqual()
        {
            var value = "SomeErr";
            var monad = new ErrorMonad<Int32>(value);

            var asserterVisitor = new AssertErrorVisitor<Int32>
            {
                ExpectedError = "SomeOtherErr",
                AreEqual = false
            };

            monad.Accept(asserterVisitor);
        }
    }
}