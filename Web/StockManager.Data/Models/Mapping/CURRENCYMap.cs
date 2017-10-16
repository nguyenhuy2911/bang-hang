using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class CURRENCYMap : EntityTypeConfiguration<CURRENCY>
    {
        public CURRENCYMap()
        {
            // Primary Key
            this.HasKey(t => t.Currency_ID);

            // Properties
            this.Property(t => t.Currency_ID)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.CurrencyName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CURRENCY");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.CurrencyName).HasColumnName("CurrencyName");
            this.Property(t => t.Exchange).HasColumnName("Exchange");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
