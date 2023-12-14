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

    }
}
