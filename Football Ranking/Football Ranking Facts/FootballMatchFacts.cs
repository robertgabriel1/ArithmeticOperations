using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballMatchFacts
    {
        [Fact]
        public void CheckTeamPresence_BothTeamsPresent_ShouldReturnTrue()
        {
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new FootballTeam("Dinamo");
            FootballTeam[] teams = { teamA, teamB };
            FootballMatch footballMatch = new FootballMatch(teamA, teamB);
            bool result = footballMatch.CheckTeamPresence(teams);
            Assert.True(result);
        }

        [Fact]
        public void CheckTeamPresence_OneTeamMissing_ShouldReturnFalse()
        {
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new FootballTeam("Dinamo");
            FootballTeam[] teams = { teamA };
            FootballMatch footballMatch = new FootballMatch(teamA, teamB);
            bool result = footballMatch.CheckTeamPresence(teams);
            Assert.False(result);
        }
    }
}
