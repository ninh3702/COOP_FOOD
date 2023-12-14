using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            set { instance = value; }
        }
        private NhaCungCapDAO() { }

        public DataTable DanhSachNhaCungCap()
        {
            return DataProvider.Instance.ExecuteQuery("select * from nhacungcap");
        }
        public bool ThemNhaCungCap(int maNCC, string tenNCC, string diachi, string SDT)
        {
            string query = string.Format("INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT) VALUES ({0}, N'{1}', N'{2}', {3});",maNCC, tenNCC, diachi, SDT);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaNhaCungCap(int maNCC, string tenNCC, string diachi, string SDT)
        {
            string query = string.Format("UPDATE NHACUNGCAP set TenNCC = N'{0}' ,DiaChi = N'{1}' ,SDT = {2} WHERE MaNCC = {3};", tenNCC, diachi, SDT, maNCC);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaNhaCungCap(int maNCC)
        {
            string query = string.Format("DELETE FROM NHACUNGCAP WHERE MaNCC = {0};",maNCC);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}