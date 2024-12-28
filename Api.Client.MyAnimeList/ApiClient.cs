using Api.Client.Core;
using Api.Client.MyAnimeList.Entity;
using Api.Client.MyAnimeList.Entity.AnimeRoot;
using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity.Enums;
using Api.Client.MyAnimeList.Entity.Forum;
using Api.Client.MyAnimeList.Entity.MangaRoot;
using Api.Client.MyAnimeList.Entity.UserInformation;
using Api.Client.MyAnimeList.Utilities;
using Newtonsoft.Json;

namespace Api.Client.MyAnimeList
{
    public class ApiClient : WebApiBase<Arguments>
    {
        private const string WEB_API_URL = "https://api.myanimelist.net/v2/";
        private const string PARAMETER_DATE_FORMAT = "yyyy-MM-dd";
        public static readonly List<string> ALL_FIELDS = new List<string>() { "id", "title", "main_picture", "airing_status", "alternative_titles", "start_date", "end_date", "synopsis", "mean", "rank", "popularity", "num_list_users", "num_scoring_users", "nsfw", "created_at", "updated_at", "media_type", "status", "genres", "my_list_status", "num_episodes", "start_season", "broadcast", "source", "average_episode_duration", "rating", "pictures", "background", "related_anime", "related_manga", "recommendations", "studios", "statistics" };

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class with the specified API key.
        /// </summary>
        /// <param name="bearerToken">The API key to access MyAnimeList API.</param>
        public ApiClient(string bearerToken) : base(WEB_API_URL, bearerToken)
        {
            if (string.IsNullOrEmpty(bearerToken))
            {
                throw new ArgumentNullException("API key can't be null", "API Key");
            }

            HttpClientWithRetries.AddHeader("X-MAL-CLIENT-ID", string.Empty);
        }

        #region Anime

        #region GetAnimeList

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetAnimeList(string q, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.Anime,
                Query = q,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetAnimeList(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetAnimeList(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Anime>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Anime>>>> GetAnimeFullList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Anime>>, AnimeMangaNode<Anime>>(webApiArguments, GetAnimeList);
        }

        #endregion

        #region GetAnimeDetails

        public async Task<WebApiResponse<Anime>?> GetAnimeDetails(int id, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.Anime,
                Id = id,
                Fields = fields?.ToList() ?? ALL_FIELDS
            };

            return await GetAnimeDetails(arguments);
        }

        public async Task<WebApiResponse<Anime>?> GetAnimeDetails(Arguments webApiArguments)
        {
            return await GetApiElement<Anime>(webApiArguments);
        }

        #endregion

        #region GetAnimeRanking

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetAnimeRanking(RankingType rankingType, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.AnimeRanking,
                RankingType = rankingType,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetAnimeRanking(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetAnimeRanking(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Anime>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Anime>>>> GetAnimeRankingList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Anime>>, AnimeMangaNode<Anime>>(webApiArguments, GetAnimeRanking);
        }

        #endregion

        #region GetSeasonalAnimeList

        public async Task<WebApiResponse<EntitySeason<AnimeMangaNode<Anime>>>?> GetSeasonalAnimeList(int year, Season season, SeasonAnimeSort sort, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.AnimeSeason,
                Year = year,
                Season = season,
                Sort = sort,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetSeasonalAnimeList(arguments);
        }

        public async Task<WebApiResponse<EntitySeason<AnimeMangaNode<Anime>>>?> GetSeasonalAnimeList(Arguments webApiArguments)
        {
            return await GetApiElement<EntitySeason<AnimeMangaNode<Anime>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Anime>>>> GetSeasonalAnimeFullList(Arguments webApiArguments)
        {
            return await GetApiCallList<EntitySeason<AnimeMangaNode<Anime>>, AnimeMangaNode<Anime>>(webApiArguments, GetSeasonalAnimeList);
        }

        #endregion

        #region GetSuggestedAnimeList

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetSuggestedAnimeList(int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.AnimeSuggestions,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetSuggestedAnimeList(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetSuggestedAnimeList(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Anime>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Anime>>>> GetSuggestedAnimeFullList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Anime>>, AnimeMangaNode<Anime>>(webApiArguments, GetSuggestedAnimeList);
        }

        #endregion

        #endregion

        #region User Anime List

        #region UpdateUserAnimeList

        public async Task<WebApiResponse<AnimeUpdate>?> UpdateUserAnimeList(int animeId, AnimeUserStatus? userStatus = null, bool? isRewatching = null, int? score = null, int? numWatchedEpisodes = null,
            int? priority = null, int? numTimesRewatched = null, int? rewatch_value = null, string? tags = null, string? comments = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.UpdateUserAnimeList,
                Id = animeId
            };

            RequestBodySchema requestBodySchema = new RequestBodySchema
            {
                AnimeUserStatus = userStatus,
                IsRewatching = isRewatching,
                Score = score,
                NumWatchedEpisodes = numWatchedEpisodes,
                Priority = priority,
                NumTimesRewatched = numTimesRewatched,
                RewatchValue = rewatch_value,
                Tags = tags,
                Comments = comments
            };

            return await UpdateUserAnimeList(arguments, requestBodySchema);
        }

        public async Task<WebApiResponse<AnimeUpdate>?> UpdateUserAnimeList(Arguments webApiArguments, RequestBodySchema requestBodySchema)
        {
            return await GetApiElement<AnimeUpdate>(webApiArguments, requestBodySchema, HttpMethod.Patch);
        }

        #endregion

        #region GetUserAnimeList

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetUserAnimeList(string username, AnimeUserStatus userStatus, UserSort userSort, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.UserAnimeList,
                Username = username,
                UserSort = userSort,
                AnimeUserStatus = userStatus,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetUserAnimeList(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Anime>>>?> GetUserAnimeList(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Anime>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Anime>>>> GetUserAnimeFullList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Anime>>, AnimeMangaNode<Anime>>(webApiArguments, GetUserAnimeList);
        }

        #endregion

        #region Delete item from UserAnimeList

        public async Task<WebApiResponse<object>?> DeleteMyAnimeListItem(int animeId)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.DeleteMyAnimeListItem,
                Id = animeId
            };

            return await DeleteMyAnimeListItem(arguments);
        }

        public async Task<WebApiResponse<object>?> DeleteMyAnimeListItem(Arguments webApiArguments)
        {
            return await GetApiElement<object>(webApiArguments, null, HttpMethod.Delete);
        }

        #endregion

        #endregion

        #region Forum

        #region GetForumBoards

        public async Task<WebApiResponse<ForumCategories>?> GetForumBoards()
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.ForumBoards,
            };

            return await GetForumBoards(arguments);
        }

        public async Task<WebApiResponse<ForumCategories>?> GetForumBoards(Arguments webApiArguments)
        {
            return await GetApiElement<ForumCategories>(webApiArguments);
        }

        #endregion

        #region GetForumTopics

        public async Task<WebApiResponse<Entity<Topic>>?> GetForumTopics(int? boardId = null, int? subBoardId = null, int? limit = null, int? offset = null, ForumSort? sort = null, string? q = null, string? topicUsername = null, string? username = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.ForumTopics,
                BoardId = boardId,
                SubBoardId = subBoardId,
                Query = q,
                ForumSort = sort,
                TopicUsername = topicUsername,
                Username = username,
                Limit = limit,
                Offset = offset
            };

            return await GetForumTopics(arguments);
        }

        public async Task<WebApiResponse<Entity<Topic>>?> GetForumTopics(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<Topic>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<Topic>>> GetForumTopicsList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<Topic>, Topic>(webApiArguments, GetForumTopics);
        }

        #endregion

        #region GetForumTopicDetails
        public async Task<WebApiResponse<SingleEntity<TopicDetail>>?> GetForumTopicDetails(int topicId)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.ForumTopics,
                Id = topicId
            };

            return await GetForumTopicDetails(arguments);
        }

        public async Task<WebApiResponse<SingleEntity<TopicDetail>>?> GetForumTopicDetails(Arguments webApiArguments)
        {
            return await GetApiElement<SingleEntity<TopicDetail>>(webApiArguments);
        }

        #endregion

        #endregion

        #region Manga

        #region GetMangaList

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Manga>>>?> GetMangaList(string q, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.Manga,
                Query = q,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetMangaList(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Manga>>>?> GetMangaList(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Manga>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Manga>>>> GetMangaFullList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Manga>>, AnimeMangaNode<Manga>>(webApiArguments, GetMangaList);
        }

        #endregion

        #region GetMangaDetails

        public async Task<WebApiResponse<Manga>?> GetMangaDetails(int id, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.Manga,
                Id = id,
                Fields = fields?.ToList() ?? ALL_FIELDS
            };

            return await GetMangaDetails(arguments);
        }

        public async Task<WebApiResponse<Manga>?> GetMangaDetails(Arguments webApiArguments)
        {
            return await GetApiElement<Manga>(webApiArguments);
        }

        #endregion

        #region GetMangaRanking

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Manga>>>?> GetMangaRanking(RankingType rankingType, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.MangaRanking,
                RankingType = rankingType,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetMangaRanking(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Manga>>>?> GetMangaRanking(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Manga>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Manga>>>> GetMangaRankingList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Manga>>, AnimeMangaNode<Manga>>(webApiArguments, GetMangaRanking);
        }

        #endregion

        #endregion

        #region User Manga List

        #region UpdateUserMangaList

        public async Task<WebApiResponse<MangaUpdate>?> UpdateUserMangaList(int animeId, MangaUserStatus? userStatus = null, bool? isRewatching = null, int? score = null, int? numWatchedEpisodes = null,
            int? priority = null, int? numTimesRewatched = null, int? rewatch_value = null, string? tags = null, string? comments = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.UpdateUserMangaList,
                Id = animeId
            };

            RequestBodySchema requestBodySchema = new RequestBodySchema
            {
                MangaUserStatus = userStatus,
                IsRewatching = isRewatching,
                Score = score,
                NumWatchedEpisodes = numWatchedEpisodes,
                Priority = priority,
                NumTimesRewatched = numTimesRewatched,
                RewatchValue = rewatch_value,
                Tags = tags,
                Comments = comments
            };

            return await UpdateUserMangaList(arguments, requestBodySchema);
        }

        public async Task<WebApiResponse<MangaUpdate>?> UpdateUserMangaList(Arguments webApiArguments, RequestBodySchema requestBodySchema)
        {
            return await GetApiElement<MangaUpdate>(webApiArguments, requestBodySchema, HttpMethod.Patch);
        }

        #endregion

        #region GetUserMangaList

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Manga>>>?> GetUserMangaList(string username, MangaUserStatus userStatus, UserSort userSort, int? limit = null, int? offset = null, IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.UserMangaList,
                Username = username,
                UserSort = userSort,
                MangaUserStatus = userStatus,
                Fields = fields?.ToList(),
                Limit = limit,
                Offset = offset
            };

            return await GetUserMangaList(arguments);
        }

        public async Task<WebApiResponse<Entity<AnimeMangaNode<Manga>>>?> GetUserMangaList(Arguments webApiArguments)
        {
            return await GetApiElement<Entity<AnimeMangaNode<Manga>>>(webApiArguments);
        }

        public async Task<WebApiResponse<IEnumerable<AnimeMangaNode<Manga>>>> GetUserMangaFullList(Arguments webApiArguments)
        {
            return await GetApiCallList<Entity<AnimeMangaNode<Manga>>, AnimeMangaNode<Manga>>(webApiArguments, GetUserMangaList);
        }

        #endregion

        #region Delete item from UserMangaList

        public async Task<WebApiResponse<object>?> DeleteMyMangaListItem(int animeId)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.DeleteMyMangaListItem,
                Id = animeId
            };

            return await DeleteMyMangaListItem(arguments);
        }

        public async Task<WebApiResponse<object>?> DeleteMyMangaListItem(Arguments webApiArguments)
        {
            return await GetApiElement<object>(webApiArguments, null, HttpMethod.Delete);
        }

        #endregion

        #endregion

        #region User

        public async Task<WebApiResponse<UserInformation>?> GetMyUserInformation(IEnumerable<string>? fields = null)
        {
            Arguments arguments = new Arguments
            {
                ApiCallType = EndpointsEnum.Users,
                Fields = fields?.ToList() ?? new List<string>() { "anime_statistics" },
            };

            return await GetMyUserInformation(arguments);
        }

        public async Task<WebApiResponse<UserInformation>?> GetMyUserInformation(Arguments webApiArguments)
        {
            return await GetApiElement<UserInformation>(webApiArguments);
        }

        #endregion

        #region Common methods

        /// <summary>
        /// Retrieves a single API element based on the specified arguments.
        /// </summary>
        /// <typeparam name="T">The type of the API element.</typeparam>
        /// <param name="webApiArguments">The arguments for the API call.</param>
        /// <returns>A <see cref="WebApiResponse{T}"/> that contains the result of the API call.</returns>
        public async Task<WebApiResponse<T>?> GetApiElement<T>(Arguments webApiArguments, object? content = null, HttpMethod? httpMethod = null)
        {
            Arguments arguments = webApiArguments;
            HttpResponseMessage response = await SendWebApiRequest(httpMethod ?? HttpMethod.Get, arguments, content).ConfigureAwait(false);
            WebApiException? error = await CheckForWebApiException(response).ConfigureAwait(false);
            if (error != null)
            {
                return new WebApiResponse<T>(error);
            }
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            T? res = JsonConvert.DeserializeObject<T>(responseBody);
            return res == null ? null : new WebApiResponse<T>(res);
        }

        /// <summary>
        /// Retrieves a list of API elements based on the specified arguments.
        /// </summary>
        /// <typeparam name="Y">The type of the API element.</typeparam>
        /// <typeparam name="T">The type of the API response.</typeparam>
        /// <param name="webApiArguments">The arguments for the API call.</param>
        /// <param name="func">The function to retrieve a single API element.</param>
        /// <returns>A <see cref="WebApiResponse{T}"/> that contains the result of the API call.</returns>
        public static async Task<WebApiResponse<IEnumerable<T>>> GetApiCallList<Y, T>(Arguments webApiArguments, Func<Arguments, Task<WebApiResponse<Y>?>> func)
            where Y : Entity<T>
        {
            Arguments arguments = webApiArguments;
            IEnumerable<Y> apiObjects = new List<Y>();
            do
            {
                WebApiResponse<Y>? apiElement = await func(webApiArguments);
                if (apiElement?.Success == true && apiElement?.Records != null)
                {
                    apiObjects = apiObjects.Append(apiElement.Records);
                    arguments.NextUrl = apiElement.Records.Paging.Next;
                }
                else
                {
                    throw apiElement?.WebApiError ?? new Exception("Unsuccessful call without errors!");
                }
            } while (!string.IsNullOrEmpty(arguments.NextUrl));

            return new WebApiResponse<IEnumerable<T>>(apiObjects.SelectMany(l => l.Data));
        }

        #endregion

        protected override Uri BuildUriForListRecords(Arguments webApiArguments)
        {
            UriBuilder uriBuilder = new UriBuilder($"{WebApiUrl}{webApiArguments.ApiCallType}");
            switch(webApiArguments.ApiCallType)
            {
                case EndpointsEnum.Anime:
                case EndpointsEnum.Manga:
                    if (webApiArguments.Id != null)
                    {
                        uriBuilder = new UriBuilder($"{WebApiUrl}{webApiArguments.ApiCallType}/{webApiArguments.Id}");
                    }
                    break;
                case EndpointsEnum.AnimeRanking:
                    uriBuilder = new UriBuilder($"{WebApiUrl}Anime/Ranking");
                    break;
                case EndpointsEnum.MangaRanking:
                    uriBuilder = new UriBuilder($"{WebApiUrl}Manga/Ranking");
                    break;
                case EndpointsEnum.AnimeSeason:
                    if (webApiArguments.Year != null && webApiArguments.Season != null)
                    {
                        uriBuilder = new UriBuilder($"{WebApiUrl}Anime/Season/{webApiArguments.Year}/{ApiCallHelper.SeasonToString(webApiArguments.Season.Value)}");
                    }
                    break;
                case EndpointsEnum.AnimeSuggestions:
                    uriBuilder = new UriBuilder($"{WebApiUrl}Anime/Suggestions");
                    break;
                case EndpointsEnum.UserAnimeList:
                    if (webApiArguments.Username != null)
                    {
                        uriBuilder = new UriBuilder($"{WebApiUrl}users/{webApiArguments.Username}/animelist");
                    }
                    break;
                case EndpointsEnum.DeleteMyAnimeListItem:
                case EndpointsEnum.UpdateUserAnimeList:
                    uriBuilder = new UriBuilder($"{WebApiUrl}Anime/{webApiArguments.Id}/my_list_status");
                    break;
                case EndpointsEnum.ForumBoards:
                    uriBuilder = new UriBuilder($"{WebApiUrl}forum/boards");
                    break;
                case EndpointsEnum.ForumTopics:
                    if(webApiArguments.Id != null)
                    {
                        uriBuilder = new UriBuilder($"{WebApiUrl}forum/topic/{webApiArguments.Id}");
                    }
                    else
                    {
                        uriBuilder = new UriBuilder($"{WebApiUrl}forum/topics");
                    }
                    break;
                case EndpointsEnum.Users:
                    uriBuilder = new UriBuilder($"{WebApiUrl}users/@me");
                    break;
                default:
                    throw new NotImplementedException("API endpoint not found under current framework.");
            }

            if (!string.IsNullOrEmpty(webApiArguments.NextUrl))
            {
                uriBuilder = new UriBuilder(webApiArguments.NextUrl);
            }
            else
            {
                if (webApiArguments.BoardId != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"board_id={webApiArguments.BoardId}");
                }

                if (webApiArguments.SubBoardId != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"subboard_id={webApiArguments.SubBoardId}");
                }

                if (webApiArguments.Query != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"q={webApiArguments.Query}");
                }

                if (webApiArguments.Fields != null && webApiArguments.Fields.Any())
                {
                    AddParameterToQuery(ref uriBuilder, $"fields={string.Join(",", webApiArguments.Fields)}");
                }

                if (webApiArguments.Nsfw != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"nsfw={webApiArguments.Nsfw}");
                }

                if (webApiArguments.Sort != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"sort={ApiCallHelper.SortToString(webApiArguments.Sort.Value)}");
                }

                if (webApiArguments.UserSort != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"sort={ApiCallHelper.UserSortToString(webApiArguments.UserSort.Value)}");
                }

                if (webApiArguments.ForumSort != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"sort={ApiCallHelper.ForumSortToString(webApiArguments.ForumSort.Value)}");
                }

                if (webApiArguments.AnimeUserStatus != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"status={ApiCallHelper.AnimeUserStatusToString(webApiArguments.AnimeUserStatus.Value)}");
                }

                if (webApiArguments.MangaUserStatus != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"status={ApiCallHelper.MangaUserStatusToString(webApiArguments.MangaUserStatus.Value)}");
                }

                if (webApiArguments.Username != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"user_name={webApiArguments.Username}");
                }

                if (webApiArguments.TopicUsername != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"topic_user_name={webApiArguments.TopicUsername}");
                }

                if (webApiArguments.Limit != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"limit={webApiArguments.Limit}");
                }

                if (webApiArguments.Offset != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"offset={webApiArguments.Offset}");
                }

                if (webApiArguments.RankingType != null)
                {
                    AddParameterToQuery(ref uriBuilder, $"ranking_type={ApiCallHelper.RankingTypeToString(webApiArguments.RankingType.Value)}");
                }
            }

            return new Uri(uriBuilder.Uri.ToString().ToLower());
        }
    }
}
