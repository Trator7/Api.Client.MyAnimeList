namespace Api.Client.MyAnimeList.Entity.Base
{
    public class SingleEntity<T>
    {
        public static IEnumerable<string> DATETIME_FORMATS = ["yyyy-MM-ddTHH:mm:ss", "yyyy-MM-dd", "yyyy-MM", "yyyy"];

        public T Data { get; set; }
        public Paging Paging { get; set; }

        public SingleEntity(T data, Paging paging)
        {
            Data = data;
            Paging = paging;
        }
    }
}