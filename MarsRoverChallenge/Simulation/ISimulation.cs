using MarsRoverChallenge.Plateau;
using MarsRoverChallenge.Rover;
using System.Collections.Generic;

namespace MarsRoverChallenge.Simulation
{
    public interface ISimulation
    {
        public DefaultPlateau plateau { get; set; }
        public List<RoverEntry> roverList { get; set; }

        public void AddRover(Position initialPosition, RoverInstruction[] instructions);

        public List<Position> RunSimulation();
    }
}