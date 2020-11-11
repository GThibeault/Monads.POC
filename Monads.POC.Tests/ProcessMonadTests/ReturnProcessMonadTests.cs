using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.ProcessMonadTests
{
    public class ReturnProcessMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProcessIdIsProperlyInitialized()
        {
            var processMonad = ProcessMonad<Boolean>.With(() => new ErrorMonad<Boolean>(String.Empty));

            Assert.IsNotNull(processMonad.ProcessId);
            Assert.AreNotEqual(default(Guid), processMonad.ProcessId);
        }

        [Test]
        public void ReturnRespectsInnerValueMonad()
        {
            var asserterVisitor = new AssertProcessVisitor<Int32>
            {
                ExpectedMonadType = ExpectedMonad.Value,
                ExpectedValue = 2020
            };

            ProcessMonad<Int32>
                .With(() => new ValueMonad<Int32>(2020))
                .Accept(asserterVisitor);
        }

        [Test]
        public void ReturnRespectsInnerErrorMonad()
        {
            var asserterVisitor = new AssertProcessVisitor<Int32>
            {
                ExpectedMonadType = ExpectedMonad.Error,
                ExpectedValue = "some err"
            };

            ProcessMonad<Int32>
                .With(() => new ErrorMonad<Int32>("some err"))
                .Accept(asserterVisitor);
        }
    }
}
