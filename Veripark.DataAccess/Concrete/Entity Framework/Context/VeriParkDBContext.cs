using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Veripark.Entities.Models.Mapping;

namespace Veripark.Entities.Models
{
    public partial class VeriParkDBContext : DbContext
    {
        static VeriParkDBContext()
        {
            Database.SetInitializer<VeriParkDBContext>(null);
        }

        public VeriParkDBContext()
            : base("Name=VeriParkDBContext")
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryHoliday> CountryHolidays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CountryHolidayMap());
        }
    }
}
