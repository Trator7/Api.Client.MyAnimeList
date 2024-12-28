using Api.Client.MyAnimeList.Entity.Enums;
using Api.Client.MyAnimeList.Utilities;
using Newtonsoft.Json;
using System.Text;

namespace Api.Client.MyAnimeList
{
    public class RequestBodySchema
    {
        [JsonProperty("status")]
        public string? UserStatusTxt { get { return AnimeUserStatus.ToString() ?? MangaUserStatus.ToString() ?? "";  } }
        [JsonIgnore]
        public AnimeUserStatus? AnimeUserStatus { get; set; }
        [JsonIgnore]
        public MangaUserStatus? MangaUserStatus { get; set; }
        [JsonProperty("is_rewatching")]
        public bool? IsRewatching { get; set; }
        public int? Score { get; set; }
        [JsonProperty("num_watched_episodes")]
        public int? NumWatchedEpisodes { get; set; }
        public int? Priority { get; set; }
        [JsonProperty("num_times_rewatched")]
        public int? NumTimesRewatched { get; set; }
        [JsonProperty("rewatch_value")]
        public int? RewatchValue { get; set; }
        public string? Tags { get; set; }
        public string? Comments { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (AnimeUserStatus != null)
            {
                sb.Append($"&status={ApiCallHelper.AnimeUserStatusToString(AnimeUserStatus.Value)}");
            }
            if (MangaUserStatus != null)
            {
                sb.Append($"&status={ApiCallHelper.MangaUserStatusToString(MangaUserStatus.Value)}");
            }
            if (IsRewatching != null)
            {
                sb.Append($"&is_rewatching={IsRewatching}");
            }
            if (Score != null)
            {
                sb.Append($"&score={Score}");
            }
            if (NumWatchedEpisodes != null)
            {
                sb.Append($"&num_watched_episodes={NumWatchedEpisodes}");
            }
            if (Priority != null)
            {
                sb.Append($"&priority={Priority}");
            }
            if (NumTimesRewatched != null)
            {
                sb.Append($"&num_times_rewatched={NumTimesRewatched}");
            }
            if (RewatchValue != null)
            {
                sb.Append($"&rewatch_value={RewatchValue}");
            }
            if (Tags != null)
            {
                sb.Append($"&tags={Tags}");
            }
            if (Comments != null)
            {
                sb.Append($"&comments={Comments}");
            }

            return sb.ToString()[1..];
        }
    }
}
