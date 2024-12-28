using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Base
{
    public class Username
    {
        [JsonProperty("id")]
        int Id { get; set; }
        [JsonProperty("name")]
        string Name { get; set; }
        [JsonProperty("forum_title")]
        string? ForumTitle { get; set; }
        [JsonProperty("forum_avator")]
        string? ForumAvatar { get; set; }

        public Username(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonConstructor]
        public Username(int id, string name, string? forumTitle, string? forumAvatar)
        {
            Id = id;
            Name = name;
            ForumTitle = forumTitle;
            ForumAvatar = forumAvatar;
        }
    }
}
