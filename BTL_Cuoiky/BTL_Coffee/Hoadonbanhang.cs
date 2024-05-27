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
using COMExcel = Microsoft.Office.Interop.Excel;
using BTL_Cuoiky.Class;

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class Hoadonbanhang : Form
    {
        public Hoadonbanhang()
        {
            InitializeComponent();
        }

        private void btnLaythongtinKH_Click(object sender, EventArgs e)
        {
            frmKhachhang khachhang = new frmKhachhang();
            khachhang.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmhome home = new frmhome();
            home.ShowDialog();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmhome home = new frmhome();
            home.ShowDialog();
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
            Ban ban = new Ban();
            ban.ShowDialog();
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien NV = new Nhanvien();
            NV.ShowDialog();
        }

        private void mnuSanpham_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sanpham SP = new Sanpham();
            SP.ShowDialog();
        }

        private void mnuquanlykho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quanlykho QLK = new Quanlykho();
            QLK.ShowDialog();
        }

        private void mnuPhieunhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Phieunhap pnhap = new Phieunhap();
            pnhap.ShowDialog();
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
            Nhacungcap NCC = new Nhacungcap();
            NCC.ShowDialog();
        }

        private void mnuBaocaobanhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            BCBanhang bcbh = new BCBanhang();
            bcbh.ShowDialog();
        }

        private void mnuBaocaodoanhthu_Click(object sender, EventArgs e)
        {
            this.Hide();
            BCDoanhthu dt = new BCDoanhthu();
            dt.ShowDialog();
        }

        private void mnuBctonkho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Baocaotonkho bchtk = new Baocaotonkho();
            bchtk.ShowDialog();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangnhap dn = new frmDangnhap();
            dn.ShowDialog();
        }

        private void Hoadonbanhang_Load(object sender, EventArgs e)
        {
            Function.Connect();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMahoadon.ReadOnly = true;
            txtTennv.ReadOnly = true;
            txtTenkhachhang.ReadOnly = true;
            txtTensp.ReadOnly = true;
            txtGiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";

            Function.FillCombo("Select MaNhanVien,TenNhanVien from tblNhanVien", cboManv, "MaNhanVien", "MaNhanVien");
            cboManv.SelectedIndex = -1;
            Function.FillCombo("SELECT MaKhachHang, TenKhachHang from tblKhachHang", cboMakhachhang, "MaKhachHang", "MaKhachHang");
            cboMakhachhang.SelectedIndex = -1;
            Function.FillCombo("Select MaLoai,TenLoai from tblLoaiSanPham", cboMaloai, "MaLoai", "TenLoai");
            cboMaloai.SelectedIndex = -1;
            Function.FillCombo("Select MaSanPham,TenSanPham from tblSanPham", cboMasp, "MaSanPham", "MaSanPham");
            cboMasp.SelectedIndex = -1;
            Function.FillCombo("Select MaBan, TenBan from tblBan", cboMaban, "MaBan", "MaBan");
            cboMaban.SelectedIndex = -1;
            Function.FillCombo("Select MaKhuyenMai,TenKhuyenMai from tblKhuyenMai", cboKhuyenmai, "MaKhuyenMai", "TenKhuyenMai");
            cboKhuyenmai.SelectedIndex = -1;
            Function.FillCombo("Select MaHoaDon from tblChiTietHoaDonBan", cboMahoadon, "MaHoaDon", "MaHoaDon");
            cboMahoadon.SelectedIndex = -1;

            if (txtMahoadon.Text != "")
            {
                load_ThongtinHD();
                btnHuyhoadon.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            load_datagridhdb();
        }
        DataTable tblCTHDB;

        private void LoadDataAfterInsert(string maHD)
        {
            string sql;
            sql = $"Select a.MaSanPham, b.TenSanPham, a.SoLuong, b.GiaBan, a.GiamGia, a.ThanhTien from tblChiTietHoaDonBan AS a INNER JOIN  tblSanPham AS b ON a.MaSanPham=b.MaSanPham WHERE MaHoaDon = '{maHD}'";
            tblCTHDB = Function.getdatatotable(sql);
            dgridhoadonbh.DataSource = tblCTHDB;
            dgridhoadonbh.Columns[0].HeaderText = "Mã sản phẩm";
            dgridhoadonbh.Columns[1].HeaderText = "Tên sản phẩm";
            dgridhoadonbh.Columns[2].HeaderText = "Số lượng";
            dgridhoadonbh.Columns[3].HeaderText = "Đơn giá bán";
            dgridhoadonbh.Columns[4].HeaderText = "Giảm giá %";
            dgridhoadonbh.Columns[5].HeaderText = "Thành tiền";
            dgridhoadonbh.AllowUserToAddRows = false;
            dgridhoadonbh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void load_datagridhdb()
        {
            string sql;
            sql = "Select a.MaSanPham, b.TenSanPham, a.SoLuong, b.GiaBan, a.GiamGia, a.ThanhTien from tblChiTietHoaDonBan AS a INNER JOIN  tblSanPham AS b ON a.MaSanPham=b.MaSanPham";
            tblCTHDB = Function.getdatatotable(sql);
            dgridhoadonbh.DataSource = tblCTHDB;
            dgridhoadonbh.Columns[0].HeaderText = "Mã sản phẩm";
            dgridhoadonbh.Columns[1].HeaderText = "Tên sản phẩm";
            dgridhoadonbh.Columns[2].HeaderText = "Số lượng";
            dgridhoadonbh.Columns[3].HeaderText = "Đơn giá bán";
            dgridhoadonbh.Columns[4].HeaderText = "Giảm giá %";
            dgridhoadonbh.Columns[5].HeaderText = "Thành tiền";
            dgridhoadonbh.AllowUserToAddRows = false;
            dgridhoadonbh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void load_ThongtinHD()
        {
            string sql;
            sql = "Select NgayBan from tblHoaDonBan where MaHoaDon  = N'" + txtMahoadon.Text + "'";

            mskNgaylap.Value = DateTime.Parse(Function.Getfieldvalues(sql));

            sql = "select MaNhanVien from tblHoaDonBan where MaHoaDon = N'" + txtMahoadon.Text + "'";
            cboManv.Text = Function.Getfieldvalues(sql);

            sql = "select MaKhuyenMai from tblChiTietHoaDonBan where MaHoaDon = N'" + txtMahoadon.Text + "'";
            cboKhuyenmai.Text = Function.Getfieldvalues(sql);

            sql = "select HinhThucThanhToan from tblChiTietHoaDonBan where MaHoaDon = N'" + txtMahoadon.Text + "'";
            txtHinhthuctt.Text = Function.Getfieldvalues(sql);

            sql = "select MaBan from tblHoaDonBan where MaHoaDon = N'" + txtMahoadon.Text + "'";
            cboManv.Text = Function.Getfieldvalues(sql);

            sql = "select MaKhachHang from tblHoaDonBan where MaHoaDon = N'" + txtMahoadon.Text + "'";
            cboMakhachhang.Text = Function.Getfieldvalues(sql);

            sql = "select TongTien from tblHoaDonBan where MaHoaDon = N'" + txtMahoadon.Text + "'";
            txtTongtien.Text = Function.Getfieldvalues(sql);
            lbltongtienbangchu.Text = "Tổng tiền bằng chữ: " + Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dgridhoadonbh.DataSource = null;
            btnHuyhoadon.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMahoadon.Text = Function.CreateKey("HDB");
        }
        private void ResetValues()
        {
            txtMahoadon.Text = "";
            mskNgaylap.Text = "";
            cboManv.Text = "";
            cboMakhachhang.Text = "";
            txtHinhthuctt.Text = "";
            cboKhuyenmai.Text = "";
            txtTongtien.Text = "0";
            lbltongtienbangchu.Text = "Tổng tiền bằng chữ: ";
            cboMaloai.Text = "";
            cboMasp.Text = "";
            cboMaban.Text = "";
            txtSoluong.Text = "";
            txtGiaban.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHoaDon FROM tblHoaDonBan WHERE MaHoaDon=N'" + txtMahoadon.Text + "'";
            if (!Function.checkkey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (mskNgaylap.Text == "    /   /")
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskNgaylap.Focus();
                    return;
                }
                if (!Function.Isdate(mskNgaylap.Text))
                {
                    MessageBox.Show("Bạn phải nhập lại ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskNgaylap.Text = "";
                    mskNgaylap.Focus();
                    return;
                }

                if (cboManv.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManv.Focus();
                    return;
                }
                if (cboMakhachhang.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMakhachhang.Focus();
                    return;
                }
                if (cboMaban.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaban.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban    
                sql = "INSERT INTO tblHoaDonBan(MaHoaDon, NgayBan, MaNhanVien, MaKhachHang, MaBan, TongTien) VALUES(N'" + txtMahoadon.Text.Trim() + "', '" + Function.Convertdatetime(mskNgaylap.Text) + "', N'" + cboManv.SelectedValue + "', N'" + cboMakhachhang.SelectedValue + "', N'" + cboMaban.SelectedValue + "'," + txtTongtien.Text + ")";
                Function.runsql(sql);
            }

            // Lưu thông tin của trong chi tiết hóa đơn 
            if (cboMasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMasp.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            if (txtHinhthuctt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHinhthuctt.Focus();
                return;
            }
            
            sql = "SELECT MaSanPham FROM tblChiTietHoaDonBan WHERE MaSanPham = N'" + cboMasp.SelectedValue + "' AND MaHoaDon = N'" + txtMahoadon.Text.Trim() + "'";
            if (Function.checkkey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMasp.Focus();
                return;
            }

            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Function.Getfieldvalues("SELECT SoLuong FROM tblSanPham WHERE MaSanPham = N'" + cboMasp.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblChiTietHoaDonBan(MaHoaDon,MaSanPham,SoLuong,DonGiaBan,GiamGia,HinhThucThanhToan,ThanhTien,MaKhuyenMai) ";
            sql +=  $"VALUES(N'{txtMahoadon.Text.Trim()}', N'{cboMasp.SelectedValue}',{txtSoluong.Text},{txtGiaban.Text},{txtGiamgia.Text},N'{txtHinhthuctt.Text.Trim()}',{txtThanhtien.Text},N'{cboKhuyenmai.SelectedValue}')";
            Function.runsql(sql);
            LoadDataAfterInsert(txtMahoadon.Text.Trim());

            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblSanPham SET SoLuong =" + SLcon + " WHERE MaSanPham= N'" + cboMasp.SelectedValue + "'";
            Function.runsql(sql);

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Function.Getfieldvalues("SELECT TongTien FROM tblHoaDonBan WHERE MaHoaDon = N'" + txtMahoadon.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblHoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHoaDon = N'" + txtMahoadon.Text + "'";
            Function.runsql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lbltongtienbangchu.Text = "Tổng tiền bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnHuyhoadon.Enabled = true;
            btnThem.Enabled = true;
            btnInhoadon.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMasp.Text = "";
            txtSoluong.Text = "0";
            txtGiaban.Text = "0";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }
        //Kiểm tra đk nhập của Số lượng và giảm giá
        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8) || e.KeyChar == '.')
            {
                // Kiểm tra nếu ký tự là dấu chấm thập phân và dấu chấm thập phân đã tồn tại trong văn bản
                if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        //Xóa một hàng trong datagrid
        private void dgridhoadonbh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp;
            Double Thanhtien;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                masp = dgridhoadonbh.CurrentRow.Cells["MaSanPham"].Value.ToString();

                if (string.IsNullOrEmpty(txtMahoadon.Text) || string.IsNullOrEmpty(masp))
                {
                    MessageBox.Show("Ban phải chọn hóa đơn và sản phẩm muốn xóa");

                    return;
                }

                DelHang(txtMahoadon.Text, masp);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(dgridhoadonbh.CurrentRow.Cells["ThanhTien"].Value.ToString());
                DelUpdateTongtien(txtMahoadon.Text, Thanhtien);
                load_datagridhdb();
            }
        }
        private void DelHang(string Mahoadon, string Masp)
        {

            Double s, sl, SLcon;
            string sql;
            sql = "SELECT SoLuong FROM tblChiTietHoaDonBan WHERE MaHoaDon = N'" + Mahoadon + "' AND MaSanPham = N'" + Masp + "'";
            s = Convert.ToDouble(Function.Getfieldvalues(sql));
            sql = "DELETE tblChiTietHoaDonBan WHERE MaHoaDon=N'" + Mahoadon + "' AND MaSanPham = N'" + Masp + "'";
            Function.runsql(sql);

            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT SoLuong FROM tblSanPham WHERE MaSanPham = N'" + Masp + "'";
            sl = Convert.ToDouble(Function.Getfieldvalues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblSanPham SET SoLuong =" + SLcon + " WHERE MaSanPham= N'" + Masp + "'";
            Function.runsql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT TongTien FROM tblHoaDonBan WHERE MaHoaDon = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Function.Getfieldvalues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblHoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHoaDon = N'" + Mahoadon + "'";
            Function.runsql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lbltongtienbangchu.Text = "Tổng tiền bằng chữ: " + Function.ChuyenSoSangChu(Tongmoi.ToString());
        }

        //Hủy hóa đơn
        private void btnHuyhoadon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Masp = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT MaSanPham FROM tblChiTietHoaDonBan WHERE MaHoaDon = N'" + txtMahoadon.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Function.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Masp[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();

                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMahoadon.Text, Masp[i]);

                //Xóa hóa đơn
                sql = "DELETE tblHoaDonBan WHERE MaHoaDon=N'" + txtMahoadon.Text + "'";
                Function.runsql(sql);
                ResetValues();
                load_datagridhdb();
                btnHuyhoadon.Enabled = false;
                btnInhoadon.Enabled = false;
            }
        }

        private void cboManv_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboManv.Text == "")
                txtTennv.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            sql = "Select TenNhanVien from tblNhanVien where MaNhanVien = N'" + cboManv.SelectedValue + "'";
            txtTennv.Text = Function.Getfieldvalues(sql);
        }

        private void cboMakhachhang_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMakhachhang.Text == "")
                txtTenkhachhang.Text = "";
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            sql = "Select TenKhachHang from tblKhachHang where MaKhachHang = N'" + cboMakhachhang.SelectedValue + "'";
            txtTenkhachhang.Text = Function.Getfieldvalues(sql);
        }

        private void cboMasp_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMasp.Text == "")
            {
                txtTensp.Text = "";
                txtGiaban.Text = "";
            }
            // Khi kich chon Ma san pham thi ten hang va gia ban se tu dong hien ra
            sql = "SELECT TenSanPham FROM tblSanPham WHERE MaSanPham =N'" + cboMasp.SelectedValue + "'";
            txtTensp.Text = Function.Getfieldvalues(sql);
            sql = "SELECT GiaBan FROM tblSanPham WHERE MaSanPham =N'" + cboMasp.SelectedValue + "'";
            txtGiaban.Text = Function.Getfieldvalues(sql);
        }

        //Khi thay đổi Số lượng, Giảm giá thì Thành tiền tự động cập nhật lại giá trị
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtGiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();

        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, gb, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtGiaban.Text == "")
                gb = 0;
            else
                gb = Convert.ToDouble(txtGiaban.Text);
            tt = sl * gb - sl * gb * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        //In hóa đơn
        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; 
            COMExcel.Worksheet exSheet; 
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinSP;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "KANA Coffee";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)57082495";

            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN HÀNG";

            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDon, a.NgayBan, a.TongTien, b.TenKhachHang, b.SoDienThoai, c.TenNhanVien FROM tblHoaDonBan AS a INNER JOIN tblKhachHang AS b ON a.MaKhachHang = b.MaKhachHang INNER JOIN tblNhanVien AS c  ON a.MaNhanVien = c.MaNhanVien Where MaHoaDon = N'"+txtMahoadon.Text+"'";
            tblThongtinHD = Function.getdatatotable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Điện thoại:";
            exRange.Range["C8:D8"].MergeCells = true;
            exRange.Range["C8:D8"].Value = tblThongtinHD.Rows[0][4].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSanPham, a.SoLuong, a.DonGiaBan, a.GiamGia, a.ThanhTien  FROM tblChiTietHoaDonBan  AS a INNER JOIN tblSanPham AS b ON a.MaSanPham = b.MaSanPham Where MaHoaDon = N'" + txtMahoadon.Text + "'";
            tblThongtinSP = Function.getdatatotable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sản phẩm";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinSP.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinSP.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinSP.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][5];
            exSheet.Name = "Hóa đơn bán hàng";
            exApp.Visible = true;
        }

        private void cboMahoadon_DropDown(object sender, EventArgs e)
        {
            Function.FillCombo("SELECT MaHoaDon FROM tblHoaDonBan", cboMahoadon, "MaHoaDon", "MaHoaDon");
            cboMahoadon.SelectedIndex = -1;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMahoadon.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahoadon.Focus();
                return;
            }
            txtMahoadon.Text = cboMahoadon.Text;
            load_ThongtinHD();
            LoadDataAfterInsert(txtMahoadon.Text);
            btnHuyhoadon.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
        }

        //Xóa dữ liệu trong các điều khiển trước khi đóng Form
        private void Hoadonbanhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }
    }
}
