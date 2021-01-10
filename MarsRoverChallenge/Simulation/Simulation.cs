using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverChallenge.Rover;
using MarsRoverChallenge.Plateau;
using System.Linq;

namespace MarsRoverChallenge.Simulation
{
    class DefaultSimulation
    {
        private DefaultPlateau plateau;
        private List<RoverEntry> roverList = new List<RoverEntry>();
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
            var( rover, currentPosition, insturctions ) = roverDetails;
            
            foreach (var instruction in insturctions)
            {
                var newPosition =  rover.move(currentPosition, instruction);
                var newPositionOnPlateau = plateau.positionIsWithinBounds(newPosition);
                var roverCanMoveToNewPosition = rover.isValidPosition(newPositionOnPlateau);
                if (roverCanMoveToNewPosition)
                {
                    currentPosition = newPosition;
                }
            }
            return currentPosition;
        }
    }
}
