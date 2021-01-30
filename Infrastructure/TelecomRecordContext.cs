using DataAnalyze.Net.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAnalyze.Net.Infrastructure
{
    public class TelecomRecordContext : DbContext
    {
        public DbSet<TelecomRecord> TelecomRecord { get; set; }

        public TelecomRecordContext(DbContextOptions<TelecomRecordContext> options) : base(options)
        {
        }
    }
}