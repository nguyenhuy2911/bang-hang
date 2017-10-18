using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManager.Data.Model.Data
{
    [Table("UNIT")]
    public partial class UNIT
    {
        public UNIT()
        {
            this.PRODUCTs = new List<PRODUCT>();
          //  this.PRODUCT_UNIT = new List<PRODUCT_UNIT>();
        }
        [Key]
        [MaxLength(20)]
        public string Unit_ID { get; set; }

        [MaxLength(250)]
        public string Unit_Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }
      //  public virtual ICollection<PRODUCT_UNIT> PRODUCT_UNIT { get; set; }
    }
}
