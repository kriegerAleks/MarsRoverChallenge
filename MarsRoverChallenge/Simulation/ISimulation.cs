using MarsRoverChallenge.Plateau;
using MarsRoverChallenge.Rover;
using System.Collections.Generic;

namespace MarsRoverChallenge.Simulation
{
    public interface ISimulation
    {
        DefaultPlateau plateau { get; set; }
        List<RoverEntry> roverList { get; set; }

        abstract void addRover(Position initialPosition, RoverInstruction[] instructions);

        abstract List<Position> runSimulation();
    }
}