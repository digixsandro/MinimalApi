using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Db
{
    public class PartDb : DbContext
    {
        public PartDb(DbContextOptions options) : base(options)  {  }
        public DbSet<Part> Parts { get; set; } = null!;

        public DbSet<Word> Words { get; set; } = null!;
    }
}
