namespace AirConditionerTesterSystem.Tests
{
    using Core;
    using Core.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repositories;

    [TestClass]
    public class Status_Should
    {
        [TestClass]
        public class StatusTests
        {
            private IAirConditionerTesterSystemData data;
            private IController controller;

            [TestInitialize]
            public void SetUp()
            {
                this.data = new AirConditionerTesterSystemData();
                this.controller = new Controller(this.data);
            }

            [TestMethod]
            public void TestStatus_ValidInput_ShouldReturn0PercentTested()
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN100", 'A', 777);
                this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN101", 'B', 778);
                var result = this.controller.Status();

                Assert.AreEqual("Jobs complete: 0.00%", result);
            }

            [TestMethod]
            public void TestStatus_ValidInput_ShouldReturn50PercentTested()
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN100", 'A', 777);
                this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN101", 'B', 778);
                this.controller.TestAirConditioner("Toshiba", "AXN100");
                var result = this.controller.Status();

                Assert.AreEqual("Jobs complete: 50.00%", result);
            }

            [TestMethod]
            public void TestStatus_ShouldReturnCorrectlyRoundedResult()
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN100", 'A', 777);
                this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN101", 'B', 778);
                this.controller.RegisterStationaryAirConditioner("Hitachi", "AXN120", 'C', 776);

                this.controller.TestAirConditioner("Toshiba", "AXN100");
                this.controller.TestAirConditioner("Hitachi", "AXN120");

                var result = this.controller.Status();

                Assert.AreEqual("Jobs complete: 66.67%", result);
            }
        }
    }
}
