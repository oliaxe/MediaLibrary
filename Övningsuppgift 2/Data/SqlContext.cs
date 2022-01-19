using Microsoft.EntityFrameworkCore;
using Övningsuppgift_2.Models;

namespace Övningsuppgift_2.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }

    }
}
