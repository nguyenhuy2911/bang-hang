using StockManager.Data.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.Models.Mapping
{
    public class Product_Type_AttributeMap : EntityTypeConfiguration<ProductType_Attribute>
    {
        public Product_Type_AttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            //  Properties
            this.Property(t => t.Id)
                .IsRequired();

            this.Property(t => t.ProductType_Id)
                .IsRequired();

            this.Property(t => t.Attribute_Id)
                .IsRequired();

            //Table
            this.ToTable("ProductType_Attribute");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductType_Id).HasColumnName("ProductType_Id");
            this.Property(t => t.Attribute_Id).HasColumnName("Attribute_Id");
            
            // Relationships
            //this.HasOptional(t => t.Product_Type)
            //    .WithMany(t => t.ProductType_Attributes)
            //    .HasForeignKey(d => d.ProductType_Id);

            //this.HasOptional(t => t.Attribute)
            //    .WithMany(t => t.ProductType_Attributes)
            //    .HasForeignKey(d => d.Attribute_Id);
        }

    }
}
