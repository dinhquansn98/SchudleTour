using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class DichvuNccDAO
    { 
        
       SchudletourDbContext db = null;


    public DichvuNccDAO()
    {
        db = new SchudletourDbContext();
    }

        public DichvuNcc GetDichvuNccByID(int id)
        {
            var model = (from d in db.DichvuNccs
                         where d.IDDichvuNcc == id
                         select d);
            return model.First();
        }


    }


   
}
