namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class TopicDetail
    {
        public string? Title { get; set; }
        public List<Post> Posts { get; set; }
        public List<Poll> Poll { get; set; }

        public TopicDetail(string title, List<Post>? posts, List<Poll>? poll)
        {
            Title = title;
            Posts = posts ?? new List<Post>();
            Poll = poll ?? new List<Poll>();
        }
    }
}