using Api.Client.MyAnimeList.Entity.AnimeRankingSubElements;
using Api.Client.MyAnimeList.Entity.Base;

namespace Api.Client.MyAnimeList.Entity
{
    public class AnimeMangaNode<T>
        where T : AnimeMangaBase
    {
        public T Node { get; set; }
        public Ranking? Ranking { get; set; }

        public AnimeMangaNode(T value, Ranking? ranking)
        {
            Node = value;
            Ranking = ranking;
        }
    }
}