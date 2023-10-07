namespace NewProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExportLog")]
    public partial class ExportLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExportLogID { get; set; }

        public int? Quantity { get; set; }

        public int? FK_ExportID { get; set; }

        public int? FK_SupplierID { get; set; }

        public int? FK_ProductID { get; set; }

        public virtual Export Export { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
