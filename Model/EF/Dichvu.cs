namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dichvu")]
    public partial class Dichvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dichvu()
        {
            DichvuNccs = new HashSet<DichvuNcc>();
            LichtrinhDVNCCs = new HashSet<LichtrinhDVNCC>();
        }

        public int DichvuID { get; set; }

        [StringLength(50)]
        public string DichvuName { get; set; }

        [StringLength(250)]
        public string DichvuMota { get; set; }

        public double? Dongia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichvuNcc> DichvuNccs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichtrinhDVNCC> LichtrinhDVNCCs { get; set; }
    }
}
