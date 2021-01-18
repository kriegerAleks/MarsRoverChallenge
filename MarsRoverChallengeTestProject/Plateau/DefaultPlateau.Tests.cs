using MarsRoverChallenge;
using MarsRoverChallenge.Plateau;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoverChallengeTestProject.Plateau
{
   public class DefaultPlateauUnitTests
    {
        
        [Fact]
        public void Constructor_GivenBoundryPosition_CanBeRetrieved()
        {
            var boundaryPosition = new Position(0,0);
            var plateau = new DefaultPlateau(boundaryPosition);
            Assert.Equal(boundaryPosition, plateau.boundary);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        // specifically testing one bounded axis at a time
        public void positionIsWithinBounds_TrueOnBorders(int x , int y)
        {
            var plateau = createPlateau();
            var TestingPosition = new Position(x, y);

            var isWithinBounds = plateau.PositionIsWithinBounds(TestingPosition);

            Assert.True(isWithinBounds);
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        [InlineData(3, 1)]
        [InlineData(1, 3)]
        // specifically testing one bounded axis at a time
        public void positionIsWithinBounds_FalseOnOutsideBorders(int x ,int y)
        {
            var plateau = createPlateau();
            var TestingPosition = new Position(x, y);

            var isWithinBounds = plateau.PositionIsWithinBounds(TestingPosition);

            Assert.False(isWithinBounds);
        }

        private DefaultPlateau createPlateau()
        {
            Position BoundryPosition = new Position(2, 2);
            return new DefaultPlateau(BoundryPosition);
        }

        
    }
}
