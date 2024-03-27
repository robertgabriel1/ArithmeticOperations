using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballTeamFacts
    {
        [Fact]
        public void TeamPoints_ShouldIncreaseTeamPoints()
        {
            FootballTeam team = new("FCSB");
            team.AddPoints(1);
            Assert.True(team.HasEqualPoints(1));
        }

        [Fact]
        public void TeamPoints_ShouldAccumulateTeamPoints()
        {
            FootballTeam team = new("FCSB");
            team.AddPoints(3);
            team.AddPoints(1);
            team.AddPoints(3);
            Assert.True(team.HasEqualPoints(7));
        }

        [Fact]
        public void TeamName_ShouldReturnCorrectName()
        {
            FootballTeam team = new("Dinamo");
            team.AddPoints(3);
            Assert.True(team.IsNameEqual("Dinamo"));
        }
    }
}