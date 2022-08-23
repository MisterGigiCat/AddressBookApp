using AddressBookApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AddressBookApp.Data
{
    public class AddressBookAppDbContext : DbContext
    {
        public AddressBookAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Address> Addresses { get; set; }
    }
}
