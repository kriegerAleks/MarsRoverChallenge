using MarsRoverChallenge.Plateau;
using MarsRoverChallenge.Rover;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverChallenge.Simulation
{
    public class DefaultSimulation : ISimulation
    {
        public DefaultPlateau plateau { get; set; }

        public List<RoverEntry> roverList { get; set; } = new List<RoverEntry>();

        public DefaultSimulation(int gridX, int gridY)
        {
            plateau = new DefaultPlateau(new Position(gridX, gridY));
        }

        public DefaultSimulation(Position boundaryPoint)
        {
            plateau = new DefaultPlateau(boundaryPoint);
        }

        public void addRover(Position initalPosition, RoverInstruction[] instructions)
        {
            roverList.Add(new RoverEntry(new DefaultRover(), initalPosition, instructions));
        }

        /**
         * run the actual simulation and return the list of the final positions
         */

        public List<Position> runSimulation()
        {
            return roverList.Select(rover => simulateRoverMovements(rover)).ToList();
        }

        private Position simulateRoverMovements(RoverEntry roverDetails)
        {
            // TODO: Separate out current and start positions
            var (rover, currentPosition, insturctions) = roverDetails;

            foreach (var instruction in insturctions)
            {
                var newPosition = rover.Move(currentPosition, instruction);
                var newPositionOnPlateau = plateau.PositionIsWithinBounds(newPosition);
                var roverCanMoveToNewPosition = rover.IsValidPosition(newPositionOnPlateau);
                if (roverCanMoveToNewPosition)
                {
                    currentPosition = newPosition;
                }
            }
            return currentPosition;
        }
    }
}