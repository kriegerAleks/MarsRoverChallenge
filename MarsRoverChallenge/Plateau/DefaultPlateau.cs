using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverChallenge.Rover;

namespace MarsRoverChallenge.Plateau
{
    /**
     * strictly speaking this isnt neccessary
     */
    class DefaultPlateau
    {   
      public Position boundary { get; }

        private List<RoverEntry> roverList = new List<RoverEntry>();
        
       public DefaultPlateau(Position boundary)
        {
            this.boundary = boundary;
        }

        public void addRover(Position initalPosition, RoverInstruction[] instructions) {
            roverList.Add(new RoverEntry(new DefaultRover(),initalPosition, instructions));
        }
    }
}
