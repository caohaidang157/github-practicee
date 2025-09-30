using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb05_Bai01.Models;
using LTWeb05_Bai01.ViewModels;

namespace LTWeb05_Bai01.Controllers
{
    public class HomeController : Controller
    {
        DuLieu csdl = new DuLieu();
        public ActionResult HienThiNhanVien()
        {
            List<Employee> ds = csdl.dsNV;
            return View(ds);
        }

        public ActionResult HienThiPhongBan()
        {
            List<Department> ds= csdl.dsPB;
            return View(ds);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Detail_PhongBan(int id)
        {
            DepartmentViewModel department = new DepartmentViewModel();
            Department ds = csdl.ChiTiet_PhongBan(id);
            List<Employee> dsnv = csdl.DanhSachNhanVienTheoMaPhong(id);
            department.Department = ds;
            department.Employees = dsnv;
            return View(department);
        }
    }
}