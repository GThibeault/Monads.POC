using Microsoft.Extensions.Logging;
using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monads.POC.Tests.LoggerMonadTests
{
    public class BindLoggerMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BindWithValueMonadIsProperlyLogged()
        {
            var logger = new TestLogger();

            _ = new LoggerMonad<Int32>(new ValueMonad<Int32>(0), logger)
                .Bind(val => new ValueMonad<Int32>(2020));

            Assert.IsNotNull(logger.LoggedValues);
            Assert.IsTrue(logger.LoggedValues[1].Contains("bind", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues[1].Contains("2020", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues[1].Contains("value", StringComparison.InvariantCultureIgnoreCase));
        }

        [Test]
        public void ConstructorWithErrorMonadIsProperlyLogged()
        {
            var logger = new TestLogger();

            _ = new LoggerMonad<Int32>(new ValueMonad<Int32>(2020), logger)
                .Bind(val => new ErrorMonad<Int32>($"#{val}"));

            Assert.IsNotNull(logger.LoggedValues);
            Assert.IsTrue(logger.LoggedValues[1].Contains("bind", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues[1].Contains("#2020", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues[1].Contains("error", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
