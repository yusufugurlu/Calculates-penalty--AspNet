using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Veripark.Entities.Models.Mapping
{
    public class CountryHolidayMap : EntityTypeConfiguration<CountryHoliday>
    {
        public CountryHolidayMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CountryHoliday");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.Holiday).HasColumnName("Holiday");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.CountryHolidays)
                .HasForeignKey(d => d.CountryID);

        }
    }
}
