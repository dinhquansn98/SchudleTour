namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Lichtrinhs = new HashSet<Lichtrinh>();
        }

        public int? TourID { get; set; }

        [StringLength(50)]
        public string TourName { get; set; }

        public int? SoVe { get; set; }

        public DateTime? Ngaytao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayxuatphat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayketthuc { get; set; }

        public int? IDNhanvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lichtrinh> Lichtrinhs { get; set; }

        public virtual Nhanvien Nhanvien { get; set; }
    }
}
