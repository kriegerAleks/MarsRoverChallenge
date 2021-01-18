using MarsRoverChallenge.Rover;

namespace MarsRoverChallenge.Simulation
{
    public struct RoverEntry
    {
        public RoverEntry(IRover rover, Position currentPosition, RoverInstruction[] instructions)
        {
            this.rover = rover;
            this.currentPosition = currentPosition;
            this.instructions = instructions;
        }

        public Position currentPosition { get; set; }
        public RoverInstruction[] instructions { get; }
        public IRover rover { get; }

        public void Deconstruct(out IRover rover, out Position currentPosition, out RoverInstruction[] instructions)
        {
            rover = this.rover;
            currentPosition = this.currentPosition;
            instructions = this.instructions;
        }
    }
}