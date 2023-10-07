namespace NewProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transfer")]
    public partial class Transfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransferID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpireDate { get; set; }

        public int? FK_SupplierID { get; set; }

        public int? FK_ProductID { get; set; }

        public int? FK_FromStoreID { get; set; }

        public int? FK_ToStoreID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Store Store { get; set; }

        public virtual Store Store1 { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
