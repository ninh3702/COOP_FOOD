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
    public partial class fChiTietHoaDon : Form
    {
        public fChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon();
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
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        BindingSource danhsachChiTietHoaDon = new BindingSource();
        private void fChiTietHoaDon_Load(object sender, EventArgs e)
        {
           
        
            LoadChiTietHoaDon();

            dtgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            HoaDonDAO.Instance.ThemDanhSachMaHoaDonVaoComboBox(cbMaHoaDon);
            SanPhamDAO.Instance.ThemDanhSachMaSanPhamVaoComboBox(cbMaSanPham);
            //ChiTietHoaDonBinding();

        }
        void LoadChiTietHoaDon()
        {
            if(cbMaHoaDon.ValueMember == "")
            {
                danhsachChiTietHoaDon.DataSource = ChiTietHoaDonDAO.Instance.DanhSachChiTietHoaDon();
            }
            else if(cbMaHoaDon.ValueMember != "")
            {
                string MaHD = cbMaHoaDon.Text;

                danhsachChiTietHoaDon.DataSource = ChiTietHoaDonDAO.Instance.DanhSachChiTietHoaDonTheoMaHoaDon(MaHD);
            }
                
            dtgvChiTietHoaDon.DataSource = danhsachChiTietHoaDon.DataSource;
            BindingClear();
            ChiTietHoaDonBinding();
        }
        void ChiTietHoaDonBinding()
        {
            cbMaHoaDon.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            cbMaSanPham.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "MaSP", true, DataSourceUpdateMode.Never));
            txtGiaSanPham.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "GiaSP", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgvChiTietHoaDon.DataSource, "SoLuongBan", true, DataSourceUpdateMode.Never));
        }
        public void BindingClear()
        {
            cbMaHoaDon.DataBindings.Clear();
            cbMaSanPham.DataBindings.Clear();
            txtGiaSanPham.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int MaHD = Int32.Parse(cbMaHoaDon.Text);
            int MaSP = Int32.Parse(cbMaSanPham.Text);
            int SoLuongBan = Int32.Parse(txtSoLuong.Text);
            float GiaSP = float.Parse(txtGiaSanPham.Text);


            if (ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(MaHD, MaSP, SoLuongBan, GiaSP))
            {
                string tongtien = ChiTietHoaDonDAO.Instance.convertDataTableToString(HoaDonDAO.Instance.HienThiTongTien(MaHD));
                HoaDonDAO.Instance.HienThiTongTienSQL(MaHD, tongtien);
                MessageBox.Show("Thêm thành công");
                LoadChiTietHoaDon();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int MaHD = Int32.Parse(cbMaHoaDon.Text);
            int MaSP = Int32.Parse(cbMaSanPham.Text);
            int SoLuongBan = Int32.Parse(txtSoLuong.Text);
            float GiaSP = float.Parse(txtGiaSanPham.Text);
            
            if (ChiTietHoaDonDAO.Instance.SuaChiTietHoaDon(MaHD, MaSP, SoLuongBan, GiaSP))
            {
                string tongtien = ChiTietHoaDonDAO.Instance.convertDataTableToString(HoaDonDAO.Instance.HienThiTongTien(MaHD));
                HoaDonDAO.Instance.HienThiTongTienSQL(MaHD, tongtien);
                MessageBox.Show("Sửa thành công");
                LoadChiTietHoaDon();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaHD = Int32.Parse(cbMaHoaDon.Text);
            int MaSP = Int32.Parse(cbMaSanPham.Text);
            if (ChiTietHoaDonDAO.Instance.XoaChiTietHoaDon(MaHD,MaSP))
            {
                string tongtien = ChiTietHoaDonDAO.Instance.convertDataTableToString(HoaDonDAO.Instance.HienThiTongTien(MaHD));
                HoaDonDAO.Instance.HienThiTongTienSQL(MaHD, tongtien);
                MessageBox.Show("Xóa thành công");
                LoadChiTietHoaDon();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }

        }
        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            
            cbMaHoaDon.Text = "";
            cbMaSanPham.Text = "";
            cbMaSanPham.Text = "";
            txtGiaSanPham.Text = "";
            txtSoLuong.Text = "";
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && cbMaSanPham.Text != "" && cbMaSanPham.Text != "")
            {
                int MaSP = Int32.Parse(cbMaSanPham.Text);
                int SoLuongBan = Int32.Parse(txtSoLuong.Text);


                float GiaSP = float.Parse(ChiTietHoaDonDAO.Instance.convertDataTableToString(ChiTietHoaDonDAO.Instance.LayGiaSanPham(MaSP)));

                txtGiaSanPham.Text = (GiaSP * (float)SoLuongBan).ToString();
            }
        }
        private void cbMaSanPham_DropDownClosed(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && cbMaSanPham.Text != "" && cbMaSanPham.Text != "")
            {
                int MaSP = Int32.Parse(cbMaSanPham.Text);
                int SoLuongBan = Int32.Parse(txtSoLuong.Text);


                float GiaSP = float.Parse(ChiTietHoaDonDAO.Instance.convertDataTableToString(ChiTietHoaDonDAO.Instance.LayGiaSanPham(MaSP)));

                txtGiaSanPham.Text = (GiaSP * (float)SoLuongBan).ToString();
            }
        }
        private void cbMaHoaDon_DropDownClosed(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }


    }
}
