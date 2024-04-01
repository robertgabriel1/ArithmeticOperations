namespace FootballRanking
{
    public class Ranking
    {
        private FootballTeam[] teams;
        private int count;
        public Ranking()
        {
            teams = new FootballTeam[0];
            count = 0;
        }

        public void AddTeam(FootballTeam team)
        {
            Array.Resize(ref teams, count + 1);
            teams[count] = team;
            count++;
            SortTeams();
        }

        private void SortTeams()
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

        public int GetTeamPosition(FootballTeam teamName)
        {
            for (int i = 0; i < count; i++)
            {
                if (teams[i] == teamName)
                {
                    return i + 1;
                }
            }

            throw new InvalidOperationException($"There is no team named {teamName}.");
        }

        public void UpdatePointsAfterMatch(FootballMatch match, FootballTeam homeTeam, FootballTeam awayTeam)
        {
            if (!TeamExists(homeTeam) || !TeamExists(awayTeam))
            {
                throw new InvalidOperationException($"One or both teams are not present in the ranking.");
            }

            match.UpdatePoints();
            SortTeams();
        }

        private bool TeamExists(FootballTeam team)
        {
            foreach (FootballTeam currentTeam in teams)
            {
                if (currentTeam == team)
                {
                    return true;
                }
            }
            return false;
        }
    }
}