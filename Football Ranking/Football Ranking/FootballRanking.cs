namespace FootballRanking
{
    public class FootballRankingArray
    {
        private readonly CreateFootballTeam[] teams;
        private int count;
        public FootballRankingArray(CreateFootballTeam[] teams)
        {
            this.teams = teams;
            count = 0;
        }

        public void AddTeam(CreateFootballTeam team)
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

        public CreateFootballTeam GetPosition(int position)
        {
            if (position >= 0 && position < count)
            {
                return teams[position];
            }

            throw new InvalidOperationException($"There is no team at that place.");
        }
    }
}