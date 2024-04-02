namespace FootballRanking
{
    public class Ranking
    {
        private FootballTeam[] teams;
        public Ranking()
        {
            teams = new FootballTeam[0];
        }

        public void AddTeam(FootballTeam team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
            SortTeams();
        }

        private void SortTeams()
        {
            int teamsNumber = teams.Length;
            bool swapped = true;
            while (swapped)
            {
               swapped = false;
               for (int i = 0; i < teamsNumber - 1; i++)
               {
                 if (teams[i].IsPointsLessThan(teams[i + 1]))
                  {
                        (teams[i + 1], teams[i]) = (teams[i], teams[i + 1]);
                        swapped = true;
                  }
               }
            }
        }

        public FootballTeam GetTeamFromPosition(int position)
        {
            if (position > 0 && position <= teams.Length)
            {
                return teams[position - 1];
            }

            throw new InvalidOperationException($"There is no team at that place.");
        }

        public int GetTeamPosition(FootballTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void UpdatePointsAfterMatch(FootballTeam homeTeam, FootballTeam awayTeam, int goalsHomeTeam, int goalsAwayTeam)
        {
            if (GetTeamPosition(homeTeam) == -1 || GetTeamPosition(awayTeam) == -1)
            {
                throw new InvalidOperationException($"One or both teams are not present in the ranking.");
            }

            int pointsForVictory = 3;
            if (goalsHomeTeam > goalsAwayTeam)
            {
                homeTeam.AddPoints(pointsForVictory);
            }
            else if (goalsHomeTeam < goalsAwayTeam)
            {
                awayTeam.AddPoints(pointsForVictory);
            }
            else
            {
                awayTeam.AddPoints(1);
                homeTeam.AddPoints(1);
            }

            SortTeams();
        }
    }
}