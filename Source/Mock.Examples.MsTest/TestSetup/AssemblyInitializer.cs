﻿using LeanTest.Core.ExecutionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mock.Examples.MsTest.IoC;

namespace Mock.Examples.MsTest.TestSetup
{
    [TestClass]
    public static class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            ContextBuilderFactory.Initialize(() => new MyOwnIoC());
            ContextBuilderFactory.CreateContextBuilder();
        }
    }
}
