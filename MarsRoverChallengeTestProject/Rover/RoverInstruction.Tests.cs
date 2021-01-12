using MarsRoverChallenge.Rover;
using System;
using Xunit;

namespace MarsRoverChallengeTestProject.Rover
{
    public class RoverInstructionTests
    {
        [Theory]
        [InlineData('M',RoverInstruction.Move)]
        [InlineData('L',RoverInstruction.Left)]
        [InlineData('R',RoverInstruction.Right)]
        public void ConvertValueToInstruction_ConvertsToInstruction_WhenValidValueGiven(char valueToConvert, RoverInstruction expectedInstruction)
        {
            var conversionResult = RoverInstructions.ConvertValueToInstruction(valueToConvert);

            Assert.True(conversionResult == expectedInstruction);
        }

        [Fact]
        public void ConvertValueToInstruction_ThrowsError_WhenInvalidValueGiven()
        {
            Exception testException = null;

            try
            {
                var throwawayValue = RoverInstructions.ConvertValueToInstruction('S');
            }
            catch (Exception testE )
            {
                testException = testE;
            }

            Assert.NotNull(testException);
        }

    }
}
