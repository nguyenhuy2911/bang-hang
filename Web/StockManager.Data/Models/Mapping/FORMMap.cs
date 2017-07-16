using StockManager.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StockManager.Data.Models.Mapping
{
    public class FORMMap : EntityTypeConfiguration<FORM>
    {
        public FORMMap()
        {
            // Primary Key
            this.HasKey(t => t.Form_Id);

            // Properties
            this.Property(t => t.Form_Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Form_Caption)
                .HasMaxLength(255);

            this.Property(t => t.ENCaption)
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("FORM");
            this.Property(t => t.Form_Id).HasColumnName("Form_Id");
            this.Property(t => t.Form_Caption).HasColumnName("Form_Caption");
            this.Property(t => t.ENCaption).HasColumnName("ENCaption");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
