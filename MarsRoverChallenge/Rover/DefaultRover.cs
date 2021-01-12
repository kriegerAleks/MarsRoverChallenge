namespace MarsRoverChallenge.Rover
{
    public class DefaultRover : BaseRover
    {
        /*
         This returns the position the rover would be moving to
         */

        public override bool isValidPosition(bool isInsideBounds)
        {
            return isInsideBounds;
        }

        public override Position move(Position currentPosition, RoverInstruction command)
        {
            switch (command)
            {
                case RoverInstruction.Left:
                case RoverInstruction.Right:
                    return turn(currentPosition, command);

                default:
                    return moveForward(currentPosition);
            }
        }

        private Position moveForward(Position currentPosition)
        {
            var (X, Y, facing) = currentPosition;

            switch (currentPosition.facing)
            {
                case Direction.North:
                    Y += 1;
                    break;

                case Direction.East:
                    X += 1;
                    break;

                case Direction.South:
                    Y -= 1;
                    break;

                case Direction.West:
                    X -= 1;
                    break;
            }

            return new Position(X, Y, facing);
        }

        private Position turn(Position currentPosition, RoverInstruction turnDirection)
        {
            int facing = 0;
            switch (turnDirection)
            {
                case RoverInstruction.Left:
                    facing = (int)currentPosition.facing - 1;
                    break;

                case RoverInstruction.Right:
                    facing = (int)currentPosition.facing + 1;
                    break;
            }

            facing = facing < 0 ? 3 : facing;

            Direction newFacing = (Direction)(facing % 4);

            return new Position(currentPosition.X, currentPosition.Y, newFacing);
        }
    }
}