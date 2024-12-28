using Newtonsoft.Json;
using Api.Client.Core;
using Api.Client.MyAnimeList;
using Api.Client.MyAnimeList.Entity.Base;
using Api.Client.MyAnimeList.Entity;
using Api.Client.MyAnimeList.Entity.Enums;
using Api.Client.MyAnimeList.Entity.AnimeRankingSubElements;
using Api.Client.MyAnimeList.Entity.Forum;
using Api.Client.MyAnimeList.Entity.AnimeRoot;
using Api.Client.MyAnimeList.Entity.MangaRoot;
using Api.Client.MyAnimeList.Entity.Base.SubElements;
using Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements;
using Api.Client.MyAnimeList.Entity.UserInformation;

namespace Test.MyAnimeListApi
{
    /*
     * These API tests are meant to be run with a valid MyAnimeList API key.
     * These test are intended only during development and should not be run in the CI pipeline.
     * 
     * Some test data changes frequently, so the expected output may not match the actual output.
     */
    public class TestsApiClient
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient(Test.Default.MyAnimeListApiKey);
        }

        [TearDown]
        public void TearDown()
        {
            _apiClient.Dispose();
        }

        [Test]
        public void TestRawResponse()
        {
            string expectedOutput = "{\"id\":52991,\"title\":\"Sousou no Frieren\",\"main_picture\":{\"medium\":\"https:\\/\\/cdn.myanimelist.net\\/images\\/anime\\/1015\\/138006.jpg\",\"large\":\"https:\\/\\/cdn.myanimelist.net\\/images\\/anime\\/1015\\/138006l.jpg\"}}";
            string rawResponse = _apiClient.GetRawJsonResponse("https://api.myanimelist.net/v2/anime/52991").Result;
            Assert.That(rawResponse.Replace(".webp", ".jpg"), Is.EqualTo(expectedOutput));
        }

        #region Anime

        //[Ignore("This test is ignored because the API returns different responses.")]
        [Test]
        public void TestGetAnimeList()
        {
            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? expectedReturn =
                new WebApiResponse<Entity<AnimeMangaNode<Anime>>>(
                    new Entity<AnimeMangaNode<Anime>>(
                        new List<AnimeMangaNode<Anime>>
                        {
                            new AnimeMangaNode<Anime>(new Anime("One Piece Movie 01") { Id = 459, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/1770/97704.jpg", "https://cdn.myanimelist.net/images/anime/1770/97704l.jpg")}, default)
                        },
                        new Paging(null, "https://api.myanimelist.net/v2/anime?offset=1&q=one+piece&limit=1")
                        ));

            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? actualReturn = _apiClient.GetAnimeList("One Piece", limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        //[Ignore("This test is ignored because the API returns different responses very frequently.")]
        [Test]
        public void TestGetAnimeDetails()
        {
            WebApiResponse<Anime>? expectedReturn = new WebApiResponse<Anime>(
                new Anime(30230, "Diamond no Ace: Second Season", new Picture("https://cdn.myanimelist.net/images/anime/9/74398.jpg", "https://cdn.myanimelist.net/images/anime/9/74398l.jpg"),
                new List<Picture> { new Picture("https://cdn.myanimelist.net/images/anime/3/73625.jpg", "https://cdn.myanimelist.net/images/anime/3/73625l.jpg"), new Picture("https://cdn.myanimelist.net/images/anime/9/74398.jpg", "https://cdn.myanimelist.net/images/anime/9/74398l.jpg") },
                new AlternativeTitles(new List<string> { "Daiya no Ace: Second Season", "Ace of the Diamond: 2nd Season" }, "Ace of Diamond: Second Season", "ダイヤのA[エース]～Second Season～"), new DateTime(2015, 04, 06), new DateTime(2016, 03, 28),
                "After the National Tournament, the Seidou High baseball team moves forward with uncertainty as the Fall season quickly approaches. In an attempt to build a stronger team centered around their new captain, fresh faces join the starting roster for the very first time. Previous losses weigh heavily on the minds of the veteran players as they continue their rigorous training, preparing for what will inevitably be their toughest season yet.\n \nRivals both new and old stand in their path as Seidou once again climbs their way toward the top, one game at a time. Needed now more than ever before, Furuya and Eijun must be determined to pitch with all their skill and strength in order to lead their team to victory. And this time, one of these young pitchers may finally claim that coveted title: \"The Ace of Seidou.\"\n\n[Written by MAL Rewrite]",
                8.3f, 274, 1691, 142169, 78933, Nsfw.white, new List<Genre> { new Genre(23, "School"), new Genre(27, "Shounen"), new Genre(30, "Sports"), new Genre(77, "Team Sports") }, DateTime.Parse("2015-03-02T07:03:11+01:00"), DateTime.Parse("2023-01-17T05:03:53+01:00"),
                "tv", string.Empty, "finished_airing", null, 51, new SeasonPeriod(2015, Season.Spring), new Broadcast("monday", "18:00"), "manga", 1440, Rating.pg_13, new List<Studio> { new Studio(10, "Production I.G"), new Studio(11, "Madhouse") },
                new List<RelatedAnimeManga>()
                {
                    new RelatedAnimeManga(new AnimeMangaBase("Diamond no Ace"){ Id = 18689, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/5/54235.jpg", "https://cdn.myanimelist.net/images/anime/5/54235l.jpg") }, "prequel", "Prequel"),
                    new RelatedAnimeManga(new AnimeMangaBase("Diamond no Ace: Second Season OVA"){ Id = 34349, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/12/83218.jpg", "https://cdn.myanimelist.net/images/anime/12/83218l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("Diamond no Ace: Act II"){ Id = 38731, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/1153/100511.jpg", "https://cdn.myanimelist.net/images/anime/1153/100511l.jpg") }, "sequel", "Sequel"),
                },
                new List<RelatedAnimeManga>(),
                new List<Recommendations>()
                {
                    new Recommendations(new AnimeMangaBase("Haikyuu!! Second Season"){ Id = 28891, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/9/76662.jpg", "https://cdn.myanimelist.net/images/anime/9/76662l.jpg") }, 4),
                    new Recommendations(new AnimeMangaBase("Haikyuu!!"){ Id = 20583, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/7/76014.jpg", "https://cdn.myanimelist.net/images/anime/7/76014l.jpg") }, 2),
                    new Recommendations(new AnimeMangaBase("Ookiku Furikabutte"){ Id = 2159, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/2/20751.jpg", "https://cdn.myanimelist.net/images/anime/2/20751l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("Cross Game"){ Id = 5941, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/6/22103.jpg", "https://cdn.myanimelist.net/images/anime/6/22103l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("Yowamushi Pedal"){ Id = 18179, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/5/53211.jpg", "https://cdn.myanimelist.net/images/anime/5/53211l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("Kuroko no Basket 2nd Season"){ Id = 16894, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/9/56155.jpg", "https://cdn.myanimelist.net/images/anime/9/56155l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("Kuroko no Basket 3rd Season"){ Id = 24415, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/4/68299.jpg", "https://cdn.myanimelist.net/images/anime/4/68299l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("Days"){ Id = 32494, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/11/88507.jpg", "https://cdn.myanimelist.net/images/anime/11/88507l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("Haikyuu!! Karasuno Koukou vs. Shiratorizawa Gakuen Koukou"){ Id = 32935, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/7/81992.jpg", "https://cdn.myanimelist.net/images/anime/7/81992l.jpg") }, 1),
                    new Recommendations(new AnimeMangaBase("One Outs"){ Id = 5040, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/7/21065.jpg", "https://cdn.myanimelist.net/images/anime/7/21065l.jpg") }, 1),
                },
                new Statistics(new Status(10673, 101029, 4591, 2810, 23063), 142166))
                );

            WebApiResponse<Anime>? actualReturn = _apiClient.GetAnimeDetails(30230).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void TestGetAnimeRanking()
        {
            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? expectedReturn = new WebApiResponse<Entity<AnimeMangaNode<Anime>>>(
                new Entity<AnimeMangaNode<Anime>>(
                    new List<AnimeMangaNode<Anime>>
                    {
                        new AnimeMangaNode<Anime>(new Anime("Sousou no Frieren") { Id = 52991, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/1015/138006.jpg", "https://cdn.myanimelist.net/images/anime/1015/138006l.jpg")}, new Ranking(1, null))
                    },
                    new Paging(null, "https://api.myanimelist.net/v2/anime/ranking?offset=1&limit=1&ranking_type=all")
                    ));

            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? actualReturn = _apiClient.GetAnimeRanking(RankingType.All, limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void TestGetSeasonalAnimeList()
        {
            WebApiResponse<EntitySeason<AnimeMangaNode<Anime>>>? expectedReturn = new WebApiResponse<EntitySeason<AnimeMangaNode<Anime>>>(
                new EntitySeason<AnimeMangaNode<Anime>>(
                    new List<AnimeMangaNode<Anime>>
                    {
                        new AnimeMangaNode<Anime>(new Anime("Alien Stage") { Id = 55255, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/1524/143502.jpg", "https://cdn.myanimelist.net/images/anime/1524/143502l.jpg")}, null)
                    },
                    new Paging(null, "https://api.myanimelist.net/v2/anime/season/2023/winter?offset=1&sort=anime_score&limit=1"),
                    new SeasonPeriod(2023, Season.Winter)
                    ));

            WebApiResponse<EntitySeason<AnimeMangaNode<Anime>>>? actualReturn = _apiClient.GetSeasonalAnimeList(2023, Season.Winter, SeasonAnimeSort.AnimeScore, limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Ignore("This test is ignored because the API returns different responses very frequently.")]
        [Test]
        public void TestGetSuggestedAnimeList()
        {
            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? expectedReturn = new WebApiResponse<Entity<AnimeMangaNode<Anime>>>(
                new Entity<AnimeMangaNode<Anime>>(
                    new List<AnimeMangaNode<Anime>>
                    {
                        new AnimeMangaNode<Anime>(new Anime("Romeo no Aoi Sora") { Id = 2559, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/4/17979.jpg", "https://cdn.myanimelist.net/images/anime/4/17979l.jpg")}, null)
                    },
                    new Paging(null, "https://api.myanimelist.net/v2/anime/suggestions?offset=1&limit=1")
                    ));

            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? actualReturn = _apiClient.GetSuggestedAnimeList(limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        #endregion Anime

        #region User Anime List

        [Test]
        public void TestGetUserAnimeList()
        {
            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? expectedReturn = new WebApiResponse<Entity<AnimeMangaNode<Anime>>>(
                new Entity<AnimeMangaNode<Anime>>(
                    new List<AnimeMangaNode<Anime>>
                    {
                        new AnimeMangaNode<Anime>(new Anime("Re:Zero kara Hajimeru Isekai Seikatsu 3rd Season") { Id = 54857, MainPicture = new Picture("https://cdn.myanimelist.net/images/anime/1706/144725.jpg", "https://cdn.myanimelist.net/images/anime/1706/144725l.jpg")}, null)
                    },
                    new Paging(null, "https://api.myanimelist.net/v2/users/@me/animelist?offset=1&sort=anime_start_date&status=watching&user_name=%40me&limit=1")
                    ));

            WebApiResponse<Entity<AnimeMangaNode<Anime>>>? actualReturn = _apiClient.GetUserAnimeList("@me", AnimeUserStatus.Watching, UserSort.AnimeStartDate, limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void TestUpdateUserAnimeList()
        {
            WebApiResponse<AnimeUpdate>? expectedReturn = new WebApiResponse<AnimeUpdate>(
                new AnimeUpdate()
                {
                    Status = AnimeUserStatus.Dropped,
                    IsRewatching = false,
                    UpdatedAt = DateTime.Parse("2024-12-28T09:24:17+00:00"),
                    Score = 6,
                    NumEpisodesWatched = 7,
                    Priority = 2,
                    NumTimesRewatched = 0,
                    RewatchValue = 0,
                    Tags = new List<string>() { "meh" },
                    Comments = "meh"
                });

            WebApiResponse<AnimeUpdate>? actualReturn = _apiClient.UpdateUserAnimeList(animeId: 41491, AnimeUserStatus.Dropped, false, 6, 7, 2, 0, 0, "meh", "meh").Result;

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            actualReturn.Records.UpdatedAt = expectedReturn.Records.UpdatedAt;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

            string jsonActual = JsonConvert.SerializeObject(actualReturn);
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void TestDeleteMyAnimeListItem()
        {
            WebApiResponse<object>? expectedReturn = new WebApiResponse<object>(new List<object> { });

            WebApiResponse<object>? actualReturn = _apiClient.DeleteMyAnimeListItem(animeId: 41491).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn);
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        #endregion User Anime List

        #region Forum

        [Test]
        public void TestGetForumBoards()
        {
            WebApiResponse<ForumCategories>? expectedReturn = new WebApiResponse<ForumCategories>(
                new ForumCategories(new List<ForumTopic>()
                {
                    new ForumTopic("MyAnimeList",
                    new List<ForumBoard>()
                    {
                        new ForumBoard(5, "Updates & Announcements", "Updates, changes, and additions to MAL.", null),
                        new ForumBoard(14, "MAL Guidelines & FAQ", "Site rules, forum rules, database guidelines, review/recommendation guidelines, and other helpful information.", null),
                        new ForumBoard(17, "DB Modification Requests", "Ask questions or submit changes (that you are unable to edit on the entry page) in the applicable board.",
                            new List<ForumBoard>(){ new ForumBoard(2, "Anime DB", null, null), new ForumBoard(3, "Character & People DB", null, null), new ForumBoard(5, "Manga DB", null, null) }),
                        new ForumBoard(3, "Support", "Have a problem using the site or think you found a bug? Post here.", null),
                        new ForumBoard(4, "Suggestions", "Have an idea or suggestion for the site? Share it here.", null),
                        new ForumBoard(13, "MAL Contests", "Our season-long anime game and other user competitions can be found here.", null),
                    }),
                    new ForumTopic("Anime & Manga",
                    new List<ForumBoard>()
                    {
                        new ForumBoard(15, "News Discussion", "Current news in anime and manga.", null),
                        new ForumBoard(16, "Anime & Manga Recommendations", "Ask the community for series recommendations or help other users looking for suggestions.", null),
                        new ForumBoard(19, "Series Discussion", "Post in episode and chapter discussion threads or talk about specific anime and manga in their series' boards.",
                            new List<ForumBoard>(){ new ForumBoard(1, "Anime Series", null, null), new ForumBoard(4, "Manga Series", null, null)}),
                        new ForumBoard(1, "Anime Discussion", "General anime discussion that is not specific to any particular series.", null),
                        new ForumBoard(2, "Manga Discussion", "General manga discussion that is not specific to any particular series.", null),
                    }),
                    new ForumTopic("General",
                    new List<ForumBoard>()
                    {
                        new ForumBoard(8, "Introductions", "New to MyAnimeList? Introduce yourself here.", null),
                        new ForumBoard(7, "Games, Computers & Tech Support", "Discuss visual novels and other video games, or ask our community a computer related question.", null),
                        new ForumBoard(10, "Music & Entertainment", "Asian music and live-action series, Western media and artists, best-selling novels, etc.", null),
                        new ForumBoard(11, "Casual Discussion", "General interest topics that don't fall into one of the sub-categories above, such as community polls.", null),
                        new ForumBoard(12, "Creative Corner", "Show your creations to get help or feedback from our community. Graphics, list designs, stories; anything goes.", null),
                        new ForumBoard(9, "Forum Games", "Fun forum games are contained here.", null),
                    }),
                    new ForumTopic("Archive",
                    new List<ForumBoard>()
                    {
                        new ForumBoard(6, "Current Events", "World headlines, the latest in science, sports competitions, and other debate topics.", null)
                    })
                }
                ));

            WebApiResponse<ForumCategories>? actualReturn = _apiClient.GetForumBoards().Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn);
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void TestGetForumTopics()
        {
            WebApiResponse<Entity<Topic>>? expectedReturn = new WebApiResponse<Entity<Topic>>(
                new Entity<Topic>(
                    new List<Topic>
                    {
                        new Topic(516089, null, DateTime.Parse("2012-11-09T19:38:52+01:00"), new Username(94702, "Luna"), 1, DateTime.Parse("2013-12-10T09:59:25+01:00"), new Username(94702, "Luna"), false)
                    },
                    new Paging(null, "https://api.myanimelist.net/v2/forum/topics?offset=1&board_id=15&limit=1")
                    ));

            WebApiResponse<Entity<Topic>>? actualReturn = _apiClient.GetForumTopics(boardId: 15, limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn);
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void GetForumTopicDetails()
        {
            WebApiResponse<SingleEntity<TopicDetail>>? expectedReturn = new WebApiResponse<SingleEntity<TopicDetail>>(
                new SingleEntity<TopicDetail>(
                    new TopicDetail("News Discussion Rules",
                    new List<Post>
                    {
                        new Post(18240275, 1, DateTime.Parse("2012-11-09T19:38:52+01:00"), new Username(94702, "Luna", "★★★★★", "https://cdn.myanimelist.net/images/useravatars/94702.png?t=1735404600"), "[size=105][b][u]News Discussion Rules[/u][/b][/size]<br />\n<br />\nThe following rules apply only to the News Discussion board [b]in addition[/b] to the [url=https://myanimelist.net/forum/?topicid=516059]Site &amp; Forum Guidelines[/url] and take precedence whenever there is a conflict.<br />\n[list=1][*]Posts that merely consist of &quot;Will watch&quot;, &quot;Won&#039;t watch&quot;, &quot;Yay!&quot; etc. will be removed without notice. Try expanding on why you are or are not interested.[/list]", "[center][img]https://i.imgur.com/bVc98Ih.png[/img][/center]")
                    },
                    null),
                    new Paging()
                    ));

            WebApiResponse<SingleEntity<TopicDetail>>? actualReturn = _apiClient.GetForumTopicDetails(topicId: 516089).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn);
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        #endregion Forum

        #region Manga

        [Ignore("This test is ignored because the API returns different responses.")]
        [Test]
        public void TestGetMangaList()
        {
            WebApiResponse<Entity<AnimeMangaNode<Manga>>>? expectedReturn =
                new WebApiResponse<Entity<AnimeMangaNode<Manga>>>(
                    new Entity<AnimeMangaNode<Manga>>(
                        new List<AnimeMangaNode<Manga>>
                        {
                            new AnimeMangaNode<Manga>(new Manga("One Piece") { Id = 13, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/253146.jpg", "https://cdn.myanimelist.net/images/manga/2/253146l.jpg")}, default)
                        },
                        new Paging(null, "https://api.myanimelist.net/v2/manga?offset=1&q=one+piece&limit=1")
                        ));

            WebApiResponse<Entity<AnimeMangaNode<Manga>>>? actualReturn = _apiClient.GetMangaList("One Piece", limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Ignore("This test is ignored because the API returns different responses very frequently.")]
        [Test]
        public void TestGetMangaDetails()
        {
            WebApiResponse<Manga>? expectedReturn = new WebApiResponse<Manga>(
                new Manga(13, "One Piece", new Picture("https://cdn.myanimelist.net/images/manga/2/253146.jpg", "https://cdn.myanimelist.net/images/manga/2/253146l.jpg"),
                new List<Picture>
                {
                    new Picture("https://cdn.myanimelist.net/images/manga/3/55539.jpg", "https://cdn.myanimelist.net/images/manga/3/55539l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/2/55543.jpg", "https://cdn.myanimelist.net/images/manga/2/55543l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/2/55545.jpg", "https://cdn.myanimelist.net/images/manga/2/55545l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/2/55551.jpg", "https://cdn.myanimelist.net/images/manga/2/55551l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/1/55553.jpg", "https://cdn.myanimelist.net/images/manga/1/55553l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/2/59409.jpg", "https://cdn.myanimelist.net/images/manga/2/59409l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/3/192143.jpg", "https://cdn.myanimelist.net/images/manga/3/192143l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/1/192144.jpg", "https://cdn.myanimelist.net/images/manga/1/192144l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/5/192145.jpg", "https://cdn.myanimelist.net/images/manga/5/192145l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/3/250752.jpg", "https://cdn.myanimelist.net/images/manga/3/250752l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/1/252690.jpg", "https://cdn.myanimelist.net/images/manga/1/252690l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/2/253146.jpg", "https://cdn.myanimelist.net/images/manga/2/253146l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/1/262418.jpg", "https://cdn.myanimelist.net/images/manga/1/262418l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/5/262419.jpg", "https://cdn.myanimelist.net/images/manga/5/262419l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/4/262420.jpg", "https://cdn.myanimelist.net/images/manga/4/262420l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/5/262489.jpg", "https://cdn.myanimelist.net/images/manga/5/262489l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/1/262490.jpg", "https://cdn.myanimelist.net/images/manga/1/262490l.jpg"),
                    new Picture("https://cdn.myanimelist.net/images/manga/1/283560.jpg", "https://cdn.myanimelist.net/images/manga/1/283560l.jpg")
                },
                new AlternativeTitles(new List<string> { }, "One Piece", "ONE PIECE"), new DateTime(1997, 07, 22), null,
                "Gol D. Roger, a man referred to as the King of the Pirates, is set to be executed by the World Government. But just before his demise, he confirms the existence of a great treasure, One Piece, located somewhere within the vast ocean known as the Grand Line. Announcing that One Piece can be claimed by anyone worthy enough to reach it, the King of the Pirates is executed and the Great Age of Pirates begins.\n\nTwenty-two years later, a young man by the name of Monkey D. Luffy is ready to embark on his own adventure, searching for One Piece and striving to become the new King of the Pirates. Armed with just a straw hat, a small boat, and an elastic body, he sets out on a fantastic journey to gather his own crew and a worthy ship that will take them across the Grand Line to claim the greatest status on the high seas.\n\n[Written by MAL Rewrite]",
                9.22f, 4, 4, 646095, 394825, Nsfw.white, new List<Genre> { new Genre(1, "Action"), new Genre(2, "Adventure"), new Genre(10, "Fantasy"), new Genre(27, "Shounen") }, DateTime.Parse("1970-01-01T00:00:00+00:00"), DateTime.Parse("2024-08-02T23:49:24+00:00"), "manga",
                "One Piece is the highest-selling manga series of all time, with over 500 million copies in circulation as of 2022. Volume 67 of the series currently holds the record for highest first print run of any manga or book of all time in Japan, with 4.05 million in 2012. The series was a finalist for the Tezuka Osamu Cultural Prize three times in a row from 2000 to 2002. In 2012, it won the 41st Japan Cartoonists Association Award Grand Prize, alongside Kimuchi Yokoyama's Neko Darake.\n\nVIZ Media has published One Piece in English under the Shonen Jump imprint since January 2, 2003, and in 3-in-1 omnibus editions since December 1, 2009. VIZ Media has been publishing boxed sets for the manga since November 5, 2013. It has also been simulpub through MANGA Plus. The series has also been published in numerous amounts of languages worldwide including Korean, Malay, Indonesian, Chinese, Thai, Vietnamese, German, French, Italian, Spanish, Portuguese, Swedish, Danish, Norwegian, Finnish, Polish, Turkish, and Russian.\n\nThe manga has been adapted into a live-action TV series on Netflix since August 31, 2023.",
                "currently_publishing", null, null, null, null,
                new List<RelatedAnimeManga>(),
                new List<RelatedAnimeManga>()
                {
                    new RelatedAnimeManga(new AnimeMangaBase("Wanted!"){ Id = 793, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/170782.jpg", "https://cdn.myanimelist.net/images/manga/1/170782l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("Romance Dawn"){ Id = 5114, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/263631.jpg", "https://cdn.myanimelist.net/images/manga/1/263631l.jpg") }, "alternative_version", "Alternative version"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Strong World"){ Id = 17152, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/25743.jpg", "https://cdn.myanimelist.net/images/manga/1/25743l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Mugiwara Daigekijou"){ Id = 14414, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/273090.jpg", "https://cdn.myanimelist.net/images/manga/2/273090l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("Chopperman"){ Id = 52353, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/114119.jpg", "https://cdn.myanimelist.net/images/manga/1/114119l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("Chopperman: Yuke Yuke! Minna no Chopper-sensei"){ Id = 23251, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/65203.jpg", "https://cdn.myanimelist.net/images/manga/3/65203l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("Jisshoku! Akuma no Mi!!"){ Id = 25146, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/40484.jpg", "https://cdn.myanimelist.net/images/manga/2/40484l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("Cross Epoch"){ Id = 881, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/310862.jpg", "https://cdn.myanimelist.net/images/manga/2/310862l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Party"){ Id = 86972, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/165199.jpg", "https://cdn.myanimelist.net/images/manga/2/165199l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Taose! Kaizoku Ganzack"){ Id = 94533, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/178412.jpg", "https://cdn.myanimelist.net/images/manga/2/178412l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Loguetown-hen"){ Id = 94534, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/270719.jpg", "https://cdn.myanimelist.net/images/manga/3/270719l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("Shokugeki no Sanji"){ Id = 114760, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/265963.jpg", "https://cdn.myanimelist.net/images/manga/3/265963l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Koby-ni no Kobiyama - Uri Futatsunagi no Daihihou"){ Id = 115627, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/222839.jpg", "https://cdn.myanimelist.net/images/manga/1/222839l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("Koisuru One Piece"){ Id = 120401, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/222841.jpg", "https://cdn.myanimelist.net/images/manga/1/222841l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("Gekijouban One Piece: Stampede"){ Id = 120656, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/230439.jpg", "https://cdn.myanimelist.net/images/manga/1/230439l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Novel: Mugiwara Stories"){ Id = 110830, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/232215.jpg", "https://cdn.myanimelist.net/images/manga/2/232215l.jpg") }, "side_story", "Side story"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Novel: A"){ Id = 127114, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/232216.jpg", "https://cdn.myanimelist.net/images/manga/2/232216l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Gakuen"){ Id = 122305, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/233977.jpg", "https://cdn.myanimelist.net/images/manga/2/233977l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Vivi no Bouken"){ Id = 139972, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/249763.jpg", "https://cdn.myanimelist.net/images/manga/2/249763l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Novel: Law"){ Id = 141501, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/251912.jpg", "https://cdn.myanimelist.net/images/manga/1/251912l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Novel: Heroines"){ Id = 141511, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/251914.jpg", "https://cdn.myanimelist.net/images/manga/1/251914l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("Chin Piece"){ Id = 142771, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/253803.jpg", "https://cdn.myanimelist.net/images/manga/2/253803l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("Fischer's x One Piece: Nanatsunagi no Daihihou"){ Id = 142772, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/253804.jpg", "https://cdn.myanimelist.net/images/manga/2/253804l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece: Episode A"){ Id = 128594, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/266074.jpg", "https://cdn.myanimelist.net/images/manga/2/266074l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece 1000-wa Kinen! Tokubetsu Bangai-hen"){ Id = 150042, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/266234.jpg", "https://cdn.myanimelist.net/images/manga/3/266234l.jpg") }, "other", "Other"),
                    new RelatedAnimeManga(new AnimeMangaBase("Ore no Keikaku wa Zettai ni Kuruwanai!!"){ Id = 152411, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/298737.jpg", "https://cdn.myanimelist.net/images/manga/2/298737l.jpg") }, "spin_off", "Spin-off"),
                    new RelatedAnimeManga(new AnimeMangaBase("One Piece Card Battle Hobby Saikyou Kizuna Boost"){ Id = 172694, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/308149.jpg", "https://cdn.myanimelist.net/images/manga/1/308149l.jpg") }, "other", "Other")
                },
                new List<Recommendations>()
                {
                    new Recommendations(new AnimeMangaBase("Fairy Tail") { Id = 598, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/198604.jpg", "https://cdn.myanimelist.net/images/manga/3/198604l.jpg") }, 26),
                    new Recommendations(new AnimeMangaBase("Naruto") { Id = 11, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/249658.jpg", "https://cdn.myanimelist.net/images/manga/3/249658l.jpg") }, 15),
                    new Recommendations(new AnimeMangaBase("Hunter x Hunter") { Id = 26, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/253119.jpg", "https://cdn.myanimelist.net/images/manga/2/253119l.jpg") }, 12),
                    new Recommendations(new AnimeMangaBase("Kingdom") { Id = 16765, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/171872.jpg", "https://cdn.myanimelist.net/images/manga/2/171872l.jpg") }, 12),
                    new Recommendations(new AnimeMangaBase("Toriko") { Id = 7887, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/4/304295.jpg", "https://cdn.myanimelist.net/images/manga/4/304295l.jpg") }, 11),
                    new Recommendations(new AnimeMangaBase("Dragon Ball") { Id = 42, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/267793.jpg", "https://cdn.myanimelist.net/images/manga/1/267793l.jpg") }, 8),
                    new Recommendations(new AnimeMangaBase("Nanatsu no Taizai") { Id = 44485, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/153111.jpg", "https://cdn.myanimelist.net/images/manga/2/153111l.jpg") }, 6),
                    new Recommendations(new AnimeMangaBase("Bleach") { Id = 12, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/180031.jpg", "https://cdn.myanimelist.net/images/manga/3/180031l.jpg") }, 6),
                    new Recommendations(new AnimeMangaBase("Tower of God") { Id = 122663, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/2/223694.jpg", "https://cdn.myanimelist.net/images/manga/2/223694l.jpg") }, 6),
                    new Recommendations(new AnimeMangaBase("Magi") { Id = 14790, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/3/282487.jpg", "https://cdn.myanimelist.net/images/manga/3/282487l.jpg") }, 6)
                }, null)
                );

            WebApiResponse<Manga>? actualReturn = _apiClient.GetMangaDetails(13).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        [Test]
        public void TestGetMangaRanking()
        {
            WebApiResponse<Entity<AnimeMangaNode<Manga>>>? expectedReturn = new WebApiResponse<Entity<AnimeMangaNode<Manga>>>(
                new Entity<AnimeMangaNode<Manga>>(
                    new List<AnimeMangaNode<Manga>>
                    {
                        new AnimeMangaNode<Manga>(new Manga("Berserk") { Id = 2, MainPicture = new Picture("https://cdn.myanimelist.net/images/manga/1/157897.jpg", "https://cdn.myanimelist.net/images/manga/1/157897l.jpg")}, new Ranking(1, null))
                    },
                    new Paging(null, "https://api.myanimelist.net/v2/manga/ranking?offset=1&limit=1&ranking_type=all")
                    ));

            WebApiResponse<Entity<AnimeMangaNode<Manga>>>? actualReturn = _apiClient.GetMangaRanking(RankingType.All, limit: 1).Result;

            string jsonActual = JsonConvert.SerializeObject(actualReturn).Replace(".webp", ".jpg");
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }

        #endregion Manga

        #region User
        [Ignore("This test is ignored because the API returns different responses very frequently.")]
        [Test]
        public void TestGetMyUserInformation()
        {
            WebApiResponse<UserInformation>? expectedReturn = new WebApiResponse<UserInformation>(
                new UserInformation(1, "USER", null, null, "2000-01-01", string.Empty, "2021-03-05T23:12:31+00:00", 
                    new AnimeUserStatistics(6, 37, 1, 2, 0, 46, 44.63f, 16.81f, 27.65f, 0.0f, 0.17f, 44.63f, 2669, 0, 7.5f), null, null));

            WebApiResponse<UserInformation>? actualReturn = _apiClient.GetMyUserInformation().Result;

            if (actualReturn?.Records != null)
            {
                actualReturn.Records.Id = 1;
                actualReturn.Records.Name = "USER";
                actualReturn.Records.Birthday = "2000-01-01";
            }

            string jsonActual = JsonConvert.SerializeObject(actualReturn);
            string jsonExpected = JsonConvert.SerializeObject(expectedReturn);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }
        #endregion User

    }
}