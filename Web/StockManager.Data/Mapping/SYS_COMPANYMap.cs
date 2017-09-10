using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class SYS_COMPANYMap : EntityTypeConfiguration<SYS_COMPANY>
    {
        public SYS_COMPANYMap()
        {
            // Primary Key
            this.HasKey(t => t.Company_Id);

            // Properties
            this.Property(t => t.Company_Id)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Company)
                .HasMaxLength(250);

            this.Property(t => t.Address)
                .HasMaxLength(250);

            this.Property(t => t.Tel)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.WebSite)
                .HasMaxLength(250);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Tax)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SYS_COMPANY");
            this.Property(t => t.Company_Id).HasColumnName("Company_Id");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.WebSite).HasColumnName("WebSite");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Tax).HasColumnName("Tax");
            this.Property(t => t.Licence).HasColumnName("Licence");
            this.Property(t => t.Photo).HasColumnName("Photo");
        }
    }
}
