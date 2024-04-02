using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballRankingFacts
    {
        [Fact]
        public void AddTeamInArray_WhenArrayIsEmpty_ShouldAddTeam()
        {
            Ranking footballArray = new();
            FootballTeam team = new("FCSB");
            footballArray.AddTeam(team);
            Assert.Equal(team, footballArray.GetTeamFromPosition(1));
        }

        [Fact]
        public void AddInArray_WhenArrayIsNotFull_ShouldAddTeam()
        {
            Ranking footballArray = new();
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new("Dinamo");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            Assert.Equal(teamA, footballArray.GetTeamFromPosition(1));
            Assert.Equal(teamB, footballArray.GetTeamFromPosition(2));
        }

        [Fact]
        public void GetTeamFromPosition_WhenPositionIsValid_ShouldReturnTeam()
        {
            Ranking footballArray = new();
            FootballTeam teamA = new("FCSB");
            teamA.AddPoints(1);
            FootballTeam teamB = new("Dinamo");
            teamB.AddPoints(3);
            FootballTeam teamC = new("Rapid");
            teamC.AddPoints(6);
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            footballArray.AddTeam(teamC);
            FootballTeam positionTeam = footballArray.GetTeamFromPosition(1);
            Assert.True(positionTeam == teamC);
            Assert.Throws<InvalidOperationException>(() => footballArray.GetTeamFromPosition(0));
        }

        [Fact]
        public void GetTeamPosition_WhenPositionIsValid_ShouldReturnTeam()
        {
            Ranking footballArray = new();
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new("Dinamo");
            FootballTeam teamC = new("Rapid");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            footballArray.AddTeam(teamC);
            int positionTeam = footballArray.GetTeamPosition(teamA);
            Assert.Equal(1, positionTeam);
        }

        [Fact]
        public void FootballMatch_WhenPositionIsValid_ShouldReturnTeam()
        {
            Ranking footballArray = new();
            FootballTeam teamA = new("FCSB");
            teamA.AddPoints(1);
            FootballTeam teamB = new("Dinamo");
            teamB.AddPoints(3);
            FootballTeam teamC = new("Rapid");
            teamC.AddPoints(6);
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            footballArray.AddTeam(teamC);
            footballArray.UpdatePointsAfterMatch(teamA, teamB, 2, 1);
            Assert.Equal(1, footballArray.GetTeamPosition(teamC));
            Assert.Equal(2, footballArray.GetTeamPosition(teamA));
            Assert.Equal(3, footballArray.GetTeamPosition(teamB));
        }
    }
}
