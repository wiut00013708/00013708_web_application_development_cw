using _00013708_web_application_api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace _00013708_web_application_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    }
}
