namespace MarsRoverChallenge.Plateau
{
    public interface BasePlateau
    {
        public Position boundary { get; set; }

        public bool positionIsWithinBounds(Position intendedPosition);
    }
}