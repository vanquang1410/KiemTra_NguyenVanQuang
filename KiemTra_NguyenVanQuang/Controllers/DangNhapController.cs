using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenVanQuang.Models;
namespace KiemTra_NguyenVanQuang.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListDangNhap()
        {        
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}