using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class ImagesMap: EntityTypeConfiguration<Images>
    {
        public ImagesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            this.Property(t => t.Name)
                .HasMaxLength(50);
            this.Property(t => t.Path)
               .HasMaxLength(250);
            this.Property(t => t.Type)               
               .HasMaxLength(10);
            this.Property(t => t.RelateId)
               .HasMaxLength(50);
            // Table & Column Mappings
            this.ToTable("Images");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.RelateId).HasColumnName("RelateId");
        }
    }
}
