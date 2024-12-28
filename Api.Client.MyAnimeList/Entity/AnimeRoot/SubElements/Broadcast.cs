using Newtonsoft.Json;
using System.Globalization;

namespace Api.Client.MyAnimeList.Entity.AnimeRoot.SubElements
{
    /// <summary>
    /// Represents the day of the week and time that an anime is broadcast in Japan time.
    /// </summary>
    public class Broadcast
    {
        public const string TIME_FORMAT = @"hh\:mm";

        [JsonProperty("day_of_the_week")]
        public string DayOfTheWeek { get; set; }
        [JsonProperty("start_time")]
        public TimeSpan StartTime { get; set; }

        public Broadcast(string dayOfTheWeek, string? time)
        {
            DayOfTheWeek = dayOfTheWeek;

            if (TimeSpan.TryParseExact(time, TIME_FORMAT, CultureInfo.InvariantCulture, out TimeSpan tmp))
            {
                StartTime = tmp;
            }
        }
    }
}
