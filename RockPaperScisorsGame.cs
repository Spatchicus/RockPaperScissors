using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RockPaperScissorsGame
    {
        private Random rng;
        private int wins;
        private int losses;
        private int ties;
        private List<GameOptions> gameOptions;

        public void SetUpGameOptions()
        {
            List<GameOptions> gameOptions = new List<GameOptions>();
            foreach (GameOptions option in Enum.GetValues(typeof(GameOptions))){
                gameOptions.Add(option);
            }

            this.gameOptions = gameOptions;
        }


        public RockPaperScissorsGame()
        {
            rng = new Random();
            SetUpGameOptions();
        }

        public void Play()
        {
            GameOptions userChoice = PromptUser();
            GameOptions computerChoice;
            int score;

            while(userChoice != GameOptions.Quit)
            {
                computerChoice = ComputerChoice();
                score = GetScore(computerChoice, userChoice);
                log($"The computer chose: {computerChoice} ");
                ReturnScore();

                userChoice = PromptUser();
                if (userChoice == GameOptions.Reset)
                {
                    wins = 0; losses = 0; ties = 0;
                    userChoice = PromptUser();
                }
            }
            ReturnScore();
            log("Press enter to continue...");
            Console.ReadLine();
        }

        private int GetScore(GameOptions computer, GameOptions user)
        {
            if(computer == user)
            {
                ties++;
                return ties;
            }
            else if(computer == GameOptions.Rock && user == GameOptions.Paper || 
                    computer == GameOptions.Scissors && user == GameOptions.Rock || 
                    computer == GameOptions.Paper && user == GameOptions.Scissors)
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

        private GameOptions ComputerChoice()
        {
            int computer = rng.Next((int)GameOptions.Rock, (int)GameOptions.Scissors + 1);
            GameOptions option = (GameOptions)computer;
            return option;
        }

        private GameOptions PromptUser()
        {
                     
            log("Welcome to Rock, Paper or Scissors\n");
            log("Please select one of the options: ");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (GameOptions option in gameOptions)
            {
                log($"{Enum.GetName(typeof(GameOptions),option)} ({(int)option})");
            }
            Console.ResetColor();

            string userChoice = Console.ReadLine();
            GameOptions useroption;

            if (Enum.TryParse(userChoice, out useroption))
            {
                log($"You chose {useroption}");
                if(useroption == GameOptions.Quit)
                {
                    log("Thanks for playing!");
                }
            }
            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                log("That is an invalid choice:");
            }

            //Console.ForegroundColor = ConsoleColor.Magenta;
            //switch (Char.ToLowerInvariant(userChoice[0]))
            //{
            //    case 'r':
            //        log("\nYou chose Rock");
            //        break;
            //    case 'p':
            //        log("You chose Paper");
            //        break;
            //    case 's':
            //        log("You chose Scissors");
            //        break;
            //    case 'q':
            //        log("Thanks for playing!");
            //        break;
            //    default:
            //        Console.ResetColor();
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        log("That is an invalid choice:");
            //        break;
            //}
            //Console.ResetColor();
            return useroption;
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

        public void log(object input)
        {
            Console.WriteLine(input.ToString());
        }

        private enum GameOptions
        {
            Rock = 1,
            Paper,
            Scissors,
            Quit,
            Reset
        }
    }


    

}
