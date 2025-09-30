using LTWeb05_Bai02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai02.ViewModels
{
    public class SanPham_Loai_ViewModel
    {
        public LoaiSP LoaiSP { get; set; }
        public List<SanPham> DSSP { get; set; } 
    }
}