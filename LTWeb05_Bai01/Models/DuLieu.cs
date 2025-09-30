using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb05_Bai01.ViewModels;

namespace LTWeb05_Bai01.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=DESKTOP-HHFANUM;database=QL_NhanSu;User ID=sa;Password=123";
        SqlConnection con = new SqlConnection(strcon);
        public List<Employee> dsNV = new List<Employee>();
        public List<Department> dsPB = new List<Department>();

        public DuLieu()
        {
            ThietLap_DSNV();
            Thietlap_DSPB();
        }

        public void ThietLap_DSNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["TEN"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = int.Parse(dr["DeptId"].ToString());
                dsNV.Add(em);
            }
        }
        public void Thietlap_DSPB()
        {
            SqlDataAdapter dA = new SqlDataAdapter("select * from tbl_Department", con);
            DataTable dataTable = new DataTable();
            dA.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                var pb = new Department();
                pb.MaPB = int.Parse(dr["DeptId"].ToString());
                pb.TenPB = dr["Ten"].ToString();
                dsPB.Add(pb);
            }
        }

        public Department ChiTiet_PhongBan(int id)
        {
            Department department = new Department();
            string sqlScript = String.Format("select * from tbl_Department where DeptId={0}", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            department.MaPB = int.Parse(dt.Rows[0]["DeptId"].ToString());
            department.TenPB = dt.Rows[0]["Ten"].ToString();
            return department;
        }
        public List<Employee> DanhSachNhanVienTheoMaPhong(int id)
        {
            List<Employee> employees = new List<Employee>();
            string sqlScript = String.Format("select * from tbl_Employee where DeptId={0}", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["TEN"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = int.Parse(dr["DeptId"].ToString());
                employees.Add(em);
            }
            return employees;
        }
    }
}