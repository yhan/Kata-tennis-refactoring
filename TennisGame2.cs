namespace Tennis
{
    using System.Collections.Generic;

    public static class PlayerExtensions
    {
        public static bool Lead(this Player player, Player player2)
        {
            return player.Score > player2.Score && player.Score < 4;
        }

        public static bool Won(this Player player1, Player player2)
        {
            return player1.Score - player2.Score >= 2;
        }
    }

    public class TennisGame2 : ITennisGame
    {
        private readonly Player _player1;

        private readonly Player _player2;

        public TennisGame2(string player1Name, string player2Name) : this(new Player(player1Name), new Player(player2Name))
        {
        }

        public TennisGame2(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        private readonly Dictionary<int, string> _scoreTranslation = new Dictionary<int, string>
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };

        public string GetScore()
        {
            if (ScoresAreEqual())
            {
                return _scoreTranslation[_player1.Score] + "-All";
            }

            if (IsDeuce())
            {
                return "Deuce";
            }

            if (IsRegular())
            {
                return _scoreTranslation[_player1.Score] + "-" + _scoreTranslation[_player2.Score];
            }

            var leader = GetLeader();

            if (HasWon())
            {
                return $"Win for {leader}";
            }

            return $"Advantage {leader}";
        }

        private bool ScoresAreEqual()
        {
            return _player1.Score == _player2.Score && _player1.Score < 3;
        }

        private bool IsDeuce()
        {
            return _player1.Score == _player2.Score && _player1.Score > 2;
        }

        private bool IsRegular()
        {
            return _player1.Lead(_player2) || _player2.Lead(_player1);
        }

        private bool HasWon()
        {
            return _player1.Won(_player2) || _player2.Won(_player1);
        }

        public void WonPoint(string player)
        {
            if (player == _player1.Name)
            {
                _player1.Score++;
            }
            else
            {
                _player2.Score++;
            }
        }

        private string GetLeader()
        {
            if (_player1.Score > _player2.Score)
            {
                return _player1.Name;
            }

            return _player2.Name;
        }
    }
}