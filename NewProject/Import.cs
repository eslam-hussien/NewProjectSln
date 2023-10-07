namespace NewProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Import")]
    public partial class Import
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Import()
        {
            ImportLogs = new HashSet<ImportLog>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImportID { get; set; }

        [StringLength(50)]
        public string Serial { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? FK_StoreID { get; set; }

        public virtual Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportLog> ImportLogs { get; set; }
    }
}
