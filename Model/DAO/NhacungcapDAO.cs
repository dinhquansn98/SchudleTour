using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NhacungcapDAO
    {
        SchudletourDbContext db = null;
        public NhacungcapDAO()
        {
            db = new SchudletourDbContext();
        }

        public List<NhacungcapView> GetNhacungcapbyDichvuID(int dichvuID)
        {
            var model = from a in db.Nhacungcaps
                        join b in db.DichvuNccs
                        on a.NccID equals b.NccID
                        where b.DichvuID == dichvuID
                        select new NhacungcapView()
                        {
                            IDDichvuNcc = b.IDDichvuNcc,
                            NccName = a.NccName,  
                            Email = a.Email,
                            Sdt = a.Sdt,
                        };

            return model.ToList();

        }

    }
}
