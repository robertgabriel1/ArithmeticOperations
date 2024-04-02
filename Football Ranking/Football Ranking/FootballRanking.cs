namespace FootballRanking
{
    public class Ranking
    {
        private FootballTeam[] teams;
        public Ranking()
        {
            teams = new FootballTeam[0];
        }

        public void AddTeam(FootballTeam team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = team;
            SortTeams();
        }

        private void SortTeams()
        {
            Sort sort = new();
            sort.SortByPoints(teams);
        }

        public FootballTeam GetTeamFromPosition(int position)
        {
            if (position > 0 && position <= teams.Length)
            {
                return teams[position - 1];
            }

            throw new InvalidOperationException($"There is no team at that place.");
        }

        public int GetTeamPosition(FootballTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void UpdatePointsAfterMatch(FootballMatch match, FootballTeam homeTeam, FootballTeam awayTeam)
        {
            if (GetTeamPosition(homeTeam) == -1 || GetTeamPosition(awayTeam) == -1)
            {
                throw new InvalidOperationException($"One or both teams are not present in the ranking.");
            }

            match.UpdatePoints();
            SortTeams();
        }
    }
}