using LTWeb05_Bai02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai02.ViewModels
{
    public class ProductByCategoryViewModel
    {
        public IEnumerable<LoaiSP> Categories { get; set; } 
        public int? SelectedCategory { get; set; }    
        public IEnumerable<SanPham> Products { get; set; }
    }
}