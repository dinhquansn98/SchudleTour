using Model.DAO;
using Microsoft.Ajax.Utilities;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SchudleTour.Controllers
{
    public class DanhsachdvddController : Controller
    {
        DichvuDAO rpDichvu = null;
        DiadiemDAO rpDiadiem = null;

        // GET: Danhsachdvdd
 
        public DanhsachdvddController()
        {
            rpDichvu = new DichvuDAO();
            rpDiadiem = new DiadiemDAO();

        }

        [HttpPost]
        public ActionResult Danhsachdvdd()
        {
            ListViewDvdd listViewDvdd = new ListViewDvdd();
            listViewDvdd.listdichvu = rpDichvu.GetSreachDichvu(HttpContext.Request.Form["namesreach"]);
            listViewDvdd.listdiadiem = rpDiadiem.GetSreachDiadiem(HttpContext.Request.Form["namesreach"]);
            

            return View(listViewDvdd);
        }


    }
}