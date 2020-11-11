using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;

namespace Monads.POC.Tests.UnauthorizedMonadTests
{
    public class BindUnauthorizedMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BindPropagatesTheType()
        {
            var firstMonad = new UnauthorizedMonad<Int32>();
            var secondMonad = firstMonad.Bind(val => new ValueMonad<Int32>(val + 1));

            var asserterVisitor = new AssertUnauthorizedVisitor<Int32>();

            secondMonad.Accept(asserterVisitor);
        }

        [Test]
        public void BindPropagatesTheErrorMore()
        {
            var asserterVisitor = new AssertUnauthorizedVisitor<Int32>();

            new UnauthorizedMonad<Int32>()
               .Bind(val => new ValueMonad<Int32>(val + 1))
               .Bind(val => new ValueMonad<Int32>(val + 2))
               .Bind(val => new ValueMonad<Int32>(val + 3))
               .Bind(val => new ValueMonad<Int32>(val + 4))
               .Accept(asserterVisitor);
        }

        [Test]
        public void BindDoesntExecuteAfterError()
        {
            var asserterVisitor = new AssertUnauthorizedVisitor<Int32>();

            ErrorMonad<Int32> Fail(Int32 value)
            {
                Assert.Fail();

                return new ErrorMonad<Int32>("This should never execute");
            }

            Assert.DoesNotThrow(() => new UnauthorizedMonad<Int32>().Bind(Fail));
            
        }
    }
}