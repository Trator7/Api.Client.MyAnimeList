using Api.Client.MyAnimeList.Entity.Enums;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements
{
    public class SeasonPeriod
    {
        public int Year { get; set; }
        public Season Season { get; set; }

        public SeasonPeriod(int year, Season season)
        {
            Year = year;
            Season = season;
        }
    }
}
