using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{ 
    
    public class NhanvienDAO
    {

        SchudletourDbContext db = null;

        public NhanvienDAO()
        {
            db = new SchudletourDbContext();
        }
        public List<Nhanvien> Gethuongdanvien()
        {
            var model = (  from d in db.Nhanviens
                           where d.Vitri == "Huongdanvien"
                           select d
                          );
            return model.ToList();
        }
        public Nhanvien GethuongdanvienbyID(int id)
        {
            var model = (from d in db.Nhanviens
                         where d.IDNhanvien == id
                         select d
                          );
            return model.First();
        }
    }
}
