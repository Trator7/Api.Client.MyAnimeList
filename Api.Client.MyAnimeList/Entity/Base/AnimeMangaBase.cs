using Api.Client.MyAnimeList.Entity.Base.SubElements;
using Api.Client.MyAnimeList.Entity.Enums;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.Base
{
    public class AnimeMangaBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("main_picture")]
        public Picture MainPicture { get; set; }
        public List<Picture>? Pictures { get; set; }

        [JsonProperty("alternative_titles")]
        public AlternativeTitles? AlternativeTitles { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }
        public string? Synopsis { get; set; }
        public float? Mean { get; set; }
        public int? Rank { get; set; }
        public int? Popularity { get; set; }
        [JsonProperty("num_list_users")]
        public int NumListUsers { get; set; }
        [JsonProperty("num_scoring_users")]
        public int NumScoringUsers { get; set; }
        public Nsfw? Nsfw { get; set; }
        public List<Genre>? Genres { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        public string? Background { get; set; }
        [JsonProperty("related_anime")]
        public List<RelatedAnimeManga>? RelatedAnime { get; set; }
        [JsonProperty("related_manga")]
        public List<RelatedAnimeManga>? RelatedManga { get; set; }
        public List<Recommendations>? Recommendations { get; set; }

        public AnimeMangaBase(string title)
        {
            Title = title;
            MainPicture = new Picture();
        }

        [JsonConstructor]
        public AnimeMangaBase(
            int id, string title, Picture mainPicture, List<Picture> pictures, AlternativeTitles? alternativeTitles,
            DateTime? startDate, DateTime? endDate, string? synopsis, float? mean, int? rank, int? popularity,
            int numListUsers, int numScoringUsers, Nsfw? nsfw, List<Genre>? genres, DateTime? createdAt, DateTime? updatedAt,
            string? background, List<RelatedAnimeManga>? relatedAnime, List<RelatedAnimeManga>? relatedManga,
            List<Recommendations>? recommendations)
        {
            Id = id;
            Title = title;
            MainPicture = mainPicture;
            Pictures = pictures;
            AlternativeTitles = alternativeTitles;
            StartDate = startDate;
            EndDate = endDate;
            Synopsis = synopsis;
            Mean = mean;
            Rank = rank;
            Popularity = popularity;
            NumListUsers = numListUsers;
            NumScoringUsers = numScoringUsers;
            Nsfw = nsfw;
            Genres = genres;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Background = background;
            RelatedAnime = relatedAnime;
            RelatedManga = relatedManga;
            Recommendations = recommendations;
        }
    }
}
