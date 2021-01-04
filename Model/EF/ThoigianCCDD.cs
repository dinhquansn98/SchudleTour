namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThoigianCCDD")]
    public partial class ThoigianCCDD
    {
        public int ID { get; set; }

        public int? DiadiemID { get; set; }

        public int? IDLichtrinh { get; set; }

        public DateTime? Thoigianden { get; set; }

        public DateTime? Thoigiandi { get; set; }

        public virtual Diadiemthamquan Diadiemthamquan { get; set; }

        public virtual Lichtrinh Lichtrinh { get; set; }
    }
}
