namespace Api.Client.MyAnimeList.Entity.Forum
{
    public class ForumBoard
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<ForumBoard> SubBoards { get; set; }

        public ForumBoard(int id, string title, string? description, List<ForumBoard>? subBoards)
        {
            Id = id;
            Title = title;
            Description = description;
            SubBoards = subBoards ?? new List<ForumBoard>();
        }
    }
}