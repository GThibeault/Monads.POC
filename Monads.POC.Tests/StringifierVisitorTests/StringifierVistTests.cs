using Monads.POC.Common.Monads.MonadImplementations;
using Monads.POC.Common.Monads.VisitorImplementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.StringifierVisitorTests
{
    public class StringifierVisitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringifiesValueMonadCorrectly()
        {
            var monad = new ValueMonad<Int32>(2020);
            var visitor = new StringifierVisitor<Int32>();

            var stringifyRes = monad.Accept(visitor);

            Assert.IsNotNull(stringifyRes);
            Assert.IsTrue(stringifyRes.Contains("2020", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(stringifyRes.Contains("value", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}