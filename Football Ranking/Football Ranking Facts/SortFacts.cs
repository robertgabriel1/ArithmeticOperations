using FootballRanking;
namespace Football_Ranking_Facts
{
    public class SortFacts
    {
        [Fact]
        public void Sort_ShouldSortTeamsInDescendingOrder()
        {
            FootballTeam teamA = new("FCSB");
            teamA.AddPoints(3);
            FootballTeam teamB = new("Dinamo");
            teamB.AddPoints(6);
            FootballTeam teamC = new("Rapid");
            teamC.AddPoints(1);
            FootballTeam[] teams = { teamA, teamB, teamC };
            Sort sort = new();
            sort.SortByPoints(teams);
            Assert.Equal(teamB, teams[0]);
            Assert.Equal(teamA, teams[1]);
            Assert.Equal(teamC, teams[2]);
            teamA.AddPoints(3);
        }
    }
}