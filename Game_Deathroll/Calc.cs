using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Deathroll
{
    internal class Calc
    {
        public Calc(int initialNumber, List<string> names)
        {
            this._currentNumber = initialNumber;
            playerNames = names;
            playerRemaining = names;
        }

        private Random _random;
        private int _currentNumber;
        public int CurrentNumber {  get { return _currentNumber; } }
        public List<string> playerNames;
        public List<string> playerRemaining;

        public int Roll()
        {
            _currentNumber = _random.Next(_currentNumber);
            return _currentNumber;
        }

    }
}
