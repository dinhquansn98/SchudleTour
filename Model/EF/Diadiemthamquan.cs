namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diadiemthamquan")]
    public partial class Diadiemthamquan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diadiemthamquan()
        {
            ThoigianCCDDs = new HashSet<ThoigianCCDD>();
        }

        [Key]
        public int DiadiemID { get; set; }

        [StringLength(50)]
        public string DiadiemName { get; set; }

        public double? Dongia { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public int? Idddiachi { get; set; }

        public virtual Diachi Diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoigianCCDD> ThoigianCCDDs { get; set; }
    }
}
