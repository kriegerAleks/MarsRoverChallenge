using MarsRoverChallenge;
using MarsRoverChallenge.Rover;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoverChallengeTestProject.Rover
{
    public class DefaultRoverTests
    {
    
        private DefaultRover GetDefaultRover() { return new DefaultRover(); }

        private Position GetInitialPosition(Direction direction)
        {
            return new Position(0, 0, direction);
        }

        [Fact]
        public void isValidPosition_ReturnsTrue_WhenValid() {

            var testRover = GetDefaultRover();
            var isValidPosition = true;

            var isValidPositionForRover = testRover.isValidPosition(isValidPosition);

            Assert.True(isValidPositionForRover);
        }

        [Fact]
        public void isValidPosition_ReturnsFalse_WhenInvalid()
        {
            var testRover = GetDefaultRover();
            var isInvalidPosition = false;

            var isValidPositionForRover = testRover.isValidPosition(isInvalidPosition);

            Assert.False(isValidPositionForRover);
        }

        [Theory]
        [InlineData(Direction.North,0,1)]
        [InlineData(Direction.East,1,0)]
        [InlineData(Direction.South,0,-1)]
        [InlineData(Direction.West,-1,0)]
        public void move_returnsAPositionOnTheCurrentHeading_WhenMovingForward(Direction facing , int expectedX , int expectedY)
        {
            const RoverInstruction MOVE = RoverInstruction.Move;

            var initialPosition = GetInitialPosition(facing);
            var testRover = GetDefaultRover();

            var testPosition = testRover.move(initialPosition, MOVE );

            Assert.True(testPosition.facing == facing, "Position should remain the same after movement");
            Assert.True(testPosition.X == expectedX, $"when {facing}: X {expectedX} == actualX {testPosition.X}");
            Assert.True(testPosition.Y == expectedY, $"when {facing}: Y {expectedY} == actualY {testPosition.Y}");
        }

        [Theory]
        [InlineData(Direction.North, RoverInstruction.Left , Direction.West)]
        [InlineData(Direction.East, RoverInstruction.Left , Direction.North)]
        [InlineData(Direction.South, RoverInstruction.Left , Direction.East)]
        [InlineData(Direction.West, RoverInstruction.Left , Direction.South)]
        [InlineData(Direction.West, RoverInstruction.Right, Direction.North)]
        [InlineData(Direction.South, RoverInstruction.Right, Direction.West)]
        [InlineData(Direction.East, RoverInstruction.Right, Direction.South)]
        [InlineData(Direction.North, RoverInstruction.Right, Direction.East)]

        public void move_CanTurnProperly_WhenTurningLeftAndRight(Direction currentDirection ,RoverInstruction turnDirection , Direction expectedFacing)
        {
            var testRover = GetDefaultRover();
            var testPosition = GetInitialPosition( currentDirection);

            Position movementResult = testRover.move(testPosition, turnDirection);

            Assert.True(movementResult.facing == expectedFacing); ;

        }

    }
}
