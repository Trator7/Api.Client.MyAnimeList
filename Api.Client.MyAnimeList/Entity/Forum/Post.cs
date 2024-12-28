using Api.Client.MyAnimeList.Entity.Base;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class Post
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("created_by")]
        public Username CreatedBy { get; set; }
        public string Body { get; set; }
        public string Signature { get; set; }

        public Post(int id, int number, DateTime createdAt, Username createdBy, string body, string signature)
        {
            Id = id;
            Number = number;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            Body = body;
            Signature = signature;
        }
    }
}
