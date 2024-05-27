using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BTL_Cuoiky.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class Phieunhap : Form
    {
        public Phieunhap()
        {
            InitializeComponent();
        }
        private void mnuhoadonbanhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hoadonbanhang Hoadon = new Hoadonbanhang();
            Hoadon.ShowDialog();
        }

        private void mnukhachhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKhachhang KH = new frmKhachhang();
            KH.ShowDialog();
        }

        private void mnuKhuyenmai_Click(object sender, EventArgs e)
        {
            this.Hide();
            Khuyenmai KM = new Khuyenmai();
            KM.ShowDialog();
        }

        private void mnuban_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ban Ban = new Ban();
            Ban.ShowDialog();
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien nv = new Nhanvien();
            nv.ShowDialog();
        }

        private void mnuSanpham_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sanpham sp = new Sanpham();
            sp.ShowDialog();
        }

        private void mnuquanlykho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quanlykho kho = new Quanlykho();
            kho.ShowDialog();
        }

        private void mnuPhieuxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Phieuxuat pxuat = new Phieuxuat();
            pxuat.ShowDialog();
        }

        private void mnuNCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhacungcap ncc = new Nhacungcap();
            ncc.ShowDialog();
        }

        private void mnuBaocaobanhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            BCBanhang BCBH = new BCBanhang();
            BCBH.ShowDialog();
        }

        private void mnuBaocaodoanhthu_Click(object sender, EventArgs e)
        {
            this.Hide();
            BCDoanhthu Dt = new BCDoanhthu();
            Dt.ShowDialog();
        }

        private void mnuBctonkho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Baocaotonkho BCTK = new Baocaotonkho();
            BCTK.ShowDialog();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangnhap dn = new frmDangnhap();
            dn.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmhome home = new frmhome();
            home.ShowDialog();
        }


        DataTable tblPN;
        private void Phieunhap_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            btnInphieu.Enabled = false;

            txtMaphieunhap.ReadOnly = true;
            txtTenSP.ReadOnly=true;
            cboMasp.Enabled = false;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;

            Class.Function.FillCombo("SELECT MaNhanVien,TenNhanVien FROM tblNhanVien", cboManhanvien, "MaNhanVien", "TenNhanVien");
            cboManhanvien.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT MaNhaCungCap,TenNhaCungCap FROM tblNhaCungCap", cboManhacungcap, "MaNhaCungCap", "TenNhaCungCap");
            cboManhacungcap.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT MaSanPham FROM tblSanPham", cboMasp, "MaSanPham", "TenSanPham");
            cboMasp.SelectedIndex = -1;
            Class.Function.FillCombo("SELECT MaPhieuNhap FROM tblChiTietPhieuNhap", cboMaphieunhap, "MaPhieuNhap", "MaPhieuNhap");
            cboMaphieunhap.SelectedIndex = -1;

            if (txtMaphieunhap.Text != "")
            {
                Load_Thongtinphieunhap();
                btnBoqua.Enabled = true;
            }
            load_datagridview();

        }
        private void load_datagridview()
        {
            string sql;
            sql = "SELECT a.MaSanPham,b.TenSanPham, a.SoLuong, a.DonGia, a.ChietKhau, a.HanSuDung, a.DonViTinh, a.HinhThucThanhToan, a.ThanhTien FROM tblChiTietPhieuNhap as a INNER JOIN tblSanPham as b ON  a.MaSanPham=b.MaSanPham WHERE MaPhieuNhap='"+txtMaphieunhap.Text+"'";
            tblPN = Class.Function.getdatatotable(sql);
            dgridPhieunhap.DataSource = tblPN;
            dgridPhieunhap.Columns[0].HeaderText = "Mã SP";
            dgridPhieunhap.Columns[1].HeaderText = "Tên SP";
            dgridPhieunhap.Columns[2].HeaderText = "Số lượng";
            dgridPhieunhap.Columns[3].HeaderText = "Đơn giá";
            dgridPhieunhap.Columns[4].HeaderText = "Chiết khấu";
            dgridPhieunhap.Columns[5].HeaderText = "Hạn sử dụng";
            dgridPhieunhap.Columns[6].HeaderText = "Đơn vị";
            dgridPhieunhap.Columns[7].HeaderText = "HTTT";
            dgridPhieunhap.Columns[8].HeaderText = "Thành tiền";
            dgridPhieunhap.AllowUserToAddRows = false;
            dgridPhieunhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_Thongtinphieunhap()
        {
            string sql;
            sql = "SELECT NgayNhap FROM tblPhieunhap WHERE MaPhieuNhap='" + txtMaphieunhap.Text + "'";
            mskNgaylap.Text = Class.Function.Convertdatetime(Class.Function.Getfieldvalues(sql));

            sql = "SELECT MaNhanVien FROM tblPhieuNhap WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
            cboManhanvien.Text = Class.Function.Getfieldvalues(sql);

            sql = "SELECT MaNhaCungCap FROM tblPhieuNhap WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
            cboManhacungcap.Text = Class.Function.Getfieldvalues(sql);

            sql = "SELECT TongTien FROM tblPhieuNhap WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
            txtTongtien.Text = Class.Function.Getfieldvalues(sql);

            lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtDongia.Enabled = true;
            btnBoqua.Enabled = true;
            btnSua.Enabled = false;
            resetvalues();
            txtMaphieunhap.Text = Class.Function.CreateKey("PN");
            load_datagridview();

        }
        private void resetvalues()
        {
            txtMaphieunhap.Text = "";
            mskNgaylap.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            cboManhacungcap.Text= "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMasp.Text = "";
            cboMasp.Enabled = true;
            txtSoluong.Text = "0";
            txtDongia.Text = "0";
            txtChietkhau.Text = "";
            mskHansudung.Text = "";
            txtThanhtien.Text = "0";
            cboMaphieunhap.Text="";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;

            //tblPhieunhap
            sql = "SELECT MaPhieuNhap FROM tblPhieuNhap WHERE MaPhieuNhap=N'" + txtMaphieunhap.Text + "'";
            if (!Class.Function.checkkey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                if (cboManhanvien.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboManhacungcap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhacungcap.Focus();
                    return;
                }
                // Lưu thông tin chung vào bảng tblPhieuNhap
                string ngayNhapFormatted = DateTime.Parse(mskNgaylap.Text.Trim()).ToString("yyyy-MM-dd");
                sql = "INSERT INTO tblPhieuNhap(MaPhieuNhap, NgayNhap, MaNhanVien, MaNhaCungCap, Tongtien) VALUES('"+txtMaphieunhap.Text.Trim()+"', '"+ngayNhapFormatted+"', '"+cboManhanvien.SelectedValue+"','"+cboManhacungcap.SelectedValue+"', '"+txtTongtien.Text+"')";
                Class.Function.runsql(sql);
            }


            //tblChiTietPhieuNhap
            // Lưu thông tin của các mặt hàng
            if (cboMasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMasp.Focus();
                return;
            }
            if (!double.TryParse(txtSoluong.Text, out sl) || sl == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtChietkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chiết khấu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChietkhau.Focus();
                return;
            }
            if (txtDonvitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonvitinh.Focus();
                return;
            }
            if (!double.TryParse(txtDongia.Text, out double dongia))
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongia.Focus();
                return;
            }
            if (txtHTTT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHTTT.Focus();
                return;
            }
            // Kiểm tra mã sản phẩm trong chi tiết phiếu nhập
            sql = "SELECT MaSanPham FROM tblChiTietPhieuNhap WHERE MaSanPham=N'" + cboMasp.Text.Trim() + "' AND MaPhieuNhap = N'" + txtMaphieunhap.Text.Trim() + "'";
            if (Class.Function.checkkey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesSP();
                cboMasp.Focus();
                return;
            }
            // Tính toán thành tiền
            if (!double.TryParse(txtChietkhau.Text, out double chietKhau))
            {
                MessageBox.Show("Bạn phải nhập chiết khấu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChietkhau.Focus();
                return;
            }
            double thanhTien = (sl * dongia) - chietKhau;

            // Chèn dữ liệu vào bảng ChiTietPhieuNhap
            string HSDFormatted = DateTime.Parse(mskHansudung.Text.Trim()).ToString("yyyy-MM-dd");
            sql = "INSERT INTO tblChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuong, DonGia, ChietKhau, DonViTinh, HinhThucThanhToan, HanSuDung, ThanhTien) VALUES(N'" + txtMaphieunhap.Text.Trim() + "', N'" + cboMasp.SelectedValue + "', '" + sl + "', '" + dongia + "', '" + chietKhau + "', '" + txtDonvitinh.Text + "', '" + txtHTTT.Text + "', '" + HSDFormatted + "', '" + thanhTien + "')";
            Class.Function.runsql(sql);
            load_datagridview();

            // Cập nhật lại số lượng của sản phẩm vào bảng tblSanPham
            double soLuongCu = Convert.ToDouble(Class.Function.Getfieldvalues("SELECT SoLuong FROM tblSanPham WHERE MaSanPham= N'" + cboMasp.Text + "'"));
            double soLuongMoi = soLuongCu + sl;
            sql = "UPDATE tblSanPham SET SoLuong =" + soLuongMoi + " WHERE MaSanPham= N'" + cboMasp.Text + "'";
            Class.Function.runsql(sql);

            // Cập nhật lại tổng tiền cho phiếu nhập
            if (double.TryParse(Class.Function.Getfieldvalues("SELECT TongTien FROM tblPhieuNhap WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'"), out double tongTienCu))
            {
                double tongTienMoi = tongTienCu + thanhTien;
                sql = "UPDATE tblPhieuNhap SET TongTien =" + tongTienMoi + " WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
                Class.Function.runsql(sql);
                txtTongtien.Text = tongTienMoi.ToString();
                lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(tongTienMoi.ToString());
            }
            else
            {
                MessageBox.Show("Không thể lấy tổng tiền cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetValuesSP();
            btnThem.Enabled = true;
            btnInphieu.Enabled = true;
            btnBoqua.Enabled = false;
        }
        private void ResetValuesSP()
        {
            cboMasp.Text = "";
            txtSoluong.Text = "0";
            txtChietkhau.Text = "";
            txtDongia.Text = "0";
            txtHTTT.Text = "";
            mskHansudung.Text = "";
            txtDonvitinh.Text = "";
            txtThanhtien.Text = "0";
            cboManhanvien.Text = "";
            cboManhacungcap.Text = "";
            cboMaphieunhap.Text = "";
            mskNgaylap.Text = "";
            txtTenSP.Text = "";
        }
        private void dgridPhieunhap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMasp.Focus();
                return;
            }
            if (tblPN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMasp.Text = dgridPhieunhap.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTenSP.Text = dgridPhieunhap.CurrentRow.Cells["TenSanPham"].Value.ToString();
            txtSoluong.Text = dgridPhieunhap.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDongia.Text = dgridPhieunhap.CurrentRow.Cells["DonGia"].Value.ToString();
            txtChietkhau.Text = dgridPhieunhap.CurrentRow.Cells["ChietKhau"].ToString();
            mskHansudung.Text = dgridPhieunhap.CurrentRow.Cells["HanSuDung"].Value.ToString();
            txtDonvitinh.Text = dgridPhieunhap.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtHTTT.Text = dgridPhieunhap.CurrentRow.Cells["HinhThucThanhToan"].Value.ToString();
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            if (tblPN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (cboMasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMasp.Focus();
                return;
            }
          if (!double.TryParse(txtSoluong.Text, out sl) || sl == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtChietkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chiết khấu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChietkhau.Focus();
                return;
            }
            if (txtDonvitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonvitinh.Focus();
                return;
            }
            if (!double.TryParse(txtDongia.Text, out double dongia))
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongia.Focus();
                return;
            }
            if (txtHTTT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHTTT.Focus();
                return;
            }
            // Kiểm tra mã sản phẩm trong chi tiết phiếu nhập
            sql = "SELECT MaSanPham FROM tblChiTietPhieuNhap WHERE MaSanPham=N'" + cboMasp.Text.Trim() + "' AND MaPhieuNhap = N'" + txtMaphieunhap.Text.Trim() + "'";
            if (Class.Function.checkkey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesSP();
                cboMasp.Focus();
                return;
            }
            if (!double.TryParse(txtChietkhau.Text, out double chietKhau))
            {
                MessageBox.Show("Bạn phải nhập chiết khấu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChietkhau.Focus();
                return;
            }
            double thanhTien = (sl * dongia) - chietKhau;

            // Chèn dữ liệu vào bảng ChiTietPhieuNhap
            string HSDFormatted = DateTime.Parse(mskHansudung.Text.Trim()).ToString("yyyy-MM-dd");
            sql = "UPDATE tblChiTietPhieuNhap SET SoLuong = " + sl + ", DonGia = " + dongia + ", ChietKhau = " + chietKhau +", HanSuDung = '" + HSDFormatted + "', DonViTinh = N'" + txtDonvitinh.Text.Trim() + "', HinhThucThanhToan = N'" + txtHTTT.Text.Trim() + "', ThanhTien = " + thanhTien +" WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text.Trim() + "' AND MaSanPham = N'" + cboMasp.SelectedValue + "'";
            Class.Function.runsql(sql);
            //sql = "UPDATE tblChiTietPhieuNhap SET MaPhieuNhap=N'" + txtMaphieunhap.Text.Trim() + "', MaSanPham, SoLuong, DonGia, ChietKhau, DonViTinh, HinhThucThanhToan, HanSuDung, ThanhTien) VALUES(, N'" + cboMasp.SelectedValue + "', '" + sl + "', '" + dongia + "', '" + chietKhau + "', '" + txtDonvitinh.Text + "', '" + txtHTTT.Text + "', '" + HSDFormatted + "', '" + thanhTien + "')";
            //Class.Function.runsql(sql);
            load_datagridview();

            // Cập nhật lại số lượng của sản phẩm vào bảng tblSanPham
            double soLuongCu = Convert.ToDouble(Class.Function.Getfieldvalues("SELECT SoLuong FROM tblSanPham WHERE MaSanPham= N'" + cboMasp.Text + "'"));
            double soLuongMoi = soLuongCu + sl;
            sql = "UPDATE tblSanPham SET SoLuong =" + soLuongMoi + " WHERE MaSanPham= N'" + cboMasp.Text + "'";
            Class.Function.runsql(sql);

            // Cập nhật lại tổng tiền cho phiếu nhập
            if (double.TryParse(Class.Function.Getfieldvalues("SELECT TongTien FROM tblPhieuNhap WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'"), out double tongTienCu))
            {
                double tongTienMoi = tongTienCu + thanhTien;
                sql = "UPDATE tblPhieuNhap SET TongTien =" + tongTienMoi + " WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
                Class.Function.runsql(sql);
                txtTongtien.Text = tongTienMoi.ToString();
                lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(tongTienMoi.ToString());
            }
            else
            {
                MessageBox.Show("Không thể lấy tổng tiền cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Class.Function.runsql(sql);
            load_datagridview();
            resetvalues();
            btnBoqua.Enabled = false;

        }
        private void dgridPhieunhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp;
            Double Thanhtien;
            if (tblPN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masp = dgridPhieunhap.CurrentRow.Cells["MaSanPham"].Value.ToString();
                DelSP(txtMaphieunhap.Text, masp);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(dgridPhieunhap.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMaphieunhap.Text, Thanhtien);
                load_datagridview();
            }  
        }
        private void DelSP(string MaPhieuNhap, string MaSanPham)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT SoLuong FROM tblChiTietPhieuNhap WHERE MaPhieuNhap = N'" + MaPhieuNhap + "' AND MaSanPham = N'" + MaSanPham + "'";
            s = Convert.ToDouble(Class.Function.Getfieldvalues(sql));
            sql = "DELETE tblChiTietPhieuNhap WHERE MaPhieuNhap=N'" + MaPhieuNhap + "' AND MaSanPham = N'"+ MaSanPham + "'";
            Class.Function.Runsqldel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT SoLuong FROM tblSanPham WHERE MaSanPham = N'" + MaSanPham + "'";
            sl = Convert.ToDouble(Class.Function.Getfieldvalues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblSanPham SET SoLuong =" + SLcon + " WHERE MaSanPham= N'" + MaSanPham + "'";
            Class.Function.runsql(sql);
        }
        private void DelUpdateTongtien(string Maphieunhap, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT TongTien FROM tblPhieuNhap WHERE MaPhieuNhap = N'" + Maphieunhap + "'";
            Tong = Convert.ToDouble(Class.Function.Getfieldvalues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblPhieuNhap SET TongTien =" + Tongmoi + " WHERE MaPhieuNhap = N'" +Maphieunhap + "'";
            Class.Function.runsql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Class.Function.ChuyenSoSangChu(Tongmoi.ToString());
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] MaSP = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT MaSanPham FROM tblChiTietPhieuNhap WHERE MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Class.Function.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaSP[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelSP(txtMaphieunhap.Text, MaSP[i]);
                //Xóa hóa đơn
                sql = "DELETE tblPhieuNhap WHERE MaPhieuNhap=N'" + txtMaphieunhap.Text + "'";
                Class.Function.Runsqldel(sql);
                resetvalues();
                load_datagridview();

            }
        }
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, ck;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtChietkhau.Text == "")
                ck = 0;
            else
                ck = Convert.ToDouble(txtChietkhau.Text);
            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg * ck / 100;
            txtThanhtien.Text = tt.ToString();
        }
        private void txtChietkhau_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, ck;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtChietkhau.Text == "")
                ck = 0;
            else
                ck = Convert.ToDouble(txtChietkhau.Text);
            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg * ck / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnInphieu_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            exRange = exSheet.Cells[1, 1];
            exRange.Font.Size = 10;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 5;
            exRange.MergeCells = true;
            exRange.Value = "Coffee KaNa";
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange = exSheet.Cells[2, 1];
            exRange.Font.Size = 10;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Hà Nội";
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange = exSheet.Cells[3, 1];
            exRange.Font.Size = 10;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Điện thoại: (04)37562222";
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange = exSheet.Cells[5, 3];
            exRange.Font.Size = 16;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "PHIẾU NHẬP HÀNG";
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            //Lấy thông tin của một hóa đơn
            sql = "SELECT a.MaPhieuNhap, a.NgayNhap, a.TongTien, b.TenNhanVien, c.TenNhaCungCap, c.DiaChi, c.SoDienThoai FROM tblPhieuNhap AS a INNER JOIN tblNhanVien AS b ON a.MaNhanVien = b.MaNhanVien INNER JOIN  tblNhaCungCap AS c ON a.MaNhaCungCap = c.MaNhaCungCap WHERE a.MaPhieuNhap = N'" + txtMaphieunhap.Text + "'";
            tblThongtinHD = Class.Function.getdatatotable(sql);

            exRange = exSheet.Cells[7, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Mã phiếu nhập:";
            exRange = exSheet.Cells[7, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][0].ToString();

            exRange = exSheet.Cells[8, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Ngày nhập:";
            exRange = exSheet.Cells[8, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][1].ToString();

            exRange = exSheet.Cells[9, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Nhân viên:";
            exRange = exSheet.Cells[9, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][3].ToString();

            exRange = exSheet.Cells[10, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Nhà cung cấp:";
            exRange = exSheet.Cells[10, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][4].ToString();

            exRange = exSheet.Cells[11, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Địa chỉ:";
            exRange = exSheet.Cells[11, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][5].ToString();

            exRange = exSheet.Cells[12, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Điện thoại:";
            exRange = exSheet.Cells[12, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][6].ToString();


            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSanPham, a.SoLuong, a.DonGia, a.ChietKhau, a.HanSuDung, a.DonViTinh, a.HinhThucThanhToan, a.ThanhTien FROM tblChiTietPhieuNhap as a INNER JOIN tblSanPham as b ON  a.MaSanPham=b.MaSanPham WHERE MaPhieuNhap='" + txtMaphieunhap.Text + "'";
            tblThongtinHang = Class.Function.getdatatotable(sql);

            //Tạo dòng tiêu đề bảng
            exRange = exSheet.Cells[14, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "STT";
            exRange = exSheet.Cells[14, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Tên hàng";
            exRange = exSheet.Cells[14, 3];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Số lượng";
            exRange = exSheet.Cells[14, 4];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Đơn giá";
            exRange = exSheet.Cells[14, 5];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Chiết khấu";
            exRange = exSheet.Cells[14, 6];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Hạn sử dụng";
            exRange = exSheet.Cells[14, 7];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Đơn vị tính";
            exRange = exSheet.Cells[14, 8];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Hình thức thanh toán";
            exRange = exSheet.Cells[14, 9];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự cột 1
                exSheet.Cells[15 + hang, 1] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                //Điền thông tin hàng từ cột thứ 2
                {
                    exSheet.Cells[15 + hang, cot + 2] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }
            exRange = exSheet.Cells[16 + hang, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Tổng tiền:";
            exRange = exSheet.Cells[16 + hang, 6];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[17 + hang, 1];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Bằng chữ:";
            exRange = exSheet.Cells[17 + hang, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = Class.Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());

            exRange = exSheet.Cells[19 + hang, 3];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Hà Nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exRange = exSheet.Cells[20 + hang, 2];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Nhân viên lập phiếu";
            exRange = exSheet.Cells[20 + hang, 4];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Thủ kho";
            exRange = exSheet.Cells[20 + hang, 6];
            exRange.Font.Size = 12;
            exRange.Font.Name = "Times new roman";
            exRange.Font.Bold = true;
            exRange.MergeCells = true;
            exRange.Value = "Giám đốc";
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaphieunhap.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã phiếu nhập để tìm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaphieunhap.Focus();
                return;
            }
            txtMaphieunhap.Text = cboMaphieunhap.Text;
            Load_Thongtinphieunhap();
            load_datagridview();
            btnLuu.Enabled = true;
            btnInphieu.Enabled = true;
            cboMaphieunhap.SelectedIndex = -1;

        }
        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }
        private void cboMaphieunhap_DropDown(object sender, EventArgs e)
        {
            Class.Function.FillCombo("SELECT MaPhieuNhap FROM tblPhieuNhap", cboMaphieunhap, "MaPhieuNhap","MaPhieuNhap");
            cboMaphieunhap.SelectedIndex = -1;

        }

        private void Phieunhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            resetvalues();

        }
        private void btnBoqua_Click(object sender, EventArgs e)
        {
            cboMasp.Text = "";
            txtSoluong.Text = "0";
            txtHTTT.Text = "";
            txtDonvitinh.Text = "";
            txtChietkhau.Text = "0";
            txtDongia.Text= "0";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnInphieu.Enabled = true;
            btnThoat.Enabled = true;
        }
        private void cboMasp_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMasp.Text == "")
                txtTenSP.Text = "";
            str = "Select TenSanPham from tblSanPham where MaSanPham =N'" +cboMasp.SelectedValue + "'";
            txtTenSP.Text = Class.Function.Getfieldvalues(str);
        }

        
    }
}
