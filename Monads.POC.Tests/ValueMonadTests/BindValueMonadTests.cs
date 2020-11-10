using Monads.POC.Common.Monads.Implementations;
using NUnit.Framework;
using System;

namespace Monads.POC.Tests.ValueMonadTests
{
    public class BindValueMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BindReturnsTheSecondValue()
        {
            var firstVal = 1;
            var firstMonad = new ValueMonad<Int32>(firstVal);
            var secondMonad = firstMonad.Bind(val => new ValueMonad<Int32>(val + 1));

            var asserterVisitor = new AssertValueVisitor<Int32>
            {
                ExpectedValue = firstVal + 1,
                AreEqual = true
            };

            secondMonad.Accept(asserterVisitor);
        }

        [Test]
        public void BindDoesntReturnADifferentValue()
        {
            var firstVal = 1;
            var firstMonad = new ValueMonad<Int32>(firstVal);
            var secondMonad = firstMonad.Bind(val => new ValueMonad<Int32>(val + 1));

            var asserterVisitor = new AssertValueVisitor<Int32>
            {
                ExpectedValue = 0,
                AreEqual = false
            };

            secondMonad.Accept(asserterVisitor);
        }

        [Test]
        public void BindReturnsTheSecondValueOFDifferentType()
        {
            var firstVal = 1;
            var firstMonad = new ValueMonad<Int32>(firstVal);
            var secondMonad = firstMonad.Bind(val => new ValueMonad<String>($"First val is: {val}."));

            var asserterVisitor = new AssertValueVisitor<String>
            {
                ExpectedValue = "First val is: 1.",
                AreEqual = true
            };

            secondMonad.Accept(asserterVisitor);
        }
    }
}