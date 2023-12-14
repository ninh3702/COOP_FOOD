using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_BTL.DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        public static ChiTietHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAO(); return instance; }
            set { instance = value; }
        }

        private ChiTietHoaDonDAO() { }

        public DataTable DanhSachChiTietHoaDon()
        {
            return DataProvider.Instance.ExecuteQuery("select * from ct_hd");
        }
        public DataTable DanhSachChiTietHoaDonTheoMaHoaDon(string MaHD)
        {
            if(MaHD != "")
            {
                string query = string.Format("select * from ct_hd where MaHD = {0}", Int32.Parse(MaHD));

                DataTable result = DataProvider.Instance.ExecuteQuery(query);

                return result;
            }
            else
            {
                return DanhSachChiTietHoaDon();
            }
            
        }
        public DataTable LayGiaSanPham(int MaSP)
        {
            string query = string.Format("select sanpham.giaban from sanpham where sanpham.masp = {0}",MaSP);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }
        public bool ThemChiTietHoaDon(int MaHD, int MaSP, int SoLuongBan, float GiaSP)
        {
            string query = string.Format("INSERT INTO CT_HD (MaHD, MaSP, SoLuongBan, GiaSP) VALUES ({0},{1},{2},{3});", MaHD, MaSP, SoLuongBan, GiaSP);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaChiTietHoaDon(int MaHD, int MaSP, int SoLuongBan, float GiaSP)
        {
            string query = string.Format("UPDATE CT_HD set MaSP = {1}, SoLuongBan = {2}, GiaSP = {3} WHERE MaHD = {0}", MaHD, MaSP, SoLuongBan, GiaSP);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaChiTietHoaDon(int MaHD, int MaSP)
        {
            string query = string.Format("DELETE FROM CT_HD WHERE MaHD = {0} and MaSP = {1};", MaHD,MaSP);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public string convertDataTableToString(DataTable dataTable)
        {
            string data = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    data += row[j];
                    if (j == dataTable.Columns.Count - 1)
                    {
                        if (i != (dataTable.Rows.Count - 1))
                            data += "$";
                    }
                    else
                        data += "|";
                }
            }
            return data;
        }
    }
}
