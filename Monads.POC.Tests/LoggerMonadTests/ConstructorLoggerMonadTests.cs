using Microsoft.Extensions.Logging;
using Monads.POC.Common.Monads.MonadImplementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monads.POC.Tests.LoggerMonadTests
{
    public class ConstructorLoggerMonadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWithValueMonadIsProperlyLogged()
        {
            var logger = new TestLogger();

            _ = new LoggerMonad<Int32>(new ValueMonad<Int32>(2020), logger);

            Assert.IsNotNull(logger.LoggedValues);
            Assert.AreEqual(1, logger.LoggedValues.Count);
            Assert.IsTrue(logger.LoggedValues.Single().Contains("construct", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues.Single().Contains("2020", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues.Single().Contains("value", StringComparison.InvariantCultureIgnoreCase));
        }

        [Test]
        public void ConstructorWithErrorMonadIsProperlyLogged()
        {
            var logger = new TestLogger();

            _ = new LoggerMonad<Int32>(new ErrorMonad<Int32>("SomeString"), logger);

            Assert.IsNotNull(logger.LoggedValues);
            Assert.AreEqual(1, logger.LoggedValues.Count);
            Assert.IsTrue(logger.LoggedValues.Single().Contains("construct", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues.Single().Contains("somestring", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(logger.LoggedValues.Single().Contains("error", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
