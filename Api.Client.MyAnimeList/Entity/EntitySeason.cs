using Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements;
using Api.Client.MyAnimeList.Entity.Base;

namespace Api.Client.MyAnimeList.Entity
{
    public class EntitySeason<T> : Entity<T>
    {
        public SeasonPeriod Season { get; set; }

        public EntitySeason(List<T> data, Paging paging, SeasonPeriod season) : base(data, paging)
        {
            Season = season;
        }
    }
}
