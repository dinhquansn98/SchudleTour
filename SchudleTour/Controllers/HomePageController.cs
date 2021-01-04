using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchudleTour.Controllers
{
    public class HomePageController : Controller
    {
        ThanhvienDAO thanhvienDAO = null;

        public HomePageController()
        {
            thanhvienDAO = new ThanhvienDAO();
        }

        // GET: HomePage
        public ActionResult Index()
        {   
            var username = HttpContext.Request.Form["username"];
            var password = HttpContext.Request.Form["password"];
            if(username != null && password != null)
            {
                var model = thanhvienDAO.GetThanhvienFromLogin(username, password);
                if (model == null)
                {
                    return View("../HomePage/Login");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View();
            }
           
          
        }

        public ActionResult Login()
        {

            return View();
        }
    }
}