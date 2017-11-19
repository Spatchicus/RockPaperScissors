using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RockPaperScisorsGame
    {
        private Random rng;
        private int wins;
        private int losses;
        private int ties;

        
        public List<string> SetUpGameOptions(List<string> list)
        {
            list.Add("Rock");
            list.Add("Paper");
            list.Add("Scisors");
            list.Add("Quit");
            return list;
        }


        public RockPaperScisorsGame()
        {
            rng = new Random();
        }

        public void Play()
        {
            string userChoice = PromptUser();
            string computerChoice;
            int score;

            while(userChoice.ToLower() != "quit")
            {
                computerChoice = ComputerChoice();
                score = GetScore(computerChoice, userChoice);
                log($"The computer chose: {computerChoice} ");
                ReturnScore();

                userChoice = PromptUser();
                
            }
            ReturnScore();
        }

        private int GetScore(string computer, string user)
        {
            if(computer.ToLower() == user.ToLower())
            {
                ties++;
                return ties;
            }
            else if(computer.ToLower() == "rock" && user.ToLower() == "paper" || computer.ToLower() == "scisors" && user.ToLower() == "rock" || computer.ToLower() == "paper" && user.ToLower() == "scisors")
            {
                wins++;
                return wins;
            }
            else
            {
                losses++;
                return losses;
            }
        }

        private string ComputerChoice()
        {
            int computer = rng.Next(1, 4);

            if (computer == 1)
            {
                return "Rock";
            }
            else if (computer == 2)
            {
                return "Paper";
            }
            else
            {
                return "Scisors";
            }
        }

        private string PromptUser()
        {
            List<string> gameOptions = new List<string>();
            SetUpGameOptions(gameOptions);
            log("Welcome to Rock, Paper or Scisors");
            log("\nPlease select one of the options: ");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string opt in gameOptions)
            {
                log(opt);
            }
            Console.ResetColor();

            string userChoice = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            switch (userChoice.ToLower())
            {
                case "rock":
                    log("\nYou chose Rock");
                    break;
                case "paper":
                    log("You chose Paper");
                    break;
                case "scisors":
                    log("You chose Scisors");
                    break;
                case "quit":
                    log("Thanks for playing!");
                    break;
                default:
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    log("That is an invalid choice:");
                    break;
            }
            Console.ResetColor();
            return userChoice;
        }

        private void ReturnScore()
        {
            log("\nThe Current Score is\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            log($"Wins: {wins}");
            Console.ForegroundColor = ConsoleColor.Red;
            log($"Loses: {losses}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            log($"Ties: {ties}\n");
            Console.ResetColor();
        }

        public void log(string input)
        {
            Console.WriteLine(input);
        }
    }

}
