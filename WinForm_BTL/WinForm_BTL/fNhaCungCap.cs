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
        BindingSource danhsachNhaCungCap = new BindingSource();
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

        private void fNhaCungCap_Load(object sender, EventArgs e)
        { 
            dtgvNhaCungCap.DataSource = danhsachNhaCungCap;
            danhsachNhaCungCap.DataSource = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
            
            dtgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhaCungCapBinding();
        }
        void NhaCungCapBinding()
        {
            txtMaNhaCungCap.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "MaNCC"));
            txtTenNhaCungCap.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "TenNCC"));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "DiaChi"));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvNhaCungCap.DataSource, "SDT"));
        }
    }
}
