namespace Api.Client.MyAnimeList.Entity.MangaRoot.SubElements
{
    public class MangaMagazineRelationEdge
    {
        public Magazine Node { get; set; }
        public string Role { get; set; }

        public MangaMagazineRelationEdge(Magazine value, string role)
        {
            Node = value;
            Role = role;
        }
    }
}
