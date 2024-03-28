using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballRankingFacts
    {
        [Fact]
        public void AddTeamInArray_WhenArrayIsEmpty_ShouldAddTeam()
        {
            FootballTeam[] teams = new FootballTeam[3];
            Ranking footballArray = new(teams);
            FootballTeam team = new("FCSB");
            footballArray.AddTeam(team);
            Assert.Equal(team, teams[0]);
        }

        [Fact]
        public void AddInArray_WhenArrayIsNotFull_ShouldAddTeam()
        {
            FootballTeam[] teams = new FootballTeam[3];
            Ranking footballArray = new(teams);
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new("Dinamo");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            Assert.Equal(teamA, teams[0]);
            Assert.Equal(teamB, teams[1]);
        }

        [Fact]
        public void AddInArray_WhenArrayIsFull_ShouldThrowExceptionWhenArrayIsFull()
        {
            FootballTeam[] teams = new FootballTeam[2];
            Ranking footballArray = new(teams);
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new("Dinamo");
            FootballTeam teamC = new("Rapid");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            Assert.Throws<InvalidOperationException>(() => footballArray.AddTeam(teamC));
        }

        [Fact]
        public void GetTeamFromPosition_WhenPositionIsValid_ShouldReturnTeam()
        {
            FootballTeam[] teams = new FootballTeam[3];
            Ranking footballArray = new(teams);
            FootballTeam teamA = new("FCSB");
            teamA.AddPoints(1);
            FootballTeam teamB = new("Dinamo");
            teamB.AddPoints(3);
            FootballTeam teamC = new("Rapid");
            teamC.AddPoints(6);
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            footballArray.AddTeam(teamC);
            footballArray.SortTeams();
            FootballTeam positionTeam = footballArray.GetTeamFromPosition(1);
            Assert.True(positionTeam.IsNameEqual("Rapid"));
            Assert.Throws<InvalidOperationException>(() => footballArray.GetTeamFromPosition(0));
        }

        [Fact]
        public void GetTeamPosition_WhenPositionIsValid_ShouldReturnTeam()
        {
            FootballTeam[] teams = new FootballTeam[3];
            Ranking footballArray = new(teams);
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new("Dinamo");
            FootballTeam teamC = new("Rapid");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            footballArray.AddTeam(teamC);
            int positionTeam = footballArray.GetTeamPosition("FCSB");
            Assert.Equal(1, positionTeam);
        }

        [Fact]
        public void FootballMatch_WhenPositionIsValid_ShouldReturnTeam()
        {
            FootballTeam[] teams = new FootballTeam[3];
            Ranking footballArray = new(teams);
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
            footballArray.SortTeams();
            Assert.Equal(1, footballArray.GetTeamPosition("Rapid"));
            Assert.Equal(2, footballArray.GetTeamPosition("FCSB"));
            Assert.Equal(3, footballArray.GetTeamPosition("Dinamo"));
        }
    }
}
