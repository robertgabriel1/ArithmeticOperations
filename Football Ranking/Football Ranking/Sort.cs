namespace FootballRanking
{
    public class Sort
    {
        private FootballTeam[] teams;

        public void SortByPoints(FootballTeam[] teams)
        {
            this.teams = teams;
            int teamsNumber = teams.Length;
            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < teamsNumber - 1; i++)
                {
                    if (teams[i].IsPointsLessThan(teams[i + 1]))
                    {
                        Swap(i, i + 1);
                        swapped = true;
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            FootballTeam temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }
    }
}
