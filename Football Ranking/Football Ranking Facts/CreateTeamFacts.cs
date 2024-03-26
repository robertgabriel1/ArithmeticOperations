using FootballRanking;
namespace Football_Ranking_Facts
{
    public class CreateTeamFacts
    {
        [Fact]
        public void TeamPoints_ShouldIncreaseTeamPoints()
        {
            CreateFootballTeam team = new("FCSB");
            team.AddPoints(1);
            Assert.Equal(1, team.TeamPoints());
        }

        [Fact]
        public void TeamPoints_ShouldAccumulateTeamPoints()
        {
            CreateFootballTeam team = new("FCSB");
            team.AddPoints(3);
            team.AddPoints(1);
            team.AddPoints(3);
            Assert.Equal(7, team.TeamPoints());
        }

        [Fact]
        public void TeamName_ShouldReturnCorrectName()
        {
            CreateFootballTeam team = new("Dinamo");
            team.AddPoints(3);
            Assert.Equal("Dinamo", team.TeamName());
        }
    }
}