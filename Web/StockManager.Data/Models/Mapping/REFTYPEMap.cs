using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class REFTYPEMap : EntityTypeConfiguration<REFTYPE>
    {
        public REFTYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.NameEN)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("REFTYPE");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameEN).HasColumnName("NameEN");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.IsSearch).HasColumnName("IsSearch");
        }
    }
}
