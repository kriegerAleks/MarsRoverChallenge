namespace MarsRoverChallenge.Rover
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class Directions
    {
        /**
         * TODO:  There should be a better way to do this. I know that its possible
         * to make an enum class and that using that it is theoretically possible
         * to override the default conversion from / to strings and numbers
         */

        public static char convertFromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North: return 'N';
                case Direction.South: return 'S';
                case Direction.East: return 'E';
                default: return 'W';
            }
        }

        public static Direction convertToDirection(char stringDirection)
        {
            switch (stringDirection)
            {
                case 'N': return Direction.North;
                case 'S': return Direction.South;
                case 'E': return Direction.East;
                case 'W': return Direction.West;
                default:
                    throw new System.Exception("wrong symbol");
            }
        }
    }
}