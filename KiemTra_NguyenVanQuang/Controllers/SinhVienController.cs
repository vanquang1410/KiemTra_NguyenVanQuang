using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenVanQuang.Models;

namespace KiemTra_NguyenVanQuang.Controllers
{
    public class SinhVienController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: SinhVien
        public ActionResult ListSinhVien()
        {
            var sinhvien = from s in data.SinhViens select s;
            return View(sinhvien);
        }
        public ActionResult Details(string id)
        {
            var sinhvien = data.SinhViens.SingleOrDefault(s => s.MaSV == id);
            return View(sinhvien);
        }
        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];

            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.HoTen = hoten.ToString();
                s.GioiTinh = gioitinh.ToString();
                s.NgaySinh = DateTime.Parse(ngaysinh);
                s.Hinh = hinh.ToString();
                s.MaNganh = manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //Edit
        public ActionResult Edit(string id)
        {
            var sinhVien = data.SinhViens.First(s => s.MaSV == id);
            return View(sinhVien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var masv = data.SinhViens.First(s => s.MaSV == id);
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];
            masv.MaSV = id;
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                masv.HoTen = hoten.ToString();
                masv.GioiTinh = gioitinh.ToString();
                masv.NgaySinh = DateTime.Parse(ngaysinh);
                masv.Hinh = hinh.ToString();
                masv.MaNganh = manganh.ToString();
                UpdateModel(masv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        //Delete
        public ActionResult Delete(int id)
        {
            var D_sinhvien = data.SinhViens.First(m => Convert.ToInt32(m.MaSV) == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => Convert.ToInt32(m.MaSV) == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        //
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Images/" + file.FileName));
            return "~/Content/Images/" + file.FileName;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}