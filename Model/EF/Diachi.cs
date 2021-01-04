namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diachi")]
    public partial class Diachi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diachi()
        {
            Nhacungcaps = new HashSet<Nhacungcap>();
            Diadiemthamquans = new HashSet<Diadiemthamquan>();
            Thanhviens = new HashSet<Thanhvien>();
        }

        [Key]
        public int IDdiachi { get; set; }

        public int? Sonha { get; set; }

        [StringLength(50)]
        public string Toanha { get; set; }

        [StringLength(50)]
        public string Phuongxa { get; set; }

        [StringLength(50)]
        public string Quanhuyen { get; set; }

        [StringLength(50)]
        public string Tinhthanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhacungcap> Nhacungcaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diadiemthamquan> Diadiemthamquans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thanhvien> Thanhviens { get; set; }
    }
}
