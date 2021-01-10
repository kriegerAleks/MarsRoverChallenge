using MarsRoverChallenge.Rover;

namespace MarsRoverChallenge
{
    public struct Position
    /**
     * I position denotes a current position on the grid. It represents a stationary position
     */
    {
        public Position(int x, int y, Direction facing = Direction.North)
        {
            X = x;
            Y = y;
            this.facing = facing;
        }

        public Direction facing { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        /**
         * can be nulled if not needed
         */

        public void Deconstruct(out int X, out int Y, out Direction facing)
        {
            X = this.X;
            Y = this.Y;
            facing = this.facing;
        }

        public override string ToString() => $"{X} {Y} {facing}";
    }
}