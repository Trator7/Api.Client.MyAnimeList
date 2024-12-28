namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool Close { get; set; }
        public List<ForumTopicPollOption> Options { get; set; }

        public Poll(int id, string question, bool close, List<ForumTopicPollOption> options)
        {
            Id = id;
            Question = question;
            Close = close;
            Options = options;
        }
    }
}
