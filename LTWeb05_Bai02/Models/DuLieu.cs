using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai02.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=DESKTOP-HHFANUM;database=QL_DTDD1;User ID=sa;Password=123";
        SqlConnection con = new SqlConnection(strcon);
        public List<SanPham> dsSP = new List<SanPham>();
        public List<LoaiSP> dsLoai = new List<LoaiSP>();
        public DuLieu()
        {
            ThietLap_DSSP();
            ThietLap_DSLoai();
        }
        public void ThietLap_DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from SanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = double.Parse(dr["Gia"].ToString());
                sp.MoTa = dr["MoTa"].ToString();
                sp.Loai = int.Parse(dr["MaLoai"].ToString());
                dsSP.Add(sp);
            }    
        }
        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var loai = new LoaiSP();
                loai.Loai = int.Parse(dr["MaLoai"].ToString());
                loai.TenLoai = dr["TenLoai"].ToString();
                dsLoai.Add(loai);
            }
        }
        public LoaiSP ChiTiet_Loai(int id)
        {
            LoaiSP loaiSP = new LoaiSP();
            string sqlScript = String.Format("select * from Loai where MaLoai='{0}'", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                loaiSP.Loai = int.Parse(dr["MaLoai"].ToString());
                loaiSP.TenLoai = dr["TenLoai"].ToString();
            }
            return loaiSP;
        }
        public List<SanPham> SanPham_TheoLoai(int id)
        {
            List<SanPham> ds = new List<SanPham>();
            string sqlScript = String.Format("select * from SanPham where MaLoai='{0}'", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = double.Parse(dr["Gia"].ToString());
                sp.MoTa = dr["MoTa"].ToString();
                sp.Loai = int.Parse(dr["MaLoai"].ToString());
                ds.Add(sp);
            }
            return ds;
        }

        public List<SanPham> TimKiemSP(string tukhoa)
        {
            List<SanPham> ds = new List<SanPham>();
            string sqlScript = String.Format("select * from SanPham where TenSP like N'%{0}%'", tukhoa);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.DuongDan = dr["DuongDan"].ToString();
                sp.Gia = double.Parse(dr["Gia"].ToString());
                sp.MoTa = dr["MoTa"].ToString();
                sp.Loai = int.Parse(dr["MaLoai"].ToString());
                ds.Add(sp);
            }
            return ds;
        }
    }
}