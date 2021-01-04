namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichtrinhDVNCC")]
    public partial class LichtrinhDVNCC
    {
        public int ID { get; set; }

        public int? IDDichvu { get; set; }

        public int? LichtrinhID { get; set; }

        public DateTime? Thoigiandi { get; set; }

        public DateTime? Thoigianden { get; set; }

        public double? GiaTien { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public int? IDDichvuNcc { get; set; }

        public virtual Dichvu Dichvu { get; set; }

        public virtual DichvuNcc DichvuNcc { get; set; }
    }
}
