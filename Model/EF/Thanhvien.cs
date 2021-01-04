namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thanhvien")]
    public partial class Thanhvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thanhvien()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        [Key]
        public int IDThanhvien { get; set; }

        [StringLength(50)]
        public string Usename { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Ghichu { get; set; }

        public int? IDdiachi { get; set; }

        public int? IDhoten { get; set; }

        public virtual Diachi Diachi { get; set; }

        public virtual Hoten Hoten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
