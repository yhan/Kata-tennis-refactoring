using System.Collections.Generic;

namespace Tennis
{
    using System;

    class TennisGame1 : ITennisGame
    {
        Dictionary<int, string> _scoreTranslation = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };
        private readonly Player _player1;
        private readonly Player _player2;

        public TennisGame1(String player1Name, String player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public void WonPoint(String playerName)
        {
            if (playerName == "player1")
            {
                _player1.Score += 1;
            }
            else
            {
                _player2.Score += 1;
            }
        }

        public String GetScore()
        {

            if (IsOnFinalPartofGame())
            {
                var leader = GetLeader();
                if (IsDeuce(leader))
                    return "Deuce";

                return HasAdvantage() ? $"Advantage {leader}" : $"Win for {leader}";
            }

            if (IsDraw())
            {
                return $"{_scoreTranslation[_player1.Score]}-All";
            }

            return $"{_scoreTranslation[_player1.Score]}-{_scoreTranslation[_player2.Score]}";
        }

        private static bool IsDeuce(string leader)
        {
            return leader == null;
        }

        private bool IsOnFinalPartofGame()
        {
            return _player1.Score >= 4 || _player2.Score >= 4 || (_player1.Score == 3 && _player2.Score == 3);
        }

        private bool IsDraw()
        {
            return _player1.Score == _player2.Score && _player1.Score < 3;
        }

        private bool HasAdvantage()
        {
            Int32 minusResult = _player1.Score - _player2.Score;
            return minusResult == 1 || minusResult == -1;
        }

        private string GetLeader()
        {
            int minusResult = _player1.Score - _player2.Score;
            if (minusResult >= 1)
                return _player1.Name;
            if (minusResult <= -1)
                return _player2.Name;

            return null;
        }
    }
}