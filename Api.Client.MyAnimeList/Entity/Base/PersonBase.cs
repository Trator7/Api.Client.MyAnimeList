using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Base
{
    public class PersonBase
    {
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public PersonBase(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
