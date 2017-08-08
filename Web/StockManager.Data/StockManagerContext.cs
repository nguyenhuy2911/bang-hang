using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StockManager.Data.Models.Mapping;
using StockManager.Entity;

namespace StockManager.Data
{
    public partial class StockManagerContext : DbContext
    {
        static StockManagerContext()
        {
            //     Database.SetInitializer<StockManagerContext>(null);
        }

        public StockManagerContext() : base("Name=SellManager")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<ADJUSTMENT> AdjustMents { get; set; }
        public DbSet<ADJUSTMENT_DETAIL> AdjustMent_Details { get; set; }
        public DbSet<BOOK> Books { get; set; }
        public DbSet<CURRENCY> Currencies { get; set; }
        public DbSet<CUSTOMER> Customers { get; set; }
        public DbSet<CUSTOMER_GROUP> Customer_Groups { get; set; }
        public DbSet<CUSTOMER_TYPE> Customer_Types { get; set; }
        public DbSet<DEPARTMENT> Departments { get; set; }
        public DbSet<EMPLOYEE> Employees { get; set; }
        public DbSet<FORM> Forms { get; set; }
        public DbSet<INVENTORY> Inventories { get; set; }
        public DbSet<INVENTORY_DETAIL> Inventory_Details { get; set; }
        public DbSet<PRODUCT> Products { get; set; }
        public DbSet<PRODUCT_BUILD> Product_Builds { get; set; }
        public DbSet<PRODUCT_GROUP> Product_Groups { get; set; }
        public DbSet<PRODUCT_PRICE> Product_Prices { get; set; }
        public DbSet<PRODUCT_TYPE> Product_Types { get; set; }
        public DbSet<PRODUCT_UNIT> Product_Units { get; set; }
        public DbSet<PROVIDER> Providers { get; set; }
        public DbSet<REFTYPE> RefTypes { get; set; }
        public DbSet<REPORT> Reports { get; set; }
        public DbSet<REPORT_GROUP> Report_Group { get; set; }
        public DbSet<STOCK> Stocks { get; set; }
        public DbSet<STOCK_BUILD> Stock_Builds { get; set; }
        public DbSet<STOCK_BUILD_DETAIL> Stock_Build_Details { get; set; }
        public DbSet<STOCK_INWARD> Stock_Inwards { get; set; }
        public DbSet<STOCK_INWARD_DETAIL> Stock_InWard_Details { get; set; }
        public DbSet<STOCK_OUTWARD> Stock_OutWards { get; set; }
        public DbSet<STOCK_OUTWARD_DETAIL> Stock_OutWard_Details { get; set; }
        public DbSet<STOCK_TRANSFER> Stock_Transfers { get; set; }
        public DbSet<STOCK_TRANSFER_DETAIL> Stock_Transfer_Details { get; set; }
        public DbSet<SYS_COMPANY> Sys_Companys { get; set; }
        public DbSet<SYS_GROUP> Sys_Groups { get; set; }
        public DbSet<SYS_GROUP_OBJECT> Sys_Group_Objects { get; set; }
        public DbSet<SYS_INFO> Sys_Infos { get; set; }
        public DbSet<SYS_LOG> Sys_Logs { get; set; }
        public DbSet<SYS_OBJECT> Sys_Objects { get; set; }
        public DbSet<SYS_OPTION> Sys_Options { get; set; }
        public DbSet<SYS_RULE> Sys_Rules { get; set; }
        public DbSet<SYS_USER> Sys_Users { get; set; }
        public DbSet<SYS_USER_RULE> Sys_User_Rules { get; set; }
        public DbSet<sysdiagram> SysDiagrams { get; set; }
        public DbSet<TRANS_REF> Trans_Refs { get; set; }
        public DbSet<UNIT> Units { get; set; }
        public DbSet<UNITCONVERT> UnitConverts { get; set; }

        public virtual int Commit()
        {
            int result = base.SaveChanges();
            return result;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ADJUSTMENTMap());
            modelBuilder.Configurations.Add(new ADJUSTMENT_DETAILMap());
            modelBuilder.Configurations.Add(new BOOKMap());
            modelBuilder.Configurations.Add(new CURRENCYMap());
            modelBuilder.Configurations.Add(new CUSTOMERMap());
            modelBuilder.Configurations.Add(new CUSTOMER_GROUPMap());
            modelBuilder.Configurations.Add(new CUSTOMER_TYPEMap());
            modelBuilder.Configurations.Add(new DEPARTMENTMap());
            modelBuilder.Configurations.Add(new EMPLOYEEMap());
            modelBuilder.Configurations.Add(new FORMMap());
            modelBuilder.Configurations.Add(new INVENTORYMap());
            modelBuilder.Configurations.Add(new INVENTORY_DETAILMap());
            modelBuilder.Configurations.Add(new PRODUCTMap());
            modelBuilder.Configurations.Add(new PRODUCT_BUILDMap());
            modelBuilder.Configurations.Add(new PRODUCT_GROUPMap());
            modelBuilder.Configurations.Add(new PRODUCT_PRICEMap());
            modelBuilder.Configurations.Add(new PRODUCT_TYPEMap());
            modelBuilder.Configurations.Add(new PRODUCT_UNITMap());
            modelBuilder.Configurations.Add(new PROVIDERMap());
            modelBuilder.Configurations.Add(new REFTYPEMap());
            modelBuilder.Configurations.Add(new REPORTMap());
            modelBuilder.Configurations.Add(new REPORT_GROUPMap());
            modelBuilder.Configurations.Add(new STOCKMap());
            modelBuilder.Configurations.Add(new STOCK_BUILDMap());
            modelBuilder.Configurations.Add(new STOCK_BUILD_DETAILMap());
            modelBuilder.Configurations.Add(new STOCK_INWARDMap());
            modelBuilder.Configurations.Add(new STOCK_INWARD_DETAILMap());
            modelBuilder.Configurations.Add(new STOCK_OUTWARDMap());
            modelBuilder.Configurations.Add(new STOCK_OUTWARD_DETAILMap());
            modelBuilder.Configurations.Add(new STOCK_TRANSFERMap());
            modelBuilder.Configurations.Add(new STOCK_TRANSFER_DETAILMap());
            modelBuilder.Configurations.Add(new SYS_COMPANYMap());
            modelBuilder.Configurations.Add(new SYS_GROUPMap());
            modelBuilder.Configurations.Add(new SYS_GROUP_OBJECTMap());
            modelBuilder.Configurations.Add(new SYS_INFOMap());
            modelBuilder.Configurations.Add(new SYS_LOGMap());
            modelBuilder.Configurations.Add(new SYS_OBJECTMap());
            modelBuilder.Configurations.Add(new SYS_OPTIONMap());
            modelBuilder.Configurations.Add(new SYS_RULEMap());
            modelBuilder.Configurations.Add(new SYS_USERMap());
            modelBuilder.Configurations.Add(new SYS_USER_RULEMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TRANS_REFMap());
            modelBuilder.Configurations.Add(new UNITMap());
            modelBuilder.Configurations.Add(new UNITCONVERTMap());
        }
    }
}
