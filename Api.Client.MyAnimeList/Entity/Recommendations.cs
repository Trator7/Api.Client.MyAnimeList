using Api.Client.MyAnimeList.Entity.Base;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity
{
    public class Recommendations
    {
        public AnimeMangaBase Node { get; set; }
        [JsonProperty("num_recommendations")]
        public int NumRecommendations { get; set; }

        public Recommendations(AnimeMangaBase value, int numRecommendations)
        {
            Node = value;
            NumRecommendations = numRecommendations;
        }
    }
}