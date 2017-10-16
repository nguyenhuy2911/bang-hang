using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class SYS_LOGMap : EntityTypeConfiguration<SYS_LOG>
    {
        public SYS_LOGMap()
        {
            // Primary Key
            this.HasKey(t => t.SYS_ID);

            // Properties
            this.Property(t => t.MChine)
                .HasMaxLength(200);

            this.Property(t => t.AccountWin)
                .HasMaxLength(50);

            this.Property(t => t.UserID)
                .HasMaxLength(20);

            this.Property(t => t.UserName)
                .HasMaxLength(100);

            this.Property(t => t.Module)
                .HasMaxLength(200);

            this.Property(t => t.Action_Name)
                .HasMaxLength(50);

            this.Property(t => t.Reference)
                .HasMaxLength(20);

            this.Property(t => t.IPLan)
                .HasMaxLength(20);

            this.Property(t => t.IPWan)
                .HasMaxLength(30);

            this.Property(t => t.Mac)
                .HasMaxLength(40);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("SYS_LOG");
            this.Property(t => t.SYS_ID).HasColumnName("SYS_ID");
            this.Property(t => t.MChine).HasColumnName("MChine");
            this.Property(t => t.AccountWin).HasColumnName("AccountWin");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Module).HasColumnName("Module");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Action_Name).HasColumnName("Action_Name");
            this.Property(t => t.Reference).HasColumnName("Reference");
            this.Property(t => t.VoucherDate).HasColumnName("VoucherDate");
            this.Property(t => t.IPLan).HasColumnName("IPLan");
            this.Property(t => t.IPWan).HasColumnName("IPWan");
            this.Property(t => t.Mac).HasColumnName("Mac");
            this.Property(t => t.DeviceName).HasColumnName("DeviceName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
