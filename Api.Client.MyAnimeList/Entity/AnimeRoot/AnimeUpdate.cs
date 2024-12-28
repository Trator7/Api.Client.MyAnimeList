using Api.Client.MyAnimeList.Entity.Enums;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot
{
    public class AnimeUpdate
    {
        public AnimeUserStatus? Status { get; set; }
        [JsonProperty("is_rewatching")]
        public bool? IsRewatching { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        public int? Score { get; set; }
        [JsonProperty("num_episodes_watched")]
        public int? NumEpisodesWatched { get; set; }
        public int? Priority { get; set; }
        [JsonProperty("num_times_rewatched")]
        public int? NumTimesRewatched { get; set; }
        [JsonProperty("rewatch_value")]
        public int? RewatchValue { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();
        public string? Comments { get; set; }
    }
}