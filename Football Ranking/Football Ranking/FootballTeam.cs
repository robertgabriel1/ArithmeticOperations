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

        public bool IsNameEqual(string teamName)
        {
           return name == teamName;
        }

        public bool IsPointsLessThan(FootballTeam nextTeam)
        {
            return points < nextTeam.points;
        }

        public bool HasEqualPoints(int teamPoints)
        {
            return points == teamPoints;
        }
    }
}