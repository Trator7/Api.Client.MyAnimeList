using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Base.SubElements
{
    public class Picture
    {
        public string? Large { get; set; }
        public string? Medium { get; set; }

        public Picture()
        {
        }

        [JsonConstructor]
        public Picture(string medium, string? large)
        {
            Medium = medium;
            Large = large;
        }
    }
}
