namespace FootballRanking
{
    public class CreateFootballTeam
    {
        private readonly string name;
        private int points;
        public CreateFootballTeam(string name)
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