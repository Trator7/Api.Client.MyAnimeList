using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity.Base.SubElements;
using Api.Client.MyAnimeList.Entity.Enums;
using Api.Client.MyAnimeList.Entity.MangaRoot.SubElements;
using Api.Client.MyAnimeList.Utilities;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.MangaRoot
{
    public class Manga : AnimeMangaBase
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
                    "manga" => Enums.MediaType.Manga,
                    "novel" => Enums.MediaType.Novel,
                    "one_shot" => Enums.MediaType.OneShot,
                    "doujinshi" => Enums.MediaType.Doujinshi,
                    "manhwa" => Enums.MediaType.Manhwa,
                    "manhua" => Enums.MediaType.Manhua,
                    "oel" => Enums.MediaType.OEL,
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
                    "finished" => AiringStatus.Finished,
                    "currently_publishing" => AiringStatus.CurrentlyPublishing,
                    "not_yet_published" => AiringStatus.NotYetPublished,
                    _ => null,
                };
            }
            set
            {
                _status = value != null ? ApiCallHelper.AiringStatusToString(value.Value) : null;
            }
        }
        [JsonProperty("my_list_status")]
        public MyListStatusManga? MyListStatus { get; set; }
        [JsonProperty("num_volumes")]
        public int? NumVolumes { get; set; }
        [JsonProperty("num_chapters")]
        public int? NumChapters { get; set; }
        [JsonProperty("authors")]
        public List<Author>? Authors { get; set; }

        public List<MangaMagazineRelationEdge>? Serialization { get; set; }

        public Manga(string title) : base(title)
        {
            Title = title;
            MainPicture = new Picture();
        }

        [JsonConstructor]
        public Manga(
            int id, string title, Picture mainPicture, List<Picture> pictures, AlternativeTitles? alternativeTitles, DateTime? startDate,
            DateTime? endDate, string? synopsis, float? mean, int? rank, int? popularity, int numListUsers, int numScoringUsers, Nsfw? nsfw, List<Genre>? genres, DateTime? createdAt,
            DateTime? updatedAt, string? mediaType, string? background, string? status, MyListStatusManga? myListStatus, int? numVolumes, int? numChapters, List<Author>? authors,
            List<RelatedAnimeManga>? relatedAnime, List<RelatedAnimeManga>? relatedManga, List<Recommendations>? recommendations, List<MangaMagazineRelationEdge>? serialization) :
            base(id, title, mainPicture, pictures, alternativeTitles, startDate, endDate, synopsis, mean, rank, popularity,
            numListUsers, numScoringUsers, nsfw, genres, createdAt, updatedAt, background, relatedAnime, relatedManga, recommendations)
        {
            _mediaType = mediaType;
            _status = status;
            MyListStatus = myListStatus;
            NumVolumes = numVolumes;
            NumChapters = numChapters;
            Authors = authors;
            Serialization = serialization;
        }
    }
}
