using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballRankingFacts
    {
        [Fact]
        public void AddTeamInArray_WhenArrayIsEmpty_ShouldAddTeam()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[3];
            FootballRankingArray footballArray = new(teams);
            CreateFootballTeam team = new("FCSB");
            footballArray.AddTeam(team);
            Assert.Equal(team, teams[0]);
        }

        [Fact]
        public void AddInArray_WhenArrayIsNotFull_ShouldAddTeam()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[3];
            FootballRankingArray footballArray = new(teams);
            CreateFootballTeam teamA = new("FCSB");
            CreateFootballTeam teamB = new("Dinamo");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            Assert.Equal(teamA, teams[0]);
            Assert.Equal(teamB, teams[1]);
        }

        [Fact]
        public void AddInArray_WhenArrayIsFull_ShouldThrowExceptionWhenArrayIsFull()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[2];
            FootballRankingArray footballArray = new(teams);
            CreateFootballTeam teamA = new("FCSB");
            CreateFootballTeam teamB = new("Dinamo");
            CreateFootballTeam teamC = new("Rapid");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);

            Assert.Throws<InvalidOperationException>(() => footballArray.AddTeam(teamC));
        }

        [Fact]
        public void GetPosition_WhenPositionIsValid_ShouldReturnTeam()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[4];
            FootballRankingArray footballArray = new(teams);
            CreateFootballTeam teamA = new("FCSB");
            teamA.AddPoints(1);
            footballArray.AddTeam(teamA);
            CreateFootballTeam teamB = new("Dinamo");
            teamB.AddPoints(3);
            footballArray.AddTeam(teamB);
            CreateFootballTeam teamC = new("Rapid");
            teamC.AddPoints(6);
            footballArray.AddTeam(teamC);
            CreateFootballTeam positionTeam = footballArray.GetPosition(0);
            Assert.Equal("FCSB", positionTeam.TeamName());
        }
    }
}