namespace Api.Client.MyAnimeList.Entity.Base.SubElements
{
    public class AlternativeTitles
    {
        public IEnumerable<string>? Synonyms { get; set; }
        public string? En { get; set; }
        public string? Ja { get; set; }

        public AlternativeTitles(IEnumerable<string>? synonyms, string? en, string? ja)
        {
            Synonyms = synonyms;
            En = en;
            Ja = ja;
        }
    }
}