using Api.Client.MyAnimeList.Entity.Enums;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot
{
    public class MangaUpdate
    {
        public MangaUserStatus? Status { get; set; }
        [JsonProperty("is_rereading")]
        public bool? IsRereading { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        public int? Score { get; set; }
        [JsonProperty("num_volumes_read")]
        public int? NumVolumesRead { get; set; }
        [JsonProperty("num_chapters_read")]
        public int? NumChaptersRead { get; set; }
        public int? Priority { get; set; }
        [JsonProperty("num_times_reread")]
        public int? NumTimesReread { get; set; }
        [JsonProperty("reread_value")]
        public int? RereadValue { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();
        public string? Comments { get; set; }
    }
}