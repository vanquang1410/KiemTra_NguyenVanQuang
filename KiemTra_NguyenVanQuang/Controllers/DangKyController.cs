using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenVanQuang.Models;

namespace KiemTra_NguyenVanQuang.Controllers
{
    public class DangKyController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        //Đăng Ký
        public List<DangKy> DangKy()
        {
            List<DangKy> lstDangKy = Session["DangKy"] as List<DangKy>;
            if (lstDangKy == null)
            {
                lstDangKy = new List<DangKy>();
                Session["DangKy"] = lstDangKy;
            }
            return lstDangKy;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}