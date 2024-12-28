using Api.Client.MyAnimeList.Entity.Enums;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Base
{
    public class MyListStatusBase
    {
        public AnimeUserStatus? Status { get; set; }
        public int Score { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("finish_date")]
        public DateTime? FinishDate { get; set; }
        public int Priority { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Comments { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public MyListStatusBase(AnimeUserStatus status, int score, DateTime? startDate, DateTime? finishDate, int priority, IEnumerable<string> tags, string comments, DateTime? updatedAt)
        {
            Status = status;
            Score = score;
            StartDate = startDate;
            FinishDate = finishDate;
            Priority = priority;
            Tags = tags;
            Comments = comments;
            UpdatedAt = updatedAt;
        }
    }
}
