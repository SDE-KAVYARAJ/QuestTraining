using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonePaperGame
{
    internal class Program
    {
        class Game
        {
            private int playerScore = 0;
            private int computerScore = 0;
            private readonly Random random = new Random();

            public void Start()
            {
                Console.WriteLine("Welcome to the Stone-Paper-Scissors game!");
                Console.WriteLine("Type 'stone', 'paper', or 'scissors' to play. Type 'exit' to quit.");

                while (playerScore < 10 && computerScore < 10)
                {
                    Console.Write("\nEnter your choice: ");
                    string playerChoice = Console.ReadLine().ToLower();

                    if (playerChoice == "exit")
                    {
                        Console.WriteLine("Game exited.");
                        break;
                    }

                    if (playerChoice != "stone" && playerChoice != "paper" && playerChoice != "scissors")
                    {
                        Console.WriteLine("Invalid input, please enter 'stone', 'paper', or 'scissors'.");
                        continue;
                    }

                    string computerChoice = GetComputerChoice();
                    Console.WriteLine($"Computer chose: {computerChoice}");

                    DetermineWinner(playerChoice, computerChoice);
                    Console.WriteLine($"Score - Player: {playerScore} | Computer: {computerScore}");
                }

                Console.WriteLine(playerScore == 10 ? "\nPlayer won the game!" : "\nComputer won the game!");
            }

            private string GetComputerChoice()
            {
                int choice = random.Next(1, 4); 
                if (choice == 1)
                {
                    return "stone";
                }
                else if (choice == 2)
                {
                    return "paper";
                }
                else
                {
                    return "scissors";
                }
            }
            private void DetermineWinner(string playerChoice, string computerChoice)
            {
                if (playerChoice == computerChoice)
                {
                    Console.WriteLine("It's a draw!");
                }
                else if ((playerChoice == "stone" && computerChoice == "scissors") ||
                         (playerChoice == "paper" && computerChoice == "stone") ||
                         (playerChoice == "scissors" && computerChoice == "paper"))
                {
                    Console.WriteLine("Player wins this round!");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Computer wins this round!");
                    computerScore++;
                }
            }
        }
        static void Main(string[] args)
        {
             Game game = new Game();
            game.Start();
        }
    }
}
