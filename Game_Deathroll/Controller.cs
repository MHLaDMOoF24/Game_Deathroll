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
                ShowPlayers();
                Console.Write("Please enter your starting number here: ");
                initNumber = IntFormatted(Console.ReadLine());
            } while (initNumber == -1);

            calc = new Calc(initNumber, playerNames);
            //Console.WriteLine("Which mode do you wish to play?");
            //Console.WriteLine("a) Single round - A single round for a single bet");
            //Console.WriteLine("b) Elimination - Continue until only one remains");

            // Add options at end: "Repeat game or new game?"

            // Add commentary-like phrases depending on how the number changes?
        }

        public void RunGame()
        {

        }





        public void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Deathroll!");
            Console.WriteLine("Whatever you bet, the dice will decide who comes out on top.");
            Console.WriteLine("The rules are simple: The first to roll 0 loses.\n");
        }
        public void ShowPlayers()
        {
            Console.WriteLine($"Please enter the number of participants: {initPlayers}");
            for (int i = 0; i < playerNames.Count; i++)
            {
                Console.WriteLine($" - Name of participant {i + 1}: {playerNames[i]}");
            }
        }

        public int IntFormatted(string stringInput)
        {
            int formatInput;
            if (int.TryParse(stringInput, out formatInput) && formatInput > 0) { }
            else
            {
                formatInput = -1;
                InputInvalid(stringInput);
            }
            return formatInput;
        }

        public void InputInvalid(string stringInput)
        {
            Console.WriteLine($"{stringInput} is not valid input, press Enter to try again.");
            Console.ReadLine();
        }


    }
}
