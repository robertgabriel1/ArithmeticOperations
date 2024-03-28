using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballTeamFacts
    {
        [Fact]
        public void AddPoints_ShouldIncreaseTeamPoints()
        {
            FootballTeam team = new("FCSB");
            team.AddPoints(1);
            Assert.True(team.HasEqualPoints(1));
        }

        [Fact]
        public void AddPoints_ShouldAccumulateTeamPoints()
        {
            FootballTeam team = new("FCSB");
            team.AddPoints(3);
            team.AddPoints(1);
            team.AddPoints(3);
            Assert.True(team.HasEqualPoints(7));
        }

        [Fact]
        public void IsNameEqual_ShouldReturnCorrectName()
        {
            FootballTeam team = new("Dinamo");
            team.AddPoints(3);
            Assert.True(team.IsNameEqual("Dinamo"));
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