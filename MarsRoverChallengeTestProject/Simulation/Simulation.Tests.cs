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

        private class RoverData
        {
            public Position initialPosition;
            public RoverInstruction[] instructions;
            public Position ExpectedFinalPosition;

            public RoverData(Position initialPosition,
            RoverInstruction[] instructions,
            Position ExpectedFinalPosition)
            {
                this.initialPosition = initialPosition;
                this.instructions = instructions;
                this.ExpectedFinalPosition = ExpectedFinalPosition;
            }
        }

        private class SimulationData
        {
            public Position simulationBoundary;
            public List<RoverData> roverList;

            public SimulationData(Position simulationBoundary,
            List<RoverData> roverList)
            {
                this.simulationBoundary = simulationBoundary;
                this.roverList = roverList;
            }
        }

        /**
         * Get simulation details is the best solution to the problem of a test that is data complex
         * To keep the test relatively light and controllable while allowing for relatively complex
         * data interactions. In this case to run a simulation takes a fair amount of data
         * there is no good way to pass this as in line data but having it as a massive list without
         * using in line data is a good way to ensure that they are annoying to understand when they break
         * this way the user will know which instruction and output set broke and so where to begin debugging
         */

        private SimulationData GetSimulationDetails(int entry)
        {
            var roverSet1 = new List<RoverData>()
            {
                new RoverData(
                        new Position(2,0,Direction.North),
                        new RoverInstruction[] { RoverInstruction.Move, RoverInstruction.Move, RoverInstruction .Left, RoverInstruction .Move},
                        new Position(1,2,Direction.West)
                    ),
                new RoverData(
                        new Position(0,0,Direction.East),
                        new RoverInstruction[] { RoverInstruction.Left, RoverInstruction.Move, RoverInstruction .Right, RoverInstruction .Move},
                        new Position(1,1,Direction.East)
                    )
            };
            var boundryPosition = new Position(2, 2);

            var roverSetList = new List<SimulationData>()
            {
                new SimulationData(boundryPosition , roverSet1)
            };

            return roverSetList[entry];
        }

        [Theory]
        [InlineData(0)]

        //TODO: Find a better way to check the results of running a simulation
        public void Simulation_Runs_details_Correctly(int simIndex)
        {
            var simulationDetails = GetSimulationDetails(simIndex);

            var testSimulation = new DefaultSimulation(simulationDetails.simulationBoundary);

            foreach (var RoverEntry in simulationDetails.roverList)
            {
                testSimulation.addRover(RoverEntry.initialPosition, RoverEntry.instructions);
            }

            var results = testSimulation.runSimulation();

            var comparedResultList = results.Select((result, index) =>
            {
                var expectedPosition = simulationDetails.roverList[index].ExpectedFinalPosition;
                return (expectedPosition.X == result.X && expectedPosition.Y == result.Y, index);
            });

            foreach (var (resultValue, index) in comparedResultList)
            {
                Assert.True(resultValue, $"There was an issue with Simulation no. {simIndex}. On rover {index}");
            }
        }
    }
}