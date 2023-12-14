using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_BTL.DAO;

namespace WinForm_BTL
{
    public partial class fNhaCungCap : Form
    {
       
        public fNhaCungCap()
        {
            InitializeComponent();
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            fChiTietHoaDon f = new fChiTietHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            fSanPham f = new fSanPham();
            f.Show();
            this.Hide();
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            f.Show();
            this.Hide();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            f.Show();
            this.Hide();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            fThongKe f = new fThongKe();
            f.Show();
            this.Hide();
        }
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            f.Show();
            this.Hide();
        }
        BindingSource danhsachNhaCungCap = new BindingSource();
        private void fNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            
            dtgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhaCungCapBinding();
        }
        void LoadNhaCungCap()
        {
            dtgvNhaCungCap.DataSource = danhsachNhaCungCap;
            danhsachNhaCungCap.DataSource = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
        }
        void NhaCungCapBinding()
        {
            txtMaNhaCungCap.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "MaNCC",true,DataSourceUpdateMode.Never));
            txtTenNhaCungCap.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "SDT", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int maNCC = Int32.Parse(txtMaNhaCungCap.Text);
            string tenNCC = txtTenNhaCungCap.Text;
            string diachi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;

            if (NhaCungCapDAO.Instance.ThemNhaCungCap(maNCC,tenNCC,diachi,SDT))
            {
                MessageBox.Show("Thêm thành công");
                LoadNhaCungCap();        
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int maNCC = Int32.Parse(txtMaNhaCungCap.Text);
            string tenNCC = txtTenNhaCungCap.Text;
            string diachi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;

            if (NhaCungCapDAO.Instance.SuaNhaCungCap(maNCC, tenNCC, diachi, SDT))
            {
                MessageBox.Show("Sửa thành công");
                LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNCC = Int32.Parse(txtMaNhaCungCap.Text);

            if (NhaCungCapDAO.Instance.XoaNhaCungCap(maNCC))
            {
                MessageBox.Show("Xóa thành công");
                LoadNhaCungCap();
            }
            else 
            {
                MessageBox.Show("Xóa thất bại");
            }

        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Text = null;
            txtTenNhaCungCap.Text = null;
            txtDiaChi.Text = null;
            txtSoDienThoai.Text = null;
        }
    }
}
