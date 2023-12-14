using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DAO
{
    public class LoaiSanPhamDAO
    {
        private static LoaiSanPhamDAO instance;

        public static LoaiSanPhamDAO Instance
        {
            get { if (instance == null) instance = new LoaiSanPhamDAO(); return instance; }
            set { instance = value; }
        }

        private LoaiSanPhamDAO() { }

        public DataTable DanhSachLoaiSanPham()
        {
            return DataProvider.Instance.ExecuteQuery("select * from loaisanpham");
        }
    }
}
