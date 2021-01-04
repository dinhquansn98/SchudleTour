using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class LichtrinhDAO
    {
        SchudletourDbContext db = null;


        public LichtrinhDAO()
        {   
            db = new SchudletourDbContext();
        }
      
    }
}
