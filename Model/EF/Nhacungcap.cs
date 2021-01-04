namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhacungcap")]
    public partial class Nhacungcap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhacungcap()
        {
            DichvuNccs = new HashSet<DichvuNcc>();
        }

        [Key]
        public int NccID { get; set; }

        [StringLength(50)]
        public string NccName { get; set; }

        [StringLength(50)]
        public string Sdt { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? diachiID { get; set; }

        public virtual Diachi Diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichvuNcc> DichvuNccs { get; set; }
    }
}
