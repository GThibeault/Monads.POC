using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.ProcessMonadTests
{
    public class BindProcessMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProcessIdIsPropagatedThroughBinds()
        {
            var processMonad = ProcessMonad<Boolean>.With(() => new ErrorMonad<Boolean>(String.Empty));
            var id = processMonad.ProcessId;

            var secondMonad = processMonad.Bind(val => new ErrorMonad<Boolean>(String.Empty)) as ProcessMonad<Boolean>;
            Assert.AreEqual(id, secondMonad.ProcessId);
        }

        [Test]
        public void BindRespectsInnerValueMonad()
        {
            var asserterVisitor = new AssertProcessVisitor<Int32>
            {
                ExpectedMonadType = ExpectedMonad.Value,
                ExpectedValue = 2021
            };

            ProcessMonad<Int32>
                .With(() => new ValueMonad<Int32>(2020))
                .Bind(val => new ValueMonad<Int32>(val + 1))
                .Accept(asserterVisitor);
        }

        [Test]
        public void BindRespectsInnerErrorMonad()
        {
            var asserterVisitor = new AssertProcessVisitor<Int32>
            {
                ExpectedMonadType = ExpectedMonad.Error,
                ExpectedValue = "some"
            };

            ProcessMonad<Int32>
                .With(() => new ErrorMonad<Int32>("some"))
                .Bind(val => new ErrorMonad<Int32>("some err"))
                .Accept(asserterVisitor);
        }
    }
}
