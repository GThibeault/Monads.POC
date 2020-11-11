using Monads.POC.Common.Monads.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monads.POC.Tests.ProcessMonadTests
{
    public enum ExpectedMonad
    {
        Invalid,
        Value,
        Error,
        Unauthorized
    }
}
