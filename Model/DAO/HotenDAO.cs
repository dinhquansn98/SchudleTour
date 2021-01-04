using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
     public class HotenDAO
    {

        SchudletourDbContext db = null;

        public HotenDAO()
        {
            db = new SchudletourDbContext();
        }
        public Hoten GetHotenbyID(int? id)
        {
            var model = (from d in db.Hotens
                         where d.IDhoten == id
                         select d
                          );
            return model.First();
        }
    }
}
