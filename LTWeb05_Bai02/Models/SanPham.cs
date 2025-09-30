using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai02.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DuongDan { get; set; }
        public double Gia { get; set; }
        public string MoTa { get; set; }
        public int Loai { get; set; }
    }
}