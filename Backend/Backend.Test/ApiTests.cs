using Backend.Controllers;
using Backend.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Backend.Test
{
    [TestClass]
    public class ApiTests
    {

        [TestMethod]
        public void Post_ReturnsSimulationResults_WhenChangeDoorIsTrue()
        {
            var controller = new SimulationController();
            var item = new SimulationParameters
            {
                numberOfSimulations = 100,
                changeDoor = true
            };
            var actionResult = controller.RunMontyHallSimulation(item);

            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void Post_ReturnsSimulationResults_WhenChangeDoorIsFalse()
        {
            var controller = new SimulationController();
            var item = new SimulationParameters
            {
                numberOfSimulations = 100,
                changeDoor = false
            };
            var actionResult = controller.RunMontyHallSimulation(item);

            Assert.IsNotNull(actionResult);
        }

    }
}
