namespace FootballRanking
{
    public class FootballTeam
    {
        private readonly string name;
        private int points;
        public FootballTeam(string name)
        {
            this.name = name;
            this.points = 0;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }

        public bool IsPointsLessThan(FootballTeam nextTeam)
        {
            return points < nextTeam.points;
        }
    }
}