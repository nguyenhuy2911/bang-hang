using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class PRODUCT_TYPEMap : EntityTypeConfiguration<PRODUCT_TYPE>
    {
        public PRODUCT_TYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.Product_Type_ID);

            // Properties
            this.Property(t => t.Product_Type_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Product_Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PRODUCT_TYPE");
            this.Property(t => t.Product_Type_ID).HasColumnName("Product_Type_ID");
            this.Property(t => t.Product_Name).HasColumnName("Product_Name");
        }
    }
}
