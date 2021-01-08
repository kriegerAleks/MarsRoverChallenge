using MarsRoverChallenge.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Plateau
{
     struct RoverEntry
    {
        public BaseRover rover { get; }
        public Position currentPosition { get; set; }
        public RoverInstruction[] instructions { get; }

        public RoverEntry(BaseRover rover , Position currentPosition, RoverInstruction[] instructions)
        {
            this.rover = rover;
            this.currentPosition = currentPosition;
            this.instructions = instructions;
        }

        public void Deconstruct(out BaseRover rover, out Position currentPosition, out RoverInstruction[] instructions)
        {
            rover = this.rover;
            currentPosition = this.currentPosition;
            instructions = this.instructions;
        }
    }
}
