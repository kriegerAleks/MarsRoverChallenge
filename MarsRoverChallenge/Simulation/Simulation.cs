using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge
{
    class Simulation
    {
        private Plateau.DefaultPlateau p;
        public Simulation(int gridX, int gridY)
        {
            p = new Plateau.DefaultPlateau(gridX, gridY);
        }
    }
}
