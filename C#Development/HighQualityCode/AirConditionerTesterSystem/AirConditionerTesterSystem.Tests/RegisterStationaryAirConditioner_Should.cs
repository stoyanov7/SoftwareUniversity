namespace AirConditionerTesterSystem.Tests
{
    using System;
    using Core;
    using Core.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repositories;
    using Utilities;

    [TestClass]
    public class RegisterStationaryAirConditioner_Should
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
        public void RegisterStationaryAirConditioner_ValidInput_ShoudReturnSuccessMessage()
        {
            var message = this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN100", 'A', 777);

            Assert.AreEqual("Air Conditioner model AXN100 from Toshiba registered successfully.", message);
        }

        [TestMethod]
        public void RegisterStationaryAC_InvalidEnergyEfficientRating_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => this.controller.RegisterStationaryAirConditioner("Toshiba", "AXN100", 'N', 777));
        }

        [TestMethod]
        public void RegisterStationaryAC_ShortManufacturerName_ShouldThrowException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => this.controller.RegisterStationaryAirConditioner("T", "AXN100", 'A', 777));
        }

        [TestMethod]
        public void RegisterStationaryAC_ShortManufacturerName_TestErrorMessage()
        {
            try
            {
                this.controller.RegisterStationaryAirConditioner("T", "AXN100", 'A', 777);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Manufacturer's name must be at least {Constants.ManufacturerMinLength} symbols long.", ex.Message);
            }
        }

        [TestMethod]
        public void RegisterStationaryAC_ShortModelName_ThrowException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => this.controller.RegisterStationaryAirConditioner("Toshiba", "A", 'B', 777));
        }

        [TestMethod]
        public void RegisterStationaryAC_ShortModelName_ShouldReturnCorrectErrorMessage()
        {
            try
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "A", 'B', 777);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Model's name must be at least {Constants.ModelMinLength} symbols long.", ex.Message);
            }
        }

        [TestMethod]
        public void RegisterStationaryAC_ZeroPowerUsage_ThrowException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => this.controller.RegisterStationaryAirConditioner("Toshiba", "A", 'B', 0));
        }

        [TestMethod]
        public void RegisterStationaryAc_WithIncorrectPowerUsage_ShouldThrowCorrectExceptionMessage()
        {
            try
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "EX100", 'B', -50);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Power Usage must be a positive integer.", ex.Message, "Expected message did not match!");
            }
        }
    }
}
