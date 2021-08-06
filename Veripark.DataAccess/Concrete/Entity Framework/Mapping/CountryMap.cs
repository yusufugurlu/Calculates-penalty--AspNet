using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Veripark.Entities.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CountryName)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Country");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
        }
    }
}
