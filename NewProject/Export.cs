namespace NewProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Export")]
    public partial class Export
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Export()
        {
            ExportLogs = new HashSet<ExportLog>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExportID { get; set; }

        [StringLength(50)]
        public string Serial { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? FK_StoreID { get; set; }

        public int? FK_CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportLog> ExportLogs { get; set; }
    }
}
