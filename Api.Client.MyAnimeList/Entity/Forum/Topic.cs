using Api.Client.MyAnimeList.Entity.Base;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class Topic
    {
        public int Id { get; set; }
        public string? Titles { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("created_by")]
        public Username CreatedBy { get; set; }
        [JsonProperty("number_of_posts")]
        public int NumberOfPosts { get; set; }
        [JsonProperty("last_post_created_at")]
        public DateTime LastPostCreatedAt { get; set; }
        [JsonProperty("last_post_created_by")]
        public Username LastPostCreatedBy { get; set; }
        public bool IsLocked { get; set; }

        public Topic(int id, string? titles, DateTime createdAt, Username createdBy, int numberOfPosts, DateTime lastPostCreatedAt, Username lastPostCreatedBy, bool isLocked)
        {
            Id = id;
            Titles = titles;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            NumberOfPosts = numberOfPosts;
            LastPostCreatedAt = lastPostCreatedAt;
            LastPostCreatedBy = lastPostCreatedBy;
            IsLocked = isLocked;
        }
    }
}