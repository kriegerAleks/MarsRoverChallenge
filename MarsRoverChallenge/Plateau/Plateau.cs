namespace MarsRoverChallenge.Plateau
{
    internal abstract class Plateau
    {
        public Position boundary;

        abstract public bool positionIsWithinBounds(Position intendedPosition);
    }
}