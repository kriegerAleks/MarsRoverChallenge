namespace MarsRoverChallenge.Plateau
{
    public class DefaultPlateau : IPlateau
    {
        public Position boundary { get; set; }
        public DefaultPlateau(Position boooundary)
        {
            this.boundary = boooundary;
        }

        public  bool PositionIsWithinBounds(Position intendedPosition)
        {
            bool xOutsideBounds = intendedPosition.X > boundary.X || intendedPosition.X < 0;
            bool yOutsideBounds = intendedPosition.Y > boundary.Y || intendedPosition.Y < 0;

            return !(xOutsideBounds || yOutsideBounds);
        }
    }
}