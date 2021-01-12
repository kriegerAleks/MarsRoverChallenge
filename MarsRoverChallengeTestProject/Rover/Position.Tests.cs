using Xunit;
using MarsRoverChallenge.Rover;
using MarsRoverChallenge;

namespace MarsRoverChallengeTestProject.Rover
{
    public class PositionTests
    {

        private const int X = 0;
        private const int Y = 1;
        private Direction Facing = Direction.East;

        [Fact]
        public void Constructor__SavesXAndY__WhenNoFacingProvided()
        {

            Position newPosition = new Position(X, Y);

            Assert.True(newPosition.X == X);
            Assert.True(newPosition.Y == Y);
        }

        [Fact]
        public void Constructor__SavesValues_WhenFacingProvided()
        {
            Position testPosition = new Position(X, Y, Facing);

            Assert.True(testPosition.facing == Facing);

            Assert.True(testPosition.X == X);
            Assert.True(testPosition.Y == Y);
        }

        [Fact]
        public void Deconstruct_ReturnsValuesWhenAllAreSet()
        {
            Position testPosition = new Position(X, Y, Facing);

            (int x, int y, Direction facing) = testPosition;

            Assert.True(x == X);
            Assert.True(y == Y);

            Assert.True(Facing == facing);
        }

        [Fact]
        public void Deconstruct_CanReturnOnlyXAndY()
        {
            Position testPosition = new Position(X, Y, Facing);

            (int x, int y) = testPosition;
        }
    }
}
