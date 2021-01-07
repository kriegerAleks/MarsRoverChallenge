
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Rover
{
  

    abstract class BaseRover
        /**
         *  This is meant to represent the base classes for any future rover implementations
         */
    {

        /**
         *  Move is to be used to return the future position in space that the rover intends to occupy
         *  if it obeys the given command. This is here because different kinds of rovers could potentially 
         *  move in different ways
        */
        public abstract Position move(Position currentPosition, RoverInstruction command );

        /**
         * Because in reality a rover is responsible for ensuring it does not fall off a cliff this is 
         * the logical place to put the logic for the check. After all, not all rovers have wheels
         */
        public abstract bool isValidPosition(Position intendedPosition, Position boundPosition );
            
        

    }
}
