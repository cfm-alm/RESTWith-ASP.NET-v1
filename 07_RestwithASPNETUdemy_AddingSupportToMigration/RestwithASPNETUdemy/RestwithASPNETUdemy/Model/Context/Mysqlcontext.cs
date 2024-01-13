using Microsoft.EntityFrameworkCore;

namespace RestwithASPNETUdemy.Model.Context
{
    public class Mysqlcontext : DbContext
    {
        public Mysqlcontext()
        {

        }
        public Mysqlcontext(DbContextOptions<Mysqlcontext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
