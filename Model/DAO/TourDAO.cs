using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TourDAO
    {
        SchudletourDbContext db = null;

        
        public TourDAO()
        {
            db = new SchudletourDbContext();
        }
        public IEnumerable<Tour> GetAllTour()
        {
            return db.Tours;
        }
    }
}
