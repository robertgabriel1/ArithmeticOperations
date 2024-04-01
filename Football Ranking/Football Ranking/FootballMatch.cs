namespace FootballRanking
{
    public class FootballMatch
    {
        private readonly FootballTeam homeTeam;
        private readonly FootballTeam awayTeam;
        private readonly int goalsHomeTeam;
        private readonly int goalsAwayTeam;
        public FootballMatch(FootballTeam homeTeam, FootballTeam awayTeam, int goalsHomeTeam, int goalsAwayTeam)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.goalsHomeTeam = goalsHomeTeam;
            this.goalsAwayTeam = goalsAwayTeam;
        }

        public void UpdatePoints()
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
