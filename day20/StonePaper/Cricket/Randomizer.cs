using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    internal class Randomizer
    {
        private static readonly Random random = new Random();

        public int GenerateRandomNumber()
        {
            return random.Next(1, 7); // Generates a random number between 1 and 6
        }
    }
}
