using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements
{
    public class Statistics
    {
        public Status Status { get; set; }
        [JsonProperty("num_list_users")]
        public int NumListUsers { get; set; }

        [JsonConstructor]
        public Statistics(Status status, int numListUsers)
        {
            Status = status;
            NumListUsers = numListUsers;
        }
    }
}
