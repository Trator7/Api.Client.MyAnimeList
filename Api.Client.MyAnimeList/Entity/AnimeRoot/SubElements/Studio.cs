namespace Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Studio(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
