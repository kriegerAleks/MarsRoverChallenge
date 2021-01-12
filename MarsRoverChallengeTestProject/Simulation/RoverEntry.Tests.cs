using MarsRoverChallenge;
using MarsRoverChallenge.Rover;
using MarsRoverChallenge.Simulation;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallengeTestProject.Simulation
{
    public class RoverEntryTests
    {

        private static BaseRover DefaultRover = new DefaultRover();
        private static Direction DefaultFacing = Direction.East;
        private static Position DefaultPosition = new Position(0, 1,DefaultFacing);

        private RoverEntry GetRoverEntry(RoverInstruction[] instructions)
        {
            return new RoverEntry(DefaultRover, DefaultPosition, instructions);
        }

        [Fact]
        public  void GetRoverEntry_SavesValuesProperly()
        {
            var testInstructions = new RoverInstruction[] {RoverInstruction.Left, RoverInstruction.Move };
            
            var testRover = GetRoverEntry(testInstructions);

            Assert.Equal(testRover.instructions, testInstructions);
            Assert.Equal(testRover.rover, DefaultRover);
            Assert.Equal(testRover.currentPosition, DefaultPosition);
        }

        [Fact]
        public void RoverEntry_DeconstructsProperly()
        {
            var testInstructions = new RoverInstruction[] {RoverInstruction.Left, RoverInstruction.Move };

            var testRover = GetRoverEntry(testInstructions);

            var (rover, currentPosition, instructions) = testRover;

            Assert.Equal(instructions, testInstructions);
            Assert.Equal(rover, DefaultRover);
            Assert.Equal(currentPosition, DefaultPosition);
        }

    }
}
