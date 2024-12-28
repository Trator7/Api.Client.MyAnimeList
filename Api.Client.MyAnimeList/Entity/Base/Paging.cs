using System.Text.Json.Serialization;

namespace Api.Client.MyAnimeList.Entity.Base
{
    public class Paging
    {
        public string? Previous { get; set; }
        public string? Next { get; set; }

        public Paging()
        {
        }

        [JsonConstructor]
        public Paging(string? previous, string? next)
        {
            Previous = previous;
            Next = next;
        }
    }
}