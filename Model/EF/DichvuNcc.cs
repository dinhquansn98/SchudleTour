namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichvuNcc")]
    public partial class DichvuNcc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichvuNcc()
        {
            LichtrinhDVNCCs = new HashSet<LichtrinhDVNCC>();
        }

        [Key]
        public int IDDichvuNcc { get; set; }

        public int? DichvuID { get; set; }

        public int? NccID { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public virtual Dichvu Dichvu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichtrinhDVNCC> LichtrinhDVNCCs { get; set; }

        public virtual Nhacungcap Nhacungcap { get; set; }
    }
}
