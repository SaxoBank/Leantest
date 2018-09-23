﻿using ExampleApp.Domain;
using LeanTest.Core.ExecutionHandling;
using LeanTest.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mock.Examples.MsTest.Application;

namespace Mock.Examples.MsTest
{
	/// <summary>
	/// Note that in a real-world example we must choose an IoC container - here we have implemented our own for
	/// this example. See the ValueAdd solution for examples of using Unity. 
	/// This container must be initialized in an AssemblyInitializer class - refer to this class to see how it is
	/// done with our example IoC container.
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
			_contextBuilder = ContextBuilderFactory.ContextBuilder
				.WithData<MyData>()
				.Build();

			_target = _contextBuilder.GetInstance<MyApplicationService>();
		}

		[TestMethod]
		public void GetAgeMustReturn10WhenKeyMatchesNewedUpData()
		{
			_contextBuilder
				.WithMyExternalService().WithData(new MyData { Age = 10, Key = "ac_32_576259321" })
				.WithData(new MyOtherData { OtherAge = 10, OtherKey = "ac_32_576259321" })
				.Build();

			int actual = _target.GetAge("FourtyTwo");

			Assert.AreEqual(10, actual);
		}
	}

	// TODO: Implement builder for IMockForDataWithContextBuilder?
	public static class ContextBuilderExtenstions
	{
		public static IMockForDataWithContextBuilder<MyData> WithMyExternalService(this ContextBuilder contextBuilder)
		{
			// TODO: This is wrong! We do not want code outside LeanTest work directly on instances!
			return contextBuilder.GetInstance<IMockForDataWithContextBuilder<MyData>>();
		}
	}
}
