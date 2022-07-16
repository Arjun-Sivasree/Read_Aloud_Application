using Microsoft.EntityFrameworkCore;
using Read_aloud_webapi.Models;

namespace Read_aloud_webapi.Persistence
{
    public class ReadAloudContext : DbContext
    {
        public ReadAloudContext(DbContextOptions<ReadAloudContext> options) : base(options)
        {

        }

        public DbSet<Member>? Members { get; set; }
    }
}