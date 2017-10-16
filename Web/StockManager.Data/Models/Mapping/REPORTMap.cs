using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class REPORTMap : EntityTypeConfiguration<REPORT>
    {
        public REPORTMap()
        {
            // Primary Key
            this.HasKey(t => t.Report_ID);

            // Properties
            this.Property(t => t.Report_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Report_Name)
                .HasMaxLength(255);

            this.Property(t => t.Title)
                .HasMaxLength(255);

            this.Property(t => t.Comment)
                .HasMaxLength(255);

            this.Property(t => t.FileName)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.DataSet)
                .HasMaxLength(50);

            this.Property(t => t.Class)
                .HasMaxLength(50);

            this.Property(t => t.Parent_ID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("REPORT");
            this.Property(t => t.Report_ID).HasColumnName("Report_ID");
            this.Property(t => t.Report_Name).HasColumnName("Report_Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DataSet).HasColumnName("DataSet");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.Parent_ID).HasColumnName("Parent_ID");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.Avtive).HasColumnName("Avtive");
        }
    }
}
