using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchudleTour.Controllers
{

    public class LichtrinhController : Controller
    {
        Lichtrinh lichtrinh = null;
        DiadiemDAO diadiemDAO = null;
        DichvuDAO dichvuDAO = null;
        DichvuNccDAO dichvuNccDAO = null;

        public LichtrinhController()
        {
            diadiemDAO = new DiadiemDAO();
            dichvuDAO = new DichvuDAO();
            dichvuNccDAO = new DichvuNccDAO();
        }

        public void AddDichvu(int IDDichvuNcc, DateTime StartDate, DateTime EndDate)
        {
            if (Session["lichtrinhsession"] != null)
            {
                lichtrinh = Session["lichtrinhsession"] as Lichtrinh;
                var DichvuNcc = dichvuNccDAO.GetDichvuNccByID(IDDichvuNcc);
                var Dichvu = dichvuDAO.GetDichvuByID(Int32.Parse(DichvuNcc.DichvuID.ToString()));
                LichtrinhDVNCC lichtrinhDVNCC  = new LichtrinhDVNCC() { 
                    DichvuNcc = DichvuNcc,
                    Thoigianden = StartDate,
                    Thoigiandi = EndDate,
                    Dichvu = Dichvu,
                };
                lichtrinh.LichtrinhDVNCCs.Add(lichtrinhDVNCC);
                Session["lichtrinhsession"] = lichtrinh;

            }
            else
            {
                lichtrinh = new Lichtrinh();
                var DichvuNcc = dichvuNccDAO.GetDichvuNccByID(IDDichvuNcc);
                var Dichvu = dichvuDAO.GetDichvuByID(Int32.Parse(DichvuNcc.DichvuID.ToString()));
                LichtrinhDVNCC lichtrinhDVNCC = new LichtrinhDVNCC()

                {
                    DichvuNcc = DichvuNcc,
                    Thoigianden = StartDate,
                    Thoigiandi = EndDate,
                    Dichvu = Dichvu,
                };
                lichtrinh.LichtrinhDVNCCs.Add(lichtrinhDVNCC);
                Session["lichtrinhsession"] = lichtrinh;

            }
        }

        // GET: Lichtrinh

        public void AddDiadiem(int DiadiemID, DateTime StartDate, DateTime EndDate)
        {
            if (Session["lichtrinhsession"] != null)
            {
                lichtrinh = Session["lichtrinhsession"] as Lichtrinh;
                var diadiem = diadiemDAO.GetSreachDiadiembyID(DiadiemID);
                ThoigianCCDD thoigianCCDD = new ThoigianCCDD()
                {
                    Thoigianden = StartDate,
                    Thoigiandi = EndDate,
                    Diadiemthamquan = diadiem,
                };
                foreach (var item in lichtrinh.ThoigianCCDDs)
                {
                    if (item.Diadiemthamquan.DiadiemID == DiadiemID && item.Thoigianden == StartDate)
                    {
                        Session["lichtrinhsession"] = lichtrinh;
                        break;
                    }
                    else
                    {
                        lichtrinh.ThoigianCCDDs.Add(thoigianCCDD);
                        Session["lichtrinhsession"] = lichtrinh;
                        break;
                    }
                }



            }
            else
            {
                lichtrinh = new Lichtrinh();
                var diadiem = diadiemDAO.GetSreachDiadiembyID(DiadiemID);
                ThoigianCCDD thoigianCCDD = new ThoigianCCDD()
                {
                    Thoigianden = StartDate,
                    Thoigiandi = EndDate,
                    Diadiemthamquan = diadiem,
                };
                thoigianCCDD.Diadiemthamquan = diadiem;
                lichtrinh.ThoigianCCDDs.Add(thoigianCCDD);
                Session["lichtrinhsession"] = lichtrinh;


            }

        }

        public ActionResult CreateLichtrinh()
        {
            var rqDiadiem = HttpContext.Request.Form["idDiadiem"];
            var rqDichvu = HttpContext.Request.Form["idDichvu"];
            var rpStartdate = HttpContext.Request.Form["thoigianden"];
            var rpEnddate = HttpContext.Request.Form["thoigiandi"];
            if (rqDiadiem != "")
            {
                if (rpStartdate == null && rpEnddate == null)
                {
                    lichtrinh = Session["lichtrinhsession"] as Lichtrinh;
                    return View(lichtrinh);
                }
                else
                {
                    DateTime Startdate = DateTime.Parse(rpStartdate);
                    DateTime Enddate = DateTime.Parse(rpEnddate);
                    int DiadiemID = Int32.Parse(rqDiadiem);
                    AddDiadiem(DiadiemID, Startdate, Enddate);
                }
            }
            if(rqDichvu != "")
            {
                if (rpStartdate == null && rpEnddate == null)
                {
                    lichtrinh = Session["lichtrinhsession"] as Lichtrinh;
                    return View(lichtrinh);
                }
                else
                {
                    DateTime Startdate = DateTime.Parse(rpStartdate);
                    DateTime Enddate = DateTime.Parse(rpEnddate);
                    int DichvuID = Int32.Parse(rqDichvu);
                    AddDichvu(DichvuID, Startdate, Enddate);
                }

            }

            //var rpdichvu = HttpContext.Request.Form["submitdichvu"];

            return View(lichtrinh);
        }

        public ActionResult AddTime()
        {
            var rqDiadiem = HttpContext.Request.Form["submitdiadiem"];
            var rqDichvu = HttpContext.Request.Form["submitdichvu"];
            //int idthoigiancungcap = Int32.Parse(rpdichvu);
            //AddDichvu(idthoigiancungcap);
            if (rqDiadiem != null)
            {
                ViewBag.IdDiadiem = rqDiadiem;
                return View();
            }
            if (rqDichvu != null)
            {
                ViewBag.IdDichvu = rqDichvu;
                return View();
            }

            return View();
        }

        public ActionResult Sreachdvdd()
        {
            return View();

        }



    }
}