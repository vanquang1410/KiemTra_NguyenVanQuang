using KiemTra_NguyenVanQuang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenVanQuang.Controllers
{
    public class HocPhanController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: HocPhan
        public ActionResult ListHocPhan()
        {
            var hocphan = from s in data.HocPhans select s;
            return View(hocphan);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}