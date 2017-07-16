using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class REPORT_GROUPMap : EntityTypeConfiguration<REPORT_GROUP>
    {
        public REPORT_GROUPMap()
        {
            // Primary Key
            this.HasKey(t => t.Report_Group_ID);

            // Properties
            this.Property(t => t.Report_Group_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Report_Group_Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("REPORT_GROUP");
            this.Property(t => t.Report_Group_ID).HasColumnName("Report_Group_ID");
            this.Property(t => t.Report_Group_Name).HasColumnName("Report_Group_Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
