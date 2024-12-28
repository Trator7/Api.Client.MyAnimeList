using Newtonsoft.Json;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements
{
    public class Status
    {
        public int Watching { get; set; }
        public int Completed { get; set; }
        [JsonProperty("on_hold")]
        public int OnHold { get; set; }
        public int Dropped { get; set; }
        [JsonProperty("plan_to_watch")]
        public int PlanToWatch { get; set; }

        public Status(int watching, int completed, int onHold, int dropped, int planToWatch)
        {
            Watching = watching;
            Completed = completed;
            OnHold = onHold;
            Dropped = dropped;
            PlanToWatch = planToWatch;
        }
    }
}
