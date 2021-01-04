using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchudleTour.Controllers
{
    public class NhacungcapController : Controller
    {
        // GET: Nhacungcap
        NhacungcapDAO nhacungcapDAO = null;
       public NhacungcapController()
        {
            nhacungcapDAO = new NhacungcapDAO();
        }
        [HttpPost]
        public ActionResult Chonnhacungcap ()
        {
         
            int dichvuID = Int32.Parse(HttpContext.Request.Form["submitdichvu"]);
            List<NhacungcapView> nhacungcapViews = nhacungcapDAO.GetNhacungcapbyDichvuID(dichvuID);
            
            return View(nhacungcapViews);
        }
    }
}