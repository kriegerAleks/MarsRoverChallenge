namespace MarsRoverChallenge.Plateau
{
    internal class DefaultPlateau : Plateau
    {
        public Position boundary { get; }

        public DefaultPlateau(Position boundary)
        {
            this.boundary = boundary;
        }

        public override bool positionIsWithinBounds(Position intendedPosition)
        {
            bool xOutsideBounds = intendedPosition.X > boundary.X || intendedPosition.X < 0;
            bool yOutsideBounds = intendedPosition.Y > boundary.Y || intendedPosition.Y < 0;

            return !(xOutsideBounds || yOutsideBounds);
        }
    }
}