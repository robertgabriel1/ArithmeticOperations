namespace FootballRanking
{
    public class FootballMatch
    {
        private readonly FootballTeam homeTeam;
        private readonly FootballTeam awayTeam;
        public FootballMatch(FootballTeam homeTeam, FootballTeam awayTeam)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
        }

        public bool CheckTeamPresence(FootballTeam[] teams)
        {
            bool homeTeamExists = false;
            bool awayTeamExists = false;
            foreach (FootballTeam team in teams)
            {
                if (team == homeTeam)
                {
                    homeTeamExists = true;
                }
                else if (team == awayTeam)
                {
                    awayTeamExists = true;
                }
            }

            return homeTeamExists && awayTeamExists;
        }

        public void UpdatePoints(int goalsHomeTeam, int goalsAwayTeam)
        {
            int pointsForVictory = 3;
            if (goalsHomeTeam > goalsAwayTeam)
            {
                homeTeam.AddPoints(pointsForVictory);
            }
            else if (goalsHomeTeam < goalsAwayTeam)
            {
                awayTeam.AddPoints(pointsForVictory);
            }
            else
            {
                awayTeam.AddPoints(1);
                homeTeam.AddPoints(1);
            }
        }
    }
}
