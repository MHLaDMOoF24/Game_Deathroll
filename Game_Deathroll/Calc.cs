using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Deathroll
{
    internal class Calc
    {
        public Calc(int number, List<string> names)
        {
            this._initialNumber = number;
            this._currentNumber = number;
            this._playersNames = names;
            this._playersRemaining = names;
            this._currentPlayer = names.Count;
        }

        private Random _random = new Random();
        private int _initialNumber;
        public int InitialNumber { get { return _initialNumber; } }
        private int _currentNumber;
        public int CurrentNumber { get { return _currentNumber; } }
        private List<string> _playersNames;
        public List<string> PlayersNames { get { return _playersNames; } }
        private List<string> _playersRemaining;
        public List<string> PlayersRemaining {  get { return _playersRemaining; } }
        private int _currentPlayer;
        public int CurrentPlayer { get { return _currentPlayer; } }



        public void PlayRound()
        {
            SetCurrentPlayer();
            Roll();
        }

        public void Roll()
        {
            _currentNumber = _random.Next(_currentNumber);
            //return _currentNumber;
        }

        public void SetCurrentPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer >= _playersRemaining.Count)
                _currentPlayer = 0;
            else if (_currentPlayer < 0)
                _currentPlayer = _playersRemaining.Count - _currentPlayer;
        }

        public void EliminateCurrentPlayer()
        {
            _playersRemaining.RemoveAt(CurrentPlayer);
            _currentPlayer--;
        }

        public void ResetNumber()
        {
            _currentNumber = _initialNumber;
        }
    }
}
