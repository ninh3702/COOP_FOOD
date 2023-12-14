using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_BTL.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            set { instance = value; }
        }
        private HoaDonDAO() { }

        public DataTable DanhSachHoaDon()
        {
            return DataProvider.Instance.ExecuteQuery("select * from hd ");
        }
        public bool ThemHoaDon(int MaHD, int MaNV, int MaKH, string NgayMua, string TongTien)
        {
            string query = string.Format("INSERT INTO HD (MaHD, MaNV, MaKH, NgayMua, TongTien) VALUES ({0}, {1}, {2}, '{3}','{4}')", MaHD, MaNV, MaKH, NgayMua, TongTien);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaHoaDon(int MaHD, int MaNV, int MaKH, string NgayMua, string TongTien)
        {
            string query = string.Format("UPDATE HD set  MaNV = {1}, MaKH = {2}, NgayMua = N'{3}', TongTien = {4} WHERE MaHD = {0}",  MaHD,  MaNV,  MaKH,  NgayMua, TongTien);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaHoaDon(int MaHD)
        {
            string query = string.Format("DELETE FROM HD WHERE MaHD = {0};", MaHD);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void ThemDanhSachMaHoaDonVaoComboBox(ComboBox cb)
        {
            cb.DataSource = HoaDonDAO.Instance.DanhSachHoaDon();
            cb.DisplayMember = "MaHD";
            cb.ValueMember = "MaHD";
        }
        public DataTable HienThiTongTien(int MaHD)
        {
            string query = string.Format("SELECT SUM(GiaSP)FROM CT_HD Where mahd = {0}",MaHD);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }
        public void HienThiTongTienSQL(int MaHD, string TongTien)
        {
            string query = string.Format("UPDATE HD set TongTien = '{1}' WHERE MaHD = {0}", MaHD,TongTien);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

        }
    }
}
