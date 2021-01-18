namespace MarsRoverChallenge.Plateau
{
    public interface IPlateau
    {
        public Position boundary { get; set; }

        public bool PositionIsWithinBounds(Position intendedPosition);
    }
}