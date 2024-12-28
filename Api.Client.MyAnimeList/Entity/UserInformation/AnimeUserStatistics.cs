using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.UserInformation
{
    public class AnimeUserStatistics
    {
        [JsonProperty("num_items_watching")]
        public int NumItemsWatching { get; set; }
        [JsonProperty("num_items_completed")]
        public int NumItemsCompleted { get; set; }
        [JsonProperty("num_items_on_hold")]
        public int NumItemsOnHold { get; set; }
        [JsonProperty("num_items_dropped")]
        public int NumItemsDropped { get; set; }
        [JsonProperty("num_items_plan_to_watch")]
        public int NumItemsPlanToWatch { get; set; }
        [JsonProperty("num_items")]
        public int NumItems { get; set; }
        [JsonProperty("num_days_watched")]
        public float NumDaysWatched { get; set; }
        [JsonProperty("num_days_watching")]
        public float NumDaysWatching { get; set; }
        [JsonProperty("num_days_completed")]
        public float NumDaysCompleted { get; set; }
        [JsonProperty("num_days_on_hold")]
        public float NumDaysOnHold { get; set; }
        [JsonProperty("num_days_dropped")]
        public float NumDaysDropped { get; set; }
        [JsonProperty("num_days")]
        public float NumDays { get; set; }
        [JsonProperty("num_episodes")]
        public int NumEpisodes { get; set; }
        [JsonProperty("num_times_rewatched")]
        public int NumTimesRewatched { get; set; }
        [JsonProperty("mean_score")]
        public float MeanScore { get; set; }

        public AnimeUserStatistics(
            int numItemsWatching, int numItemsCompleted, int numItemsOnHold, int numItemsDropped, int numItemsPlanToWatch, int numItems,
            float numDaysWatched, float numDaysWatching, float numDaysCompleted, float numDaysOnHold, float numDaysDropped, float numDays,
            int numEpisodes, int numTimesRewatched, float meanScore)
        {
            NumItemsWatching = numItemsWatching;
            NumItemsCompleted = numItemsCompleted;
            NumItemsOnHold = numItemsOnHold;
            NumItemsDropped = numItemsDropped;
            NumItemsPlanToWatch = numItemsPlanToWatch;
            NumItems = numItems;
            NumDaysWatched = numDaysWatched;
            NumDaysWatching = numDaysWatching;
            NumDaysCompleted = numDaysCompleted;
            NumDaysOnHold = numDaysOnHold;
            NumDaysDropped = numDaysDropped;
            NumDays = numDays;
            NumEpisodes = numEpisodes;
            NumTimesRewatched = numTimesRewatched;
            MeanScore = meanScore;
        }
    }
}
