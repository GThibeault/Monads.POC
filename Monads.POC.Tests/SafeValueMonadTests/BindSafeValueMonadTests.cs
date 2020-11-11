using Monads.POC.Common.Monads.MonadImplementations;
using Monads.POC.Tests.ErrorMonadTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.SafeValueMonadTests
{
    public class BindSafeValueMonadTests
    {
        [Test]
        public void BindDoesntThrow()
        {
            void ThrowInBind()
            {
                new SafeValueMonad<Int32>(2020)
                    .Bind<Int32>(val => throw new InvalidOperationException("err"));
            }

            Assert.DoesNotThrow(ThrowInBind);
        }

        [Test]
        public void ThrowInBindProducesErrorMonad()
        {
            var monad = new SafeValueMonad<Int32>(2020)
                .Bind<Boolean>(val => throw new InvalidOperationException("err"));

            Assert.IsInstanceOf(typeof(ErrorMonad<Boolean>), monad);
        }

        [Test]
        public void ThrowInBindProducesCorrectErrorMessage()
        {
            var monad = new SafeValueMonad<Int32>(2020)
                .Bind<Boolean>(val => throw new InvalidOperationException("err"));

            var visitor = new AssertErrorVisitor<Boolean>
            {
                AreEqual = true,
                ExpectedError = "err"
            };

            monad.Accept(visitor);
        }
    }
}
