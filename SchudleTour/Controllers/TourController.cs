using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchudleTour.Controllers
{
    public class TourController : Controller
    {
        TourDAO repository = null;
        Tour tour = null;
        NhanvienDAO nhanvienDAO = null;
        ThanhvienDAO thanhvienDAO = null;
        HotenDAO hotenDAO = null;
        // GET: Tour
        public TourController()
        {
            repository = new TourDAO();
            tour = new Tour();
            nhanvienDAO = new NhanvienDAO();
            thanhvienDAO = new ThanhvienDAO();
            hotenDAO = new HotenDAO();
        }

        public ActionResult GetAllTour()
        {
            var dao = new TourDAO();
            var model = dao.GetAllTour().ToList();
            return View(model);
        }
        [HttpPost]
        public void SetData(String nameTour, String soVe, String moTa, DateTime ngayxuatphat, DateTime ngayketthuc, int? huongdanvien)
        {
            tour = Session["Tour"] as Tour;
            tour.TourName = nameTour;
            tour.SoVe = Int32.Parse(soVe);
            tour.Ngayxuatphat = ngayxuatphat;
            tour.Ngaytao = DateTime.Now;
            tour.Ngayketthuc = ngayketthuc;
            var nhanvien = nhanvienDAO.GethuongdanvienbyID(Int32.Parse(huongdanvien.ToString()));
            tour.IDNhanvien = nhanvien.IDNhanvien;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SchudletourDbContext dbContext = new SchudletourDbContext())
                    {
                        Tour setTour = new Tour()
                        {
                            IDNhanvien = tour.IDNhanvien,
                            Ngaytao = tour.Ngaytao,
                            Ngayxuatphat = tour.Ngayxuatphat,
                            Ngayketthuc = tour.Ngayketthuc,
                            SoVe = tour.SoVe,
                            TourName = tour.TourName,
                        };
                        dbContext.Tours.Add(setTour);
                        dbContext.SaveChanges();
                        int? idTour = setTour.TourID;
                        foreach (var lichtrinh in tour.Lichtrinhs)
                        {
                            Lichtrinh setlichtrinh = new Lichtrinh()
                            {
                                lichtrinhName = lichtrinh.lichtrinhName,
                                LichtrinhMoTa = lichtrinh.LichtrinhMoTa,
                                TourID = idTour,
                            };
                            dbContext.Lichtrinhs.Add(setlichtrinh);
                            dbContext.SaveChanges();
                            int? lichtrinhID = setlichtrinh.LichtrinhID;
                            foreach(var thoigianCCDD in lichtrinh.ThoigianCCDDs)
                            {
                                ThoigianCCDD setthoigianCCDD = new ThoigianCCDD()
                                {
                                    Thoigianden = thoigianCCDD.Thoigianden,
                                    Thoigiandi = thoigianCCDD.Thoigiandi,
                                    DiadiemID = thoigianCCDD.Diadiemthamquan.DiadiemID,
                                    IDLichtrinh = lichtrinhID,
                                };

                                dbContext.ThoigianCCDDs.Add(setthoigianCCDD);
                                dbContext.SaveChanges();
                            }
                            foreach(var LichtrinhDVNCC in lichtrinh.LichtrinhDVNCCs)
                            {
                                LichtrinhDVNCC setlichtrinhDVNCC = new LichtrinhDVNCC()
                                {
                                    Thoigianden = LichtrinhDVNCC.Thoigianden,
                                    Thoigiandi = LichtrinhDVNCC.Thoigiandi,
                                    GiaTien = LichtrinhDVNCC.DichvuNcc.Dichvu.Dongia,
                                    Mota = LichtrinhDVNCC.Mota,
                                    LichtrinhID = lichtrinhID,
                                    IDDichvu = LichtrinhDVNCC.DichvuNcc.Dichvu.DichvuID,
                                    IDDichvuNcc = LichtrinhDVNCC.DichvuNcc.IDDichvuNcc,
                                    ID = 3,
                                
                                };
                                dbContext.LichtrinhDVNCCs.Add(setlichtrinhDVNCC);
                                dbContext.SaveChanges();

                            }


                        }



                    }
                    ts.Complete();
                }

            }
            catch (Exception ex)
            {

            }


        }



        public ActionResult CreateTour()
        {
            var nhanvienlist = nhanvienDAO.Gethuongdanvien();
            foreach (var item in nhanvienlist)
            {
                var thanhvien = thanhvienDAO.GetThanhvienbyID(item.IDThanhvien);
                var Hoten = hotenDAO.GetHotenbyID(thanhvien.IDhoten);
                thanhvien.Hoten = Hoten;
                item.Thanhvien = thanhvien;
            }

            var rqtenDichvu = HttpContext.Request.Form["Tendichvu"];
            var rqmotaDichvu = HttpContext.Request.Form["Motadichvu"];

            var lichtrinh = Session["lichtrinhsession"] as Lichtrinh;
            if (lichtrinh != null)
            {
                lichtrinh.lichtrinhName = rqtenDichvu;
                lichtrinh.LichtrinhMoTa = rqmotaDichvu;
                tour.Lichtrinhs.Add(lichtrinh);
                Session["Tour"] = tour;
            }

            return View(nhanvienlist.ToList());
        }

    }
}
