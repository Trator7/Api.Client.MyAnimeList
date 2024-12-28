namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class ForumCategories
    {
        public List<ForumTopic> Categories { get; set; }

        public ForumCategories(List<ForumTopic> categories)
        {
            Categories = categories;
        }
    }
}
