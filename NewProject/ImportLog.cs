namespace NewProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportLog")]
    public partial class ImportLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImportLogID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpireDate { get; set; }

        public int FK_SupplierID { get; set; }

        public int FK_ProductID { get; set; }

        public int? FK_Import { get; set; }

        public virtual Import Import { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
