using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_BTL.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            set { instance = value; }
        }
        private SanPhamDAO() { }

        public DataTable DanhSachSanPham()
        {
            return DataProvider.Instance.ExecuteQuery("select * from sanpham");
        }
        public bool ThemSanPham(int MaSP, string TenSP, int MaLSP, int MaNCC, int SoLuong, string NSX, string HSD, string NgayNhap, float GiaNhap, float GiaBan)
        {
            string query = string.Format("INSERT INTO SANPHAM (MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan) VALUES ({0}, N'{1}', {2}, {3}, {4}, N'{5}', N'{6}', N'{7}', {8}, {9});", MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaSanPham(int MaSP, string TenSP, int MaLSP, int MaNCC, int SoLuong, string NSX, string HSD, string NgayNhap, float GiaNhap, float GiaBan)
        {
            string query = string.Format("UPDATE SanPham set TenSP = N'{1}', MaLSP = {2}, MaNCC = {3}, SoLuong = {4}, NSX = N'{5}', HSD = N'{6}', NgayNhap = N'{7}', GiaNhap = {8}, GiaBan = {9}  WHERE MaSP = {0};", MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaSanPham(int MaSP)
        {
            string query = string.Format("DELETE FROM SanPham WHERE MaSP = {0};", MaSP);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void ThemDanhSachMaSanPhamVaoComboBox(ComboBox cb)
        {
            cb.DataSource = SanPhamDAO.Instance.DanhSachSanPham();
            cb.DisplayMember = "MaSP";
            cb.ValueMember = "MaSP";
        }

    }
}
