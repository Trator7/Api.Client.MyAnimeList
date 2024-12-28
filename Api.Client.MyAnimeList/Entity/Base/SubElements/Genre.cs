namespace Api.Client.MyAnimeList.Entity.Base.SubElements
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}