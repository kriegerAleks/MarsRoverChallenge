using MarsRoverChallenge;
using MarsRoverChallenge.Rover;
using MarsRoverChallenge.Simulation;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRoverChallengeTestProject.Simulation
{
    public class SimulationTests
    {
        [Fact]
        public void Simulation_SavesDataCorrectly_WhenPassingPosition()
        {
            var positionMock = new Position(0, 0);

            var createdSimulation = new DefaultSimulation(positionMock);

            Assert.Equal(createdSimulation.plateau.boundary, positionMock);
        }

        [Fact]
        public void Simulation_SavesDataCorrectly_WhenPassingPoints()
        {
            int x = 1;
            int y = 1;

            var createdSimulation = new DefaultSimulation(x, y);

            Assert.True(x == createdSimulation.plateau.boundary.X && y == createdSimulation.plateau.boundary.Y);
        }

        [Fact]
        public void Simulation_AddRover_AddsRoversToList()
        {
            var simulationBoundary = new Position(1, 1);
            var createdSimulation = new DefaultSimulation(simulationBoundary);

            var roverInitialPosition = new Position(0, 0);
            var roverInstructions = new RoverInstruction[] { RoverInstruction.Left, RoverInstruction.Move };

            createdSimulation.addRover(roverInitialPosition, roverInstructions);

            var (rover, currentPosition, instructionList) = createdSimulation.roverList[0];

            Assert.IsType<DefaultRover>(rover);
            Assert.Equal(currentPosition, roverInitialPosition);
            Assert.Equal(instructionList, roverInstructions);
        }

    }
}

    }
}