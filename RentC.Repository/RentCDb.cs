using System.Data.Entity;
using System.Data.SqlClient;
using RentC.Model;

namespace RentC.Repository
{
    public class RentCDb : DbContext
    {
        // Build connection string
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "DESKTOP-A0CPMR3\\SQLEXPRESS",
            InitialCatalog = "academy_net",
            IntegratedSecurity = true,
            MultipleActiveResultSets = true
        };

        public RentCDb()
        {
            Database.SetInitializer<RentCDb>(new CreateDatabaseIfNotExists<RentCDb>());
            Database.Connection.ConnectionString = builder.ConnectionString;
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationStatuses> ReservationStatuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolesPermission> RolesPermissions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
