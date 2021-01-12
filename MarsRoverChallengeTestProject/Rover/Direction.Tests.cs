using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MarsRoverChallenge.Rover;

namespace MarsRoverChallengeTestProject.Rover
{
    public class DirectionTests
    {
        [Theory]
        [InlineData(Direction.North, 'N')]
        [InlineData(Direction.South, 'S')]
        [InlineData(Direction.East, 'E')]
        [InlineData(Direction.West, 'W')]
        public void convertFromDirection_PrintsProperly(Direction direction , char ExpectedResult)
        {
            char TestResult = Directions.convertFromDirection(direction);

            Assert.True(TestResult == ExpectedResult);
        }

        [Theory]
        [InlineData(Direction.North, 'N')]
        [InlineData(Direction.South, 'S')]
        [InlineData(Direction.East, 'E')]
        [InlineData(Direction.West, 'W')]
        public void convertToDirection_ReturnsDirection_WhenValidValue(Direction ExpectedDirection , char toBeConvertedToDirection)
        {
            Direction TestDirection = Directions.convertToDirection(toBeConvertedToDirection);

            Assert.True(TestDirection == ExpectedDirection);
        }

        [Fact]
        public void convertToDirection_ThrowsError_WhenInvalidValue()
        {
            Direction emptyDirection;
            Exception caughtException = null;
            try 
            {
                emptyDirection = Directions.convertToDirection('X');
            }
            catch (Exception cException)
            {
                caughtException = cException;
            }

            Assert.NotNull(caughtException.Message);
        }

    }
}
