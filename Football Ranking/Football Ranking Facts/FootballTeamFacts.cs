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
            Assert.Equal(1, team.TeamPoints());
        }

        [Fact]
        public void TeamPoints_ShouldAccumulateTeamPoints()
        {
            FootballTeam team = new("FCSB");
            team.AddPoints(3);
            team.AddPoints(1);
            team.AddPoints(3);
            Assert.Equal(7, team.TeamPoints());
        }

        [Fact]
        public void TeamName_ShouldReturnCorrectName()
        {
            FootballTeam team = new("Dinamo");
            team.AddPoints(3);
            Assert.Equal("Dinamo", team.TeamName());
        }
    }
}