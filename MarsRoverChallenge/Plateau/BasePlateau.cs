namespace MarsRoverChallenge.Plateau
{
    internal abstract class BasePlateau
    {
        public Position boundary;

        abstract public bool positionIsWithinBounds(Position intendedPosition);
    }
}