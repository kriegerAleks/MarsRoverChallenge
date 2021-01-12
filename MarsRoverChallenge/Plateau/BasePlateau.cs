namespace MarsRoverChallenge.Plateau
{
    public abstract class BasePlateau
    {
        public Position boundary;

        abstract public bool positionIsWithinBounds(Position intendedPosition);
    }
}