namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lichtrinh")]
    public partial class Lichtrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lichtrinh()
        {
            ThoigianCCDDs = new HashSet<ThoigianCCDD>();
            LichtrinhDVNCCs = new HashSet<LichtrinhDVNCC>();
        }

        public int? LichtrinhID { get; set; }

        [StringLength(50)]
        public string lichtrinhName { get; set; }

        [StringLength(250)]
        public string LichtrinhMoTa { get; set; }

        public int? TourID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoigianCCDD> ThoigianCCDDs { get; set; }
        public virtual ICollection<LichtrinhDVNCC> LichtrinhDVNCCs { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
