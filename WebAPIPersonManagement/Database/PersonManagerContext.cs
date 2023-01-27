using Microsoft.EntityFrameworkCore;
using WebAPIPersonManagement.Models;

namespace WebAPIPersonManagement.Database
{
    public class PersonManagerContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }

        public PersonManagerContext(DbContextOptions options) : base(options)
        {

        }

    }
}
