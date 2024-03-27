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

        public string TeamName()
        {
            return name;
        }

        public int TeamPoints()
        {
            return points;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }
    }
}