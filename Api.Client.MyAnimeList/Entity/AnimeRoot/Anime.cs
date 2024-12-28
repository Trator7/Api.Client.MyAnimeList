using Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements;
using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity.Base.SubElements;
using Api.Client.MyAnimeList.Entity.Enums;
using Api.Client.MyAnimeList.Utilities;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot
{
    public class Anime : AnimeMangaBase
    {
        [JsonProperty("media_type")]
        private string? _mediaType;
        [JsonIgnore]
        public MediaType? MediaType
        {
            get
            {
                return _mediaType switch
                {
                    "unknown" => Enums.MediaType.Unknown,
                    "tv" => Enums.MediaType.Tv,
                    "ova" => Enums.MediaType.OVA,
                    "movie" => Enums.MediaType.Movie,
                    "special" => Enums.MediaType.Special,
                    "ona" => Enums.MediaType.ONA,
                    "music" => Enums.MediaType.Music,
                    _ => null,
                };
            }
            set
            {
                _mediaType = value != null ? ApiCallHelper.MediaTypeToString(value.Value) : null;
            }
        }
        [JsonProperty("status")]
        private string? _status;
        [JsonIgnore]
        public AiringStatus? Status
        {
            get
            {
                return _status switch
                {
                    "finished_airing" => AiringStatus.FinishedAiring,
                    "currently_airing" => AiringStatus.CurrentlyAiring,
                    "not_yet_aired" => AiringStatus.NotYetAired,
                    _ => null,
                };
            }
            set
            {
                _status = value != null ? ApiCallHelper.AiringStatusToString(value.Value) : null;
            }
        }
        [JsonProperty("my_list_status")]
        public MyListStatusAnime? MyListStatus { get; set; }
        [JsonProperty("num_episodes")]
        public int? NumEpisodes { get; set; }
        [JsonProperty("start_season")]
        public SeasonPeriod? StartSeason { get; set; }
        public Broadcast? Broadcast { get; set; }
        [JsonProperty("source")]
        private string? _airingSource;
        [JsonIgnore]
        public Source? AiringSource
        {
            get
            {
                return _airingSource switch
                {
                    "other" => Source.Other,
                    "original" => Source.Original,
                    "manga" => Source.Manga,
                    "4_koma_manga" => Source.KomaManga,
                    "web_manga" => Source.WebManga,
                    "digital_manga" => Source.DigitalManga,
                    "novel" => Source.Novel,
                    "light_novel" => Source.LightNovel,
                    "visual_novel" => Source.VisualNovel,
                    "game" => Source.Game,
                    "card_game" => Source.CardGame,
                    "book" => Source.Book,
                    "picture_book" => Source.PictureBook,
                    "radio" => Source.Radio,
                    "music" => Source.Music,
                    _ => null,
                };
            }
            set
            {
                _airingSource = value != null ? ApiCallHelper.SourceToString(value.Value) : null;
            }
        }
        [JsonProperty("average_episode_duration")]
        public int? AverageEpisodeDuration { get; set; }
        public Rating? Rating { get; set; }
        public List<Studio>? Studios { get; set; }
        public Statistics? Statistics { get; set; }

        public Anime(string title) : base(title)
        {
        }

        [JsonConstructor]
        public Anime(
            int id, string title, Picture mainPicture, List<Picture> pictures, AlternativeTitles? alternativeTitles, DateTime? startDate, DateTime? endDate,
            string? synopsis, float? mean, int? rank, int? popularity, int numListUsers, int numScoringUsers, Nsfw? nsfw, List<Genre>? genres,
            DateTime? createdAt, DateTime? updatedAt, string? mediaType, string? background, string? status, MyListStatusAnime? myListStatus, int? numEpisodes,
            SeasonPeriod? startSeason, Broadcast? broadcast, string? airingSource, int? averageEpisodeDuration, Rating? rating, List<Studio>? studios,
            List<RelatedAnimeManga>? relatedAnime, List<RelatedAnimeManga>? relatedManga, List<Recommendations>? recommendations, Statistics? statistics) :
            base(id, title, mainPicture, pictures, alternativeTitles, startDate, endDate, synopsis, mean, rank, popularity,
            numListUsers, numScoringUsers, nsfw, genres, createdAt, updatedAt, background, relatedAnime, relatedManga, recommendations)
        {
            _mediaType = mediaType;
            _status = status;
            MyListStatus = myListStatus;
            NumEpisodes = numEpisodes;
            StartSeason = startSeason;
            Broadcast = broadcast;
            _airingSource = airingSource;
            AverageEpisodeDuration = averageEpisodeDuration;
            Rating = rating;
            Studios = studios;
            Statistics = statistics;
        }
    }
}