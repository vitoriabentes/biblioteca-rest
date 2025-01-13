using Microsoft.EntityFrameworkCore;

namespace Biblioteca_REST_API.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){ }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<T> Persons { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}
