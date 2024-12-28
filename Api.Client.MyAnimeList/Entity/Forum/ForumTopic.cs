using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class ForumTopic
    {
        public string Title { get; set; }
        [JsonProperty("boards")]
        List<ForumBoard> Boards { get; set; }

        public ForumTopic(string title, List<ForumBoard> boards)
        {
            Title = title;
            Boards = boards;
        }
    }
}