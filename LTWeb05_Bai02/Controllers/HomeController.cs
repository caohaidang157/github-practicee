using LTWeb05_Bai02.Models;
using LTWeb05_Bai02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb05_Bai02.Controllers
{
    public class HomeController : Controller
    {
        public DuLieu csdl= new DuLieu();

        public ActionResult HienThiSanPham()
        {
            List<SanPham> ds = csdl.dsSP;
            return View(ds);
        }
        public ActionResult HienThiLoaiSP()
        {
            List<LoaiSP> ds = csdl.dsLoai;
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
        public ActionResult SanPham_Loai(int id)
        {
            SanPham_Loai_ViewModel SP_Loai= new SanPham_Loai_ViewModel();
            LoaiSP loai = csdl.ChiTiet_Loai(id);
            List<SanPham> dssp = csdl.SanPham_TheoLoai(id);
            SP_Loai.LoaiSP = loai;
            SP_Loai.DSSP = dssp;
            return View(SP_Loai);
        }
        [HttpGet]
        public ActionResult TimKiem(string tukhoa)
        {
            List<SanPham> dssp = csdl.TimKiemSP(tukhoa);
            ViewBag.TuKhoa = tukhoa;
            return View(dssp);
        }

        [HttpGet]
        public ActionResult ProductByCategory(int? selectedCategory)
        {
            var csdl = new DuLieu(); 
            var vm = new ProductByCategoryViewModel();
            vm.Categories = csdl.dsLoai; 
            vm.SelectedCategory = selectedCategory;

            if (selectedCategory.HasValue)
            {
                vm.Products = csdl.SanPham_TheoLoai(selectedCategory.Value);
            }
            else
            {
                vm.Products = new List<SanPham>(); 
            }
            return View(vm);
        }

    }
}