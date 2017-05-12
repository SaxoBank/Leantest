﻿using System;
using LeanTest.Core.ExecutionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mock.Examples.MsTest.Application;
using Mock.Examples.MsTest.Domain;

namespace Mock.Examples.MsTest
{
    /// <summary>
    /// Work-in-progress. 
    /// Note that in a real-world example we must choose an IoC container - here we have implemented our own for
    /// this example. See the ValueAdd solution for examples of using Unity. 
    /// This container must be initialized in an AssemblyInitializer class - refer to this class to see how it is
    /// sone with our example IoC container.
    /// For the example to be more complete, there should be two projects, one for test one for what is being tested.
    /// </summary>
    [TestClass]
    public class TestMyApplicationService
    {
        private ContextBuilder _contextBuilder;
        private MyApplicationService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextBuilder = ContextBuilderFactory.CreateContextBuilder()
                .Build();

            _target = _contextBuilder.GetInstance<MyApplicationService>();
        }

        [TestMethod, TestCategory("Unit"), TestCategory("SystemIntegration")]
        public void GetAgeMustReturn10WhenKeyMatchesNewedUpData()
        {
            _contextBuilder
                .WithData(new MyData { Age = 10, Key = "ac_32_576259321" })
                .Build();

            int actual = _target.GetAge("FourtyTwo");

            Assert.AreEqual(10, actual);
        }
    }
}
