namespace FootballRanking
{
    public class Ranking
    {
        private readonly FootballTeam[] teams;
        private int count;
        public Ranking(FootballTeam[] teams)
        {
            this.teams = teams;
            count = 0;
        }

        public void AddTeam(FootballTeam team)
        {
            if (count < teams.Length)
            {
                teams[count] = team;
                count++;
            }
            else
            {
                throw new InvalidOperationException("Array is full.");
            }
        }

        public void SortTeams()
        {
            Sort sort = new();
            sort.SortByPoints(teams);
        }

        public FootballTeam GetTeamFromPosition(int position)
        {
            if (position > 0 && position < count)
            {
                return teams[position - 1];
            }

            throw new InvalidOperationException($"There is no team at that place.");
        }

        public int GetTeamPosition(string teamName)
        {
            for (int i = 0; i < count; i++)
            {
                if (teams[i].TeamName() == teamName)
                {
                    return i + 1;
                }
            }

            throw new InvalidOperationException($"There is no team named {teamName}.");
        }

        public void FootballMatch(FootballTeam homeTeam, FootballTeam awayTeam, int goalsHomeTeam, int goalsAwayTeam)
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

            if (!homeTeamExists || !awayTeamExists)
            {
                throw new InvalidOperationException("One or both teams are not present in the ranking.");
            }

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