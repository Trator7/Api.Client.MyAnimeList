using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.UserInformation
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Picture { get; set; }
        public string? Gender { get; set; }
        public string? Birthday { get; set; }
        public string? Location { get; set; }
        [JsonProperty("joined_at")]
        public string? JoinedAt { get; set; }
        [JsonProperty("anime_statistics")]
        public AnimeUserStatistics? AnimeStatistics { get; set; }
        [JsonProperty("time_zone")]
        public string? TimeZone { get; set; }
        [JsonProperty("is_supporter")]
        public bool? IsSupporter { get; set; }

        public UserInformation(int id, string name, string? picture, string? gender, string? birthday, string? location, string? joinedAt, AnimeUserStatistics? animeStatistics, string? timeZone, bool? isSupporter)
        {
            Id = id;
            Name = name;
            Picture = picture;
            Gender = gender;
            Birthday = birthday;
            Location = location;
            JoinedAt = joinedAt;
            AnimeStatistics = animeStatistics;
            TimeZone = timeZone;
            IsSupporter = isSupporter;
        }
    }
}
