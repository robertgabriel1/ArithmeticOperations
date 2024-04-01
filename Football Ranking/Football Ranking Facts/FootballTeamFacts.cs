using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballTeamFacts
    {
        [Fact]
        public void AddPoints_ShouldIncreaseTeamPoints()
        {
            FootballTeam teamA = new("FCSB");
            teamA.AddPoints(1);
            FootballTeam teamB = new("Dinamo");
            teamB.AddPoints(2);
            Assert.True(teamA.IsPointsLessThan(teamB));
        }

        [Fact]
        public void IsPointsLessThan_ShouldReturnTrue()
        {
            FootballTeam teamA = new("Team 1");
            FootballTeam teamB = new("Team 2");
            teamA.AddPoints(5);
            teamB.AddPoints(10);
            Assert.True(teamA.IsPointsLessThan(teamB));
        }
    }
}