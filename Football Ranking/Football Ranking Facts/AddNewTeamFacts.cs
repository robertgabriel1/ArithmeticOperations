using FootballRanking;
namespace Football_Ranking_Facts
{
    public class AddNewTeamFacts
    {
        [Fact]
        public void AddTeamInArray_WhenArrayIsEmpty_ShouldAddTeam()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[3];
            FootballArray footballArray = new(teams);
            CreateFootballTeam team = new("FCSB");
            footballArray.AddTeam(team);
            Assert.Equal(team, teams[0]);
        }

        [Fact]
        public void AddInArray_WhenArrayIsNotFull_ShouldAddTeam()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[3];
            FootballArray footballArray = new(teams);
            CreateFootballTeam teamA = new("FCSB");
            CreateFootballTeam teamB = new("Dinamo");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);
            Assert.Equal(teamA, teams[0]);
            Assert.Equal(teamB, teams[1]);
        }

        [Fact]
        public void AddInArray_WhenArrayIsFull_ShouldNotAddTeam()
        {
            CreateFootballTeam[] teams = new CreateFootballTeam[2];
            FootballArray footballArray = new(teams);
            CreateFootballTeam teamA = new("FCSB");
            CreateFootballTeam teamB = new("Dinamo");
            CreateFootballTeam teamC = new("Rapid");
            footballArray.AddTeam(teamA);
            footballArray.AddTeam(teamB);

            Assert.Throws<InvalidOperationException>(() => footballArray.AddTeam(teamC));
        }
    }
}