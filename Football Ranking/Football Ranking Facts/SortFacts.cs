using FootballRanking;
namespace Football_Ranking_Facts
{
    public class SortFacts
    {
        [Fact]
        public void Sort_ShouldSortTeamsInDescendingOrder()
        {
            CreateFootballTeam teamA = new("Team A");
            teamA.AddPoints(3);
            CreateFootballTeam teamB = new("Team B");
            teamB.AddPoints(6);
            CreateFootballTeam teamC = new("Team C");
            teamC.AddPoints(1);
            CreateFootballTeam[] teams = { teamA, teamB, teamC };
            Sort sort = new Sort();
            sort.SortByPoints(teams);
            Assert.Equal(teamB, teams[0]);
            Assert.Equal(teamA, teams[1]);
            Assert.Equal(teamC, teams[2]);
        }
    }
}