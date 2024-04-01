using FootballRanking;
namespace Football_Ranking_Facts
{
    public class FootballMatchFacts
    {
        [Fact]
        public void UpdatePoints()
        {
            FootballTeam teamA = new("FCSB");
            FootballTeam teamB = new("Dinamo");
            teamA.AddPoints(2);
            teamB.AddPoints(3);
            FootballMatch footballMatch = new(teamA, teamB, 2 , 1);
            footballMatch.UpdatePoints();
            Assert.True(teamB.IsPointsLessThan(teamA));
        }
    }
}
