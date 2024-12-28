using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity.Enums;
using Api.Client.MyAnimeList.Utilities;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity
{
    public class RelatedAnimeManga
    {
        public AnimeMangaBase Node { get; set; }
        [JsonProperty("relation_type")]
        private string? _relationType;
        [JsonIgnore]
        public RelationType? RelationType
        {
            get
            {
                return _relationType switch
                {
                    "alternative_setting" => Enums.RelationType.AlternativeSetting,
                    "alternative_version" => Enums.RelationType.AlternativeVersion,
                    "full_story" => Enums.RelationType.FullStory,
                    "parent_story" => Enums.RelationType.ParentStory,
                    "prequel" => Enums.RelationType.Prequel,
                    "sequel" => Enums.RelationType.Sequel,
                    "side_story" => Enums.RelationType.SideStory,
                    "summary"  => Enums.RelationType.Summary,
                    _ => null,
                };
            }
            set
            {
                _relationType = value != null ? ApiCallHelper.RelationTypeToString(value.Value) : null;
            }
        }


        [JsonProperty("relation_type_formatted")]
        public string? RelationTypeFormatted { get; set; }

        public RelatedAnimeManga(AnimeMangaBase value, string? relationType, string? relationTypeFormatted)
        {
            Node = value;
            _relationType = relationType;
            RelationTypeFormatted = relationTypeFormatted;
        }
    }
}