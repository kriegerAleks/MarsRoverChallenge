using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Plateau
{
    abstract class Plateau
    {
        public Position boundry;
        abstract public bool positionIsWithinBounds(Position intendedPosition);
    }
}
