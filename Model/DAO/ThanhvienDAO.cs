using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ThanhvienDAO
    {
        SchudletourDbContext db = null;

        public ThanhvienDAO()
        {
            db = new SchudletourDbContext();
        }
        public Thanhvien GetThanhvienbyID(int? id)
        {
            var model = (from d in db.Thanhviens
                         where d.IDThanhvien == id
                         select d
                          );
            return model.First();
        }
        public Thanhvien GetThanhvienFromLogin(String username , String password)
        {
            var thanhvien = (from d in db.Thanhviens
                             where d.Usename == username && d.Password == password
                             select d
                             );
            return thanhvien.First();
        }

    }
}
