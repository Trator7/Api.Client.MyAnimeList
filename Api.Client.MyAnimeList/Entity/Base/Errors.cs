namespace Api.Client.MyAnimeList.Entity.Base
{
    public class Errors
    {
        public string Error { get; set; }
        public string Message { get; set; }

        public Errors(string error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
