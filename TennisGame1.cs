namespace Tennis
{
    using System;
    using System.Media;

    class TennisGame1 : ITennisGame
    {
        private Int32 m_score1 = 0;

        private Int32 m_score2 = 0;

        private String player1Name;

        private String player2Name;

        private Player _player1;

        private Player _player2;

        public TennisGame1(String player1Name, String player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;

            _player1 = new Player(player1Name);
            _player2 = new Player(player1Name);
        }

        public void WonPoint(String playerName)
        {
            if (playerName == "player1")
            {
                m_score1 += 1;
            }
            else
            {
                m_score2 += 1;
            }
        }

        public String GetScore()
        {
            String score = string.Empty;
            Int32 tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                Int32 minusResult = m_score1 - m_score2;
                if (minusResult == 1)
                {
                    score = "Advantage player1";
                }
                else if (minusResult == -1)
                {
                    score = "Advantage player2";
                }
                else if (minusResult >= 2)
                {
                    score = "Win for player1";
                }
                else
                {
                    score = "Win for player2";
                }
            }
            else
            {
                for (Int32 i = 1; i < 3; i++)
                {
                    if (i == 1)
                    {
                        tempScore = m_score1;
                    }
                    else
                    {
                        score += "-";
                        tempScore = m_score2;
                    }

                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }

            return score;
        }
    }

    internal class Player
    {
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }
    }
}