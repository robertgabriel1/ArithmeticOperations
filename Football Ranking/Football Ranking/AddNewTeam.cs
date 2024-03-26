namespace FootballRanking
{
    public class FootballArray
    {
        private readonly CreateFootballTeam[] teams;
        private int count;
        public FootballArray(CreateFootballTeam[] teams)
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
    }
}