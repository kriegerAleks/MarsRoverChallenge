namespace MarsRoverChallenge.Plateau
{
    internal class DefaultPlateau : BasePlateau
    {
        public DefaultPlateau(Position boooundary)
        {
            this.boundary = boooundary;
        }

        public override bool positionIsWithinBounds(Position intendedPosition)
        {
            bool xOutsideBounds = intendedPosition.X > boundary.X || intendedPosition.X < 0;
            bool yOutsideBounds = intendedPosition.Y > boundary.Y || intendedPosition.Y < 0;

            return !(xOutsideBounds || yOutsideBounds);
        }
    }
}