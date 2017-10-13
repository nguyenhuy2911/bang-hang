using StockManager.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class EMPLOYEEMap : EntityTypeConfiguration<EMPLOYEE>
    {
        public EMPLOYEEMap()
        {
            // Primary Key
            this.HasKey(t => t.Employee_ID);

            // Properties
            this.Property(t => t.Employee_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FirtName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Employee_Name)
                .HasMaxLength(100);

            this.Property(t => t.Alias)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(255);

            this.Property(t => t.Country_ID)
                .HasMaxLength(20);

            this.Property(t => t.H_Tel)
                .HasMaxLength(20);

            this.Property(t => t.O_Tel)
                .HasMaxLength(20);

            this.Property(t => t.Mobile)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.Position_ID)
                .HasMaxLength(20);

            this.Property(t => t.JobTitle_ID)
                .HasMaxLength(20);

            this.Property(t => t.Branch_ID)
                .HasMaxLength(20);

            this.Property(t => t.Department_ID)
                .HasMaxLength(20);

            this.Property(t => t.Team_ID)
                .HasMaxLength(20);

            this.Property(t => t.PersonalTax_ID)
                .HasMaxLength(50);

            this.Property(t => t.City_ID)
                .HasMaxLength(20);

            this.Property(t => t.District_ID)
                .HasMaxLength(20);

            this.Property(t => t.Manager_ID)
                .HasMaxLength(20);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(20);

            this.Property(t => t.OwnerID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("EMPLOYEE");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.FirtName).HasColumnName("FirtName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Employee_Name).HasColumnName("Employee_Name");
            this.Property(t => t.Alias).HasColumnName("Alias");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Country_ID).HasColumnName("Country_ID");
            this.Property(t => t.H_Tel).HasColumnName("H_Tel");
            this.Property(t => t.O_Tel).HasColumnName("O_Tel");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.Married).HasColumnName("Married");
            this.Property(t => t.Position_ID).HasColumnName("Position_ID");
            this.Property(t => t.JobTitle_ID).HasColumnName("JobTitle_ID");
            this.Property(t => t.Branch_ID).HasColumnName("Branch_ID");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.Team_ID).HasColumnName("Team_ID");
            this.Property(t => t.PersonalTax_ID).HasColumnName("PersonalTax_ID");
            this.Property(t => t.City_ID).HasColumnName("City_ID");
            this.Property(t => t.District_ID).HasColumnName("District_ID");
            this.Property(t => t.Manager_ID).HasColumnName("Manager_ID");
            this.Property(t => t.EmployeeType).HasColumnName("EmployeeType");
            this.Property(t => t.BasicSalary).HasColumnName("BasicSalary");
            this.Property(t => t.Advance).HasColumnName("Advance");
            this.Property(t => t.AdvanceOther).HasColumnName("AdvanceOther");
            this.Property(t => t.Commission).HasColumnName("Commission");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.ProfitRate).HasColumnName("ProfitRate");
            this.Property(t => t.IsPublic).HasColumnName("IsPublic");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.OwnerID).HasColumnName("OwnerID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
