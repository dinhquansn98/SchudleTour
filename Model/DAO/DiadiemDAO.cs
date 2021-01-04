using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DiadiemDAO
    {
        SchudletourDbContext db = null;


        public DiadiemDAO()
        {
            db = new SchudletourDbContext();
        }
        public List<Diadiemthamquan> GetSreachDiadiem(String name)
        {
            var model = db.Diadiemthamquans.Where(x => x.DiadiemName.Contains(name));
            return model.ToList();
        }
        public  Diadiemthamquan GetSreachDiadiembyID(int id)
        {
            var model = (from d in db.Diadiemthamquans
                         where d.DiadiemID == id
                         select d);
            return model.First();
        }

    }
}
