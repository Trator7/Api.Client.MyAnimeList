using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity.Enums;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.MangaRoot.SubElements
{
    public class MyListStatusManga : MyListStatusBase
    {
        [JsonProperty("num_volumes_read")]
        public int? NumVolumesRead { get; set; }
        [JsonProperty("num_chapters_read")]
        public int? NumChaptersRead { get; set; }
        [JsonProperty("is_rereading")]
        public bool? IsRereading { get; set; }
        [JsonProperty("num_times_reread")]
        public int? NumTimesReread { get; set; }
        [JsonProperty("reread_value")]
        public int? RereadValue { get; set; }

        public MyListStatusManga(AnimeUserStatus status, int score, int? numEpisodesWatched, int? numVolumesRead, int? numChaptersRead, bool? isRewatching, bool? isRereading, DateTime? startDate, DateTime? finishDate, int priority, int? numTimesRewatched, int? numTimesReread, int? rewatchValue, int? rereadValue, IEnumerable<string> tags, string comments, DateTime? updatedAt)
            : base(status, score, startDate, finishDate, priority, tags, comments, updatedAt)
        {
            NumVolumesRead = numVolumesRead;
            NumChaptersRead = numChaptersRead;
            IsRereading = isRereading;
            NumTimesReread = numTimesReread;
            RereadValue = rereadValue;
        }
    }
}
