using MarsRoverChallenge.Rover;

namespace MarsRoverChallenge.Simulation
{
    internal struct RoverEntry
    {
        public RoverEntry(BaseRover rover, Position currentPosition, RoverInstruction[] instructions)
        {
            this.rover = rover;
            this.currentPosition = currentPosition;
            this.instructions = instructions;
        }

        public Position currentPosition { get; set; }
        public RoverInstruction[] instructions { get; }
        public BaseRover rover { get; }
        public void Deconstruct(out BaseRover rover, out Position currentPosition, out RoverInstruction[] instructions)
        {
            rover = this.rover;
            currentPosition = this.currentPosition;
            instructions = this.instructions;
        }
    }
}