using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    internal class Player
    {
        public int TotalScore { get; private set; }
        public int BallsFaced { get; private set; }

        public void ScoreRuns(int runs)
        {
            TotalScore += runs;
            BallsFaced++;
        }
    }
}
