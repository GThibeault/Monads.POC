using Monads.POC.Common.Monads.Implementations;
using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;

namespace Monads.POC.Tests.ErrorMonadTests
{
    public class BindErrorMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BindPropagatesTheError()
        {
            var errMessage = "error message";
            var firstMonad = new ErrorMonad<Int32>(errMessage);
            var secondMonad = firstMonad.Bind(val => new ValueMonad<Int32>(val + 1));

            var asserterVisitor = new AssertErrorVisitor<Int32>
            {
                ExpectedError = errMessage,
                AreEqual = true
            };

            secondMonad.Accept(asserterVisitor);
        }

        [Test]
        public void BindPropagatesTheErrorMore()
        {
            var errMessage = "error message";

            var asserterVisitor = new AssertErrorVisitor<Int32>
            {
                ExpectedError = errMessage,
                AreEqual = true
            };

            new ErrorMonad<Int32>(errMessage)
               .Bind(val => new ValueMonad<Int32>(val + 1))
               .Bind(val => new ValueMonad<Int32>(val + 2))
               .Bind(val => new ValueMonad<Int32>(val + 3))
               .Bind(val => new ValueMonad<Int32>(val + 4))
               .Accept(asserterVisitor);
        }

        [Test]
        public void BindDoesntExecuteAfterError()
        {
            var errMessage = "error message";

            var asserterVisitor = new AssertErrorVisitor<Int32>
            {
                ExpectedError = errMessage,
                AreEqual = true
            };

            ErrorMonad<Int32> Fail(Int32 value)
            {
                Assert.Fail();

                return new ErrorMonad<Int32>("This should never execute");
            }

            Assert.DoesNotThrow(() => new ErrorMonad<Int32>(errMessage).Bind(Fail));
            
        }
    }
}