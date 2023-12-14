using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_BTL.DAO;

namespace WinForm_BTL
{
    public partial class fHoaDon : Form
    {
        public fHoaDon()
        {
            InitializeComponent();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
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
        BindingSource danhsachHoaDon = new BindingSource();
        private void fHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            HoaDonBinding();
            dtgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        void LoadHoaDon()
        {
            danhsachHoaDon.DataSource = HoaDonDAO.Instance.DanhSachHoaDon();
            dtgvHoaDon.DataSource = danhsachHoaDon.DataSource;
            
        }
        void HoaDonBinding()
        {
            txtMaHoaDon.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            txtMaNhanVien.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            cbMaKhachHang.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            dtpNgayMua.DataBindings.Add(new Binding("Value", dtgvHoaDon.DataSource, "NgayMua", true, DataSourceUpdateMode.Never));
            //txtTongTien.DataBindings.Add(new Binding("Text", dtgvHoaDon.DataSource, "TongTien", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int MaHD = Int32.Parse(txtMaHoaDon.Text);
            int MaNV = Int32.Parse(txtMaNhanVien.Text);
            int MaKH = Int32.Parse(cbMaKhachHang.Text);
            string NgayMua = dtpNgayMua.Value.ToString();
            string TongTien = txtTongTien.Text;


            if (HoaDonDAO.Instance.ThemHoaDon(MaHD,MaNV,MaKH,NgayMua,TongTien))
            {
                MessageBox.Show("Thêm thành công");
                LoadHoaDon();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaHD = Int32.Parse(txtMaHoaDon.Text);
            int MaNV = Int32.Parse(txtMaNhanVien.Text);
            int MaKH = Int32.Parse(cbMaKhachHang.Text);
            string NgayMua = dtpNgayMua.Value.ToString();
            string TongTien = txtTongTien.Text;

            if (HoaDonDAO.Instance.SuaHoaDon(MaHD, MaNV, MaKH, NgayMua, TongTien))
            {
                MessageBox.Show("Sửa thành công");
                LoadHoaDon();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaHD = Int32.Parse(txtMaHoaDon.Text);

            if (HoaDonDAO.Instance.XoaHoaDon(MaHD))
            {
                MessageBox.Show("Xóa thành công");
                LoadHoaDon();             
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = "";
            txtMaNhanVien.Text = "";
            cbMaKhachHang.Text = "";
            dtpNgayMua.Value = DateTime.Now;
            LoadHoaDon();
        }

        /*        void ThemDanhSachKhachHangVaoComboBox()
{
cbMaKhachHang.DataSource = NhaCungCapDAO.Instance.DanhSachNhaCungCap();
cbMaKhachHang.DisplayMember = "MaKH";
cbMaKhachHang.ValueMember = "MaKH";
}*/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text != "")
            {
                int MaHD = Int32.Parse(txtMaHoaDon.Text);
                string TongTien = ChiTietHoaDonDAO.Instance.convertDataTableToString(HoaDonDAO.Instance.HienThiTongTien(MaHD));

                txtTongTien.Text = TongTien;
            }
            else if (txtMaHoaDon.Text == "")
            {
                txtMaHoaDon.Text = "";
            }
        }
    }
}
