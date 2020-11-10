using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;

namespace Monads.POC.Tests.ValueMonadTests
{
    public class ReturnValueMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnIntValueIsEqual()
        {
            var value = 2020;
            var monad = new ValueMonad<Int32>(value);

            var asserterVisitor = new AssertValueVisitor<Int32>
            {
                ExpectedValue = value,
                AreEqual = true
            };

            monad.Accept(asserterVisitor);
        }

        [Test]
        public void DifferentReturnIntValueIsNotEqual()
        {
            var value = 2020;
            var monad = new ValueMonad<Int32>(value);

            var asserterVisitor = new AssertValueVisitor<Int32>
            {
                ExpectedValue = 0,
                AreEqual = false
            };

            monad.Accept(asserterVisitor);
        }

        [Test]
        public void ReturnStringValueIsEqual()
        {
            var value = "SomeVal";
            var monad = new ValueMonad<String>(value);

            var asserterVisitor = new AssertValueVisitor<String>
            {
                ExpectedValue = value,
                AreEqual = true
            };

            monad.Accept(asserterVisitor);
        }

        [Test]
        public void DifferentReturnStringValueIsNotEqual()
        {
            var value = "SomeVal";
            var monad = new ValueMonad<String>(value);

            var asserterVisitor = new AssertValueVisitor<String>
            {
                ExpectedValue = "SomeOtherVal",
                AreEqual = false
            };

            monad.Accept(asserterVisitor);
        }
    }
}