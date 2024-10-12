using Domain.Entity.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    public partial class DataContext
    {
       public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}