using Api.Client.MyAnimeList.Entity.Base;

namespace Api.Client.MyAnimeList.Entity.MangaRoot.SubElements
{
    public class Author
    {
        public PersonBase Node { get; set; }
        public string Role { get; set; }

        public Author(PersonBase value, string role)
        {
            Node = value;
            Role = role;
        }
    }
}
