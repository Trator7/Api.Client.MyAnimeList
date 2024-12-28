using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity.Enums;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements
{
    public class MyListStatusAnime : MyListStatusBase
    {
        [JsonProperty("num_episodes_watched")]
        public int? NumEpisodesWatched { get; set; }
        [JsonProperty("is_rewatching")]
        public bool? IsRewatching { get; set; }
        [JsonProperty("num_times_rewatched")]
        public int? NumTimesRewatched { get; set; }
        [JsonProperty("rewatch_value")]
        public int? RewatchValue { get; set; }

        public MyListStatusAnime(AnimeUserStatus status, int score, int? numEpisodesWatched, int? numVolumesRead, int? numChaptersRead, bool? isRewatching, bool? isRereading, DateTime? startDate, DateTime? finishDate, int priority, int? numTimesRewatched, int? numTimesReread, int? rewatchValue, int? rereadValue, IEnumerable<string> tags, string comments, DateTime? updatedAt)
            : base(status, score, startDate, finishDate, priority, tags, comments, updatedAt)
        {
            NumEpisodesWatched = numEpisodesWatched;
            IsRewatching = isRewatching;
            NumTimesRewatched = numTimesRewatched;
            RewatchValue = rewatchValue;
        }
    }
}
