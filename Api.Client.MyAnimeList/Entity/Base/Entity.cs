namespace Api.Client.MyAnimeList.Entity.Base
{
    public class Entity<T>
    {
        public static IEnumerable<string> DATETIME_FORMATS = ["yyyy-MM-ddTHH:mm:ss", "yyyy-MM-dd", "yyyy-MM", "yyyy"];

        public List<T> Data { get; set; }
        public Paging Paging { get; set; }

        public Entity(List<T> data, Paging paging)
        {
            Data = data;
            Paging = paging;
        }
    }
}