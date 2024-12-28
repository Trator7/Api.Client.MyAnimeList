using Api.Client.Core;
using Api.Client.MyAnimeList.Entity.Enums;

namespace Api.Client.MyAnimeList
{
    /// <summary>
    /// Represents the arguments for an API call to the MyAnimeList API.
    /// </summary>
    public class Arguments : WebApiArguments<EndpointsEnum>
    {
        public int? Id { get; set; }
        public int? BoardId { get; set; }
        public int? SubBoardId { get; set; }
        public string? Query { get; set; }
        public string? Username { get; set; }
        public string? TopicUsername { get; set; }
        public AnimeUserStatus? AnimeUserStatus { get; set; }
        public MangaUserStatus? MangaUserStatus { get; set; }
        public UserSort? UserSort { get; set; }
        public SeasonAnimeSort? Sort { get; set; }
        public ForumSort? ForumSort { get; set; }
        public List<string>? Fields { get; set; } = new List<string>();
        public bool? Nsfw { get; set; }
        public RankingType? RankingType { get; set; }
        public int? Year { get; set; }
        public Season? Season { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? NextUrl { get; set; }
    }
}