using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Miscellaneous
{
    [Table("exception_logs")]
    public class ExceptionLog
    {
        [Key]
        public int Id { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int HResult { get; set; }
        public DateTime Date { get; set; }
        public string Request { get; set; }
    }
}
