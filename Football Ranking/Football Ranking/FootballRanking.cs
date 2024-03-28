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
            if (position > 0 && position <= count)
            {
                return teams[position - 1];
            }

            throw new InvalidOperationException($"There is no team at that place.");
        }

        public int GetTeamPosition(string teamName)
        {
            for (int i = 0; i < count; i++)
            {
                if (teams[i].IsNameEqual(teamName))
                {
                    return i + 1;
                }
            }

            throw new InvalidOperationException($"There is no team named {teamName}.");
        }

        public void UpdatePointsAfterMatch(FootballTeam homeTeam, FootballTeam awayTeam, int goalsHomeTeam, int goalsAwayTeam)
        {
            FootballMatch check = new FootballMatch(homeTeam, awayTeam);
            if (!check.CheckTeamPresence(teams))
            {
                throw new InvalidOperationException("One or both teams are not present in the ranking.");
            }

            check.UpdatePoints(goalsHomeTeam, goalsAwayTeam);
        }
    }
}