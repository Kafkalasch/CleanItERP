using Microsoft.EntityFrameworkCore;

namespace CleanItERP.DataModel
{
    public class CleanItERPContext : DbContext
    {

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Textile> Textiles { get; set; }
        public DbSet<TextileState> TextileStates { get; set; }
        public DbSet<TextileType> TextileTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public CleanItERPContext(DbContextOptions<CleanItERPContext> options)
            : base(options)
        {

        }

    }
}