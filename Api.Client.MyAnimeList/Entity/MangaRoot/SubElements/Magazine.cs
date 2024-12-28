namespace Api.Client.MyAnimeList.Entity.MangaRoot.SubElements
{
    public class Magazine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Magazine(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
