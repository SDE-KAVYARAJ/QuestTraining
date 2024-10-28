using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    internal class Game
    {
        private Player player;
        private Randomizer randomizer;
        private int over;

        public Game()
        {
            player = new Player();
            randomizer = new Randomizer();
            over = 1;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Cricket Game!");
            Console.WriteLine("Score runs by hitting 1, 2, 3, or 6!\n");

            while (true)
            {
                Console.WriteLine($"\nOver: {over}");

                for (int ball = 1; ball <= 6; ball++)
                {
                    Console.Write("Enter runs scored (1, 2, 3, or 6): ");
                    int runs;

                    // Validates user input
                    while (!int.TryParse(Console.ReadLine(), out runs) || (runs != 1 && runs != 2 && runs != 3 && runs != 6))
                    {
                        Console.WriteLine("Invalid input. Please enter 1, 2, 3, or 6.");
                    }

                    // Player scores runs
                    player.ScoreRuns(runs);
                    Console.WriteLine($"You scored {runs} runs. Total Score: {player.TotalScore}");

                    // Generate random number for out condition
                    int computerGuess = randomizer.GenerateRandomNumber();
                    if (computerGuess == runs)
                    {
                        Console.WriteLine("You're out!");
                        Console.WriteLine($"Final Score: {player.TotalScore} runs in {player.BallsFaced} balls.");
                        return; // End the game if player is out
                    }
                }

                // Move to the next over after every 6 balls
                over++;
            }
        }
    }
}
