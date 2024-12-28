namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class ForumTopicPollOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Votes { get; set; }

        public ForumTopicPollOption(int id, string text, int votes)
        {
            Id = id;
            Text = text;
            Votes = votes;
        }
    }
}
