using Api.Client.MyAnimeList.Entity.Enums;

namespace Api.Client.MyAnimeList.Utilities
{
    public static class ApiCallHelper
    {
        public static string AiringStatusToString(AiringStatus airingStatus)
        {
            return airingStatus switch
            {
                AiringStatus.Finished => "finished",
                AiringStatus.FinishedAiring => "finished_airing",
                AiringStatus.CurrentlyPublishing => "currently_publishing",
                AiringStatus.CurrentlyAiring => "currently_airing",
                AiringStatus.NotYetPublished => "not_yet_published",
                AiringStatus.NotYetAired => "not_yet_aired",
                _ => throw new ArgumentException("Invalid airing status"),
            };
        }

        public static string ListAnimeUserStatusEnumToString(AnimeUserStatus listStatusEnum)
        {
            return listStatusEnum switch
            {
                AnimeUserStatus.Watching => "watching",
                AnimeUserStatus.Completed => "completed",
                AnimeUserStatus.OnHold => "on_hold",
                AnimeUserStatus.Dropped => "dropped",
                AnimeUserStatus.PlanToWatch => "plan_to_watch",
                _ => throw new ArgumentException("Invalid AnimeUserStatus status"),
            };
        }

        public static string ListMangaUserStatusEnumToString(MangaUserStatus listStatusEnum)
        {
            return listStatusEnum switch
            {
                MangaUserStatus.Reading => "reading",
                MangaUserStatus.Completed => "completed",
                MangaUserStatus.OnHold => "on_hold",
                MangaUserStatus.Dropped => "dropped",
                MangaUserStatus.PlanToRead => "plan_to_read",
                _ => throw new ArgumentException("Invalid MangaUserStatus status"),
            };
        }

        public static string MediaTypeToString(MediaType mediaType)
        {
            return mediaType switch
            {
                MediaType.Unknown => "unknown",
                MediaType.Tv => "tv",
                MediaType.OVA => "ova",
                MediaType.Movie => "movie",
                MediaType.Special => "special",
                MediaType.ONA => "ona",
                MediaType.Music => "music",
                MediaType.Manga => "manga",
                MediaType.Novel => "novel",
                MediaType.OneShot => "one_shot",
                MediaType.Doujinshi => "doujinshi",
                MediaType.Manhwa => "manhwa",
                MediaType.Manhua => "manhua",
                MediaType.OEL => "oel",
                _ => throw new ArgumentException("Invalid media type"),
            };
        }

        public static string NsfwToString(Nsfw nsfw)
        {
            return nsfw switch
            {
                Nsfw.white => "white",
                Nsfw.gray => "gray",
                Nsfw.black => "black",
                _ => throw new ArgumentException("Invalid nsfw"),
            };
        }

        public static string RankingTypeToString(RankingType rankingType)
        {
            return rankingType switch
            {
                RankingType.All => "all",
                RankingType.Airing => "airing",
                RankingType.Upcoming => "upcoming",
                RankingType.TV => "tv",
                RankingType.OVA => "ova",
                RankingType.Movie => "movie",
                RankingType.Special => "special",
                RankingType.ByPopularity => "bypopularity",
                RankingType.Favorite => "favorite",
                RankingType.Manga => "manga",
                RankingType.Novels => "novels",
                RankingType.Oneshots => "oneshots",
                RankingType.Doujin => "doujin",
                RankingType.Manhwa => "manhwa",
                RankingType.Manhua => "manhua",
                _ => throw new ArgumentException("Invalid ranking type"),
            };
        }

        public static string RatingToString(Rating rating)
        {
            return rating switch
            {
                Rating.G => "g", 
                Rating.PG => "pg",
                Rating.pg_13 => "pg_13",
                Rating.R => "r",
                Rating.rPlus => "r+",
                Rating.Rx => "rx",
                _ => throw new ArgumentException("Invalid rating"),
            };
        }

        public static string SeasonToString(Season season)
        {
            return season switch
            {
                Season.Winter => "winter",
                Season.Spring => "spring",
                Season.Summer => "summer",
                Season.Fall => "fall",
                _ => throw new ArgumentException("Invalid season"),
            };
        }

        public static string SortToString(SeasonAnimeSort sort)
        {
            return sort switch
            {
                SeasonAnimeSort.AnimeScore => "anime_score",
                SeasonAnimeSort.AnimeNumListUsers => "anime_num_list_users",
                _ => throw new ArgumentException("Invalid sort"),
            };
        }

        public static string UserSortToString(UserSort userSort)
        {
            return userSort switch
            {
                UserSort.ListScore => "list_score",
                UserSort.ListUpdatedAt => "list_updated_at",
                UserSort.AnimeTitle => "anime_title",
                UserSort.AnimeStartDate => "anime_start_date",
                UserSort.AnimeId => "anime_id",
                _ => throw new ArgumentException("Invalid user sort"),
            };
        }

        public static string ForumSortToString(ForumSort userSort)
        {
            return userSort switch
            {
                ForumSort.Recent => "recent",
                _ => throw new ArgumentException("Invalid user sort"),
            };
        }

        public static string AnimeUserStatusToString(AnimeUserStatus userSort)
        {
            return userSort switch
            {
                AnimeUserStatus.Watching => "watching",
                AnimeUserStatus.Completed => "completed",
                AnimeUserStatus.OnHold => "on_hold",
                AnimeUserStatus.Dropped => "dropped",
                AnimeUserStatus.PlanToWatch => "plan_to_watch",
                _ => throw new ArgumentException("Invalid user sort"),
            };
        }

        public static string MangaUserStatusToString(MangaUserStatus userSort)
        {
            return userSort switch
            {
                MangaUserStatus.Reading => "reading",
                MangaUserStatus.Completed => "completed",
                MangaUserStatus.OnHold => "on_hold",
                MangaUserStatus.Dropped => "dropped",
                MangaUserStatus.PlanToRead => "plan_to_read",
                _ => throw new ArgumentException("Invalid user sort"),
            };
        }

        public static string SourceToString(Source source)
        {
            return source switch
            {
                Source.Other => "other",
                Source.Original => "original",
                Source.Manga => "manga",
                Source.KomaManga => "4_koma_manga",
                Source.WebManga => "web_manga",
                Source.DigitalManga => "digital_manga",
                Source.Novel => "novel",
                Source.LightNovel => "light_novel",
                Source.VisualNovel => "visual_novel",
                Source.Game => "game",
                Source.CardGame => "card_game",
                Source.Book => "book",
                Source.PictureBook => "picture_book",
                Source.Radio => "radio",
                Source.Music => "music",
                _ => throw new ArgumentException("Invalid source"),
            };
        }

        public static string RelationTypeToString(RelationType relationType)
        {
            return relationType switch
            {
                RelationType.AlternativeSetting => "alternative_setting",
                RelationType.AlternativeVersion => "alternative_version",
                RelationType.FullStory => "full_story",
                RelationType.ParentStory => "parent_story",
                RelationType.Prequel => "prequel",
                RelationType.Sequel => "sequel",
                RelationType.SideStory => "side_story",
                RelationType.Summary => "summary",
                _ => throw new ArgumentException("Invalid relation type"),
            };
        }
    }
}