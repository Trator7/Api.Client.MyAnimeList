namespace Api.Client.MyAnimeList.Entity.AnimeRankingSubElements
{
    public class Ranking
    {
        public int Rank { get; set; }
        public int? PreviousRank { get; set; }

        public Ranking(int rank, int? previousRank)
        {
            Rank = rank;
            PreviousRank = previousRank;
        }
    }
}
