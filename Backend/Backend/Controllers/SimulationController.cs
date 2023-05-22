using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        public object RunMontyHallSimulation(SimulationParameters simulationParameters)
        {
            int wins = 0; 
            int losses = 0;

            Random random = new Random();
            int numberOfSimulations = simulationParameters.numberOfSimulations;
            bool changeDoor = simulationParameters.changeDoor;

            for (int i = 0; i < numberOfSimulations; i++)
            {
                bool won = SimulateMontyHallGameRound(changeDoor);

                if (won)
                    wins++;
                else
                    losses++;
            }

            var result = new { wins, losses };

            return result;
        }

        public static bool SimulateMontyHallGameRound(bool changeDoor)
        {
            Random random = new Random();
            bool win = false;

            int carDoor = random.Next(3);
            int pickedDoor = random.Next(3);

            int removingGoatDoor = -1;

            //determine the door with goat
            for (int doorPosition = 0; doorPosition < 3; doorPosition++)
            {
                if (doorPosition != carDoor && doorPosition != pickedDoor)
                {
                    removingGoatDoor = doorPosition;
                    break;
                }
            }

            if (!changeDoor)
            {
                win = carDoor == pickedDoor;
            }
            else
            {
                //determine the remaining unchosen door
                int remainingDoor = 3 - pickedDoor - removingGoatDoor;
                win = carDoor == remainingDoor;
            }

            return win;
        }

    }
}
