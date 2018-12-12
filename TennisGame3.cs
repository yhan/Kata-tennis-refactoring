namespace Tennis
{
    using System.Collections.Generic;

    public class TennisGame3 : ITennisGame
    {
        private readonly Dictionary<int, string> _scoreTranslation = new Dictionary<int, string>
                                                                         {
                                                                             [0] = "Love",
                                                                             [1] = "Fifteen",
                                                                             [2] = "Thirty",
                                                                             [3] = "Forty"
                                                                         };

        private readonly Player _player1;

        private readonly Player _player2;

        public TennisGame3(string player1Name, string player2Name)
            : this(new Player(player1Name), new Player(player2Name))
        {
        }

        public TennisGame3(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string GetScore()
        {
            if (IsRegular())
            {
                if (IsDraw())
                {
                    return _scoreTranslation[_player1.Score] + "-All";
                }

                return _scoreTranslation[_player1.Score] + "-" + _scoreTranslation[_player2.Score];
            }

            if (IsDeuce())
            {
                return "Deuce";
            }

            var leader = GetLeader();
            return HasAdvantage() ? "Advantage " + leader : "Win for " + leader;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
            {
                _player1.Score += 1;
            }
            else
            {
                _player2.Score += 1;
            }
        }

        private bool HasAdvantage()
        {
            return (_player1.Score - _player2.Score) * (_player1.Score - _player2.Score) == 1;
        }

        private bool IsDraw()
        {
            return _player1.Score == _player2.Score;
        }

        private string GetLeader()
        {
            return _player1.Score > _player2.Score ? _player1.Name : _player2.Name;
        }

        private bool IsDeuce()
        {
            return _player1.Score == _player2.Score;
        }

        private bool IsRegular()
        {
            return _player1.Score < 4 && _player2.Score < 4 && _player1.Score + _player2.Score < 6;
        }
    }
}