using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class DichvuDAO
    {
        SchudletourDbContext db = null;


        public DichvuDAO()
        {
            db = new SchudletourDbContext();
        }
       

        public List<Dichvu> GetSreachDichvu(String name)
        {
            var model = db.Dichvus.Where(x => x.DichvuName.Contains(name));
            return model.ToList();
        }
        public Dichvu GetDichvuByID(int id)
        {
            var model = (from d in db.Dichvus
                         where d.DichvuID == id
                         select d);
            return model.First();
        }

    }
}
