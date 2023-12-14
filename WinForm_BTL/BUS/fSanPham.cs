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
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {

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

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            fNhaCungCap f = new fNhaCungCap();
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
        BindingSource danhsachSanPham = new BindingSource();

        private void fSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();

            dtgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SanPhamBinding();
            ThemDanhSachNhaCungCapVaoComboBox();
            ThemDanhSachLoaiSanPhamVaoComboBox();
        }
        void LoadSanPham()
        {
            dtgvSanPham.DataSource = danhsachSanPham;
            danhsachSanPham.DataSource = SanPhamDAO.Instance.DanhSachSanPham();
        }
        void SanPhamBinding()
        {
            txtMaSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaSP",true,DataSourceUpdateMode.Never));
            txtTenSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txtGiaBan.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "GiaBan", true, DataSourceUpdateMode.Never));
            txtGiaNhap.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "GiaNhap", true, DataSourceUpdateMode.Never));
            dtpNSX.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "NSX", true, DataSourceUpdateMode.Never));
            dtpHSD.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "HSD", true, DataSourceUpdateMode.Never));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "NgayNhap", true, DataSourceUpdateMode.Never));
            cbMaNhaCungCap.DataBindings.Add(new Binding("Text",dtgvSanPham.DataSource,"MaNCC",true, DataSourceUpdateMode.Never));
            cbMaLoaiSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaLSP", true, DataSourceUpdateMode.Never));
        }

        void ThemDanhSachNhaCungCapVaoComboBox()
        {
            cbMaNhaCungCap.DataSource = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
            cbMaNhaCungCap.DisplayMember = "MaNCC";
            cbMaNhaCungCap.ValueMember = "MaNCC";
        }

        void ThemDanhSachLoaiSanPhamVaoComboBox()
        {
            cbMaLoaiSanPham.DataSource = LoaiSanPhamDAO.Instance.DanhSachLoaiSanPham();
            cbMaLoaiSanPham.DisplayMember = "MaLSP";
            cbMaLoaiSanPham.ValueMember = "MaLSP";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int MaSP = Int32.Parse(txtMaSanPham.Text);
            string TenSP = txtTenSanPham.Text;
            int MaLSP = Int32.Parse(cbMaLoaiSanPham.Text);
            int MaNCC = Int32.Parse(cbMaNhaCungCap.Text);
            int SoLuong = Int32.Parse(txtSoLuong.Text);
            string NSX = dtpNSX.Value.ToString();
            string HSD = dtpHSD.Value.ToString();
            string NgayNhap = dtpNgayNhap.Value.ToString();
            float GiaNhap = float.Parse(txtGiaNhap.Text);
            float GiaBan = float.Parse(txtGiaBan.Text);

            if (SanPhamDAO.Instance.ThemSanPham(MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaBan, GiaNhap))
            {
                MessageBox.Show("Thêm thành công");
                LoadSanPham();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaSP = Int32.Parse(txtMaSanPham.Text);
            string TenSP = txtTenSanPham.Text;
            int MaLSP = Int32.Parse(cbMaLoaiSanPham.Text);
            int MaNCC = Int32.Parse(cbMaNhaCungCap.Text);
            int SoLuong = Int32.Parse(txtSoLuong.Text);
            string NSX = dtpNSX.Value.ToString();
            string HSD = dtpHSD.Value.ToString();
            string NgayNhap = dtpNgayNhap.Value.ToString();
            float GiaNhap = float.Parse(txtGiaNhap.Text);
            float GiaBan = float.Parse(txtGiaBan.Text);

            if (SanPhamDAO.Instance.SuaSanPham(MaSP, TenSP, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaBan, GiaNhap))
            {
                MessageBox.Show("Sửa thành công");
                LoadSanPham();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaSP = Int32.Parse(txtMaSanPham.Text);

            if (SanPhamDAO.Instance.XoaSanPham(MaSP))
            {
                MessageBox.Show("Xóa thành công");
                LoadSanPham();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Text = null;
            txtTenSanPham.Text = null;
            cbMaLoaiSanPham.Text = null;
            cbMaNhaCungCap.Text = null;
            txtSoLuong.Text = null;
            dtpNSX.Value = DateTime.Now;
            dtpHSD.Value = DateTime.Now;
            dtpNgayNhap.Value = DateTime.Now;
            txtGiaNhap.Text = null;
            txtGiaBan.Text = null;
        }
    }
}
