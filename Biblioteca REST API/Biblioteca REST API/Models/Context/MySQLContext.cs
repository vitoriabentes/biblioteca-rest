using Microsoft.EntityFrameworkCore;

namespace Biblioteca_REST_API.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){ }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
