namespace Shared.DTOs
{
    public class ExceptionLogDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int HResult { get; set; }
        public DateTime Date { get; set; }
        public string Request { get; set; }
    }
}
