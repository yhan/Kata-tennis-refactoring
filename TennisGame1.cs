namespace Tennis
{
    using System.Collections.Generic;

    class TennisGame1 : ITennisGame
    {
        private readonly Player _player1;

        private readonly Player _player2;

        private readonly Dictionary<int, string> _scoreTranslation = new Dictionary<int, string>
                                                        {
                                                            [0] = "Love",
                                                            [1] = "Fifteen",
                                                            [2] = "Thirty",
                                                            [3] = "Forty"
                                                        };

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
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

        public string GetScore()
        {
            if (IsOnFinalPartofGame())
            {
                var leader = GetLeader();
                if (IsDeuce(leader))
                {
                    return "Deuce";
                }

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
            return _player1.Score >= 4 || _player2.Score >= 4 || _player1.Score == 3 && _player2.Score == 3;
        }

        private bool IsDraw()
        {
            return _player1.Score == _player2.Score && _player1.Score < 3;
        }

        private bool HasAdvantage()
        {
            int minusResult = _player1.Score - _player2.Score;
            return minusResult == 1 || minusResult == -1;
        }

        private string GetLeader()
        {
            int minusResult = _player1.Score - _player2.Score;
            if (minusResult >= 1)
            {
                return _player1.Name;
            }

            if (minusResult <= -1)
            {
                return _player2.Name;
            }

            return null;
        }
    }
}