using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Deathroll
{
    internal class Controller
    {
        Calc calc;
        private int initPlayers, initNumber;
        private List<string> playerNames;

        public void InitializeGame()
        {
            initPlayers = -1;
            do
            {
                Welcome();
                Console.Write("Please enter the number of participants: ");
                initPlayers = IntFormatted(Console.ReadLine());
            } while (initPlayers == -1);

            playerNames = new List<string>();
            for (int i = 0; i < initPlayers; i++)
            {
                Console.Write($" - Name of participant {i + 1}: ");
                string name = Console.ReadLine();
                if (name == null || name == string.Empty)
                    name = $"Participant {i + 1}";
                playerNames.Add(name);
            }

            initNumber = -1;
            do
            {
                Welcome();
                ShowPlayersInit();
                Console.Write("\nPlease enter your starting number here: ");
                initNumber = IntFormatted(Console.ReadLine());
            } while (initNumber == -1);

            //Console.WriteLine("Which mode do you wish to play?");
            //Console.WriteLine("a) Single round - A single round for a single bet");
            //Console.WriteLine("b) Elimination - Continue until only one remains");

            calc = new Calc(initNumber, playerNames);
            PressEnterToContinue();
        }

        public void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Deathroll!");
            Console.WriteLine("Whatever you bet, the dice will decide who comes out on top.");
            Console.WriteLine("The rules are simple: The first to roll 0 loses.\n");
        }
        public void ShowPlayersInit()
        {
            Console.WriteLine($"Please enter the number of participants: {initPlayers}");
            for (int i = 0; i < playerNames.Count; i++)
            {
                Console.WriteLine($" - Name of participant {i + 1}: {playerNames[i]}");
            }
        }



        // Add commentary-like phrases depending on how the number changes?
        public void RunGame()
        {
            calc.ResetGame();
            InitializeRound();
            do
            {
                calc.PlayRound();
                Console.Write($" {calc.PlayersRemaining[calc.CurrentPlayer]} rolled ");
                for (int i = 0; i < 3; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    Console.Write(".");
                }
                if (calc.CurrentNumber == 0)
                {
                    Console.WriteLine($" {calc.CurrentNumber}!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($" {calc.PlayersRemaining[calc.CurrentPlayer]} has lost!");
                    EliminatePlayer();
                }
                else if (calc.CurrentNumber == 1)
                {
                    Console.Write($" {calc.CurrentNumber}..!");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write($" {calc.CurrentNumber}.");
                    Console.ReadLine();
                }
            } while (calc.PlayersRemaining.Count > 1);

            Console.WriteLine($"\n{calc.PlayersRemaining[0]} has won Deathroll!");
            System.Threading.Thread.Sleep(2000);
        }

        public void EliminatePlayer()
        {
            calc.EliminateCurrentPlayer();
            calc.ResetNumber();
            if (calc.PlayersRemaining.Count > 1)
            {
                PressEnterToContinue();
                InitializeRound();
            }
        }

        public void InitializeRound()
        {
            Console.Clear();
            Console.WriteLine($"Deathrolling from {calc.InitialNumber}, with {calc.PlayersRemaining.Count} out of {calc.PlayersNames.Count} participants remaining.");
        }



        public int EndGame()
        {
            int decision;
            do
            {
                Console.Clear();
                Console.WriteLine($"The Deathroll has spoken, and the winner is...");
                Console.WriteLine($"... {calc.PlayersRemaining[0]}!!");
                Console.WriteLine($"\nPress 1 to continue this Deathroll.");
                Console.WriteLine($"Press 2 to Deathroll with new settings.");
                Console.WriteLine($"Press 3 to stop Deathrolling.");
                if (int.TryParse(Console.ReadLine(), out decision) && decision > 0 && decision < 4)
                {
                    return decision;
                }
                else decision = -1;
            } while (decision == -1);
            return 0;
        }



        public int IntFormatted(string stringInput)
        {
            int formatInput;
            if (int.TryParse(stringInput, out formatInput) && formatInput > 1) { }
            else
            {
                formatInput = -1;
                InputInvalid(stringInput);
            }
            return formatInput;
        }

        public void InputInvalid(string stringInput)
        {
            Console.Write($"{stringInput} is not valid input, press Enter to try again. ");
            Console.ReadLine();
        }

        public void PressEnterToContinue()
        {
            Console.Write("\nPress Enter to continue. ");
            Console.ReadLine();
        }
    }
}
