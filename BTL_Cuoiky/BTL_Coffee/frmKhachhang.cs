using BTL_Cuoiky.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class frmKhachhang : Form
    {
        public frmKhachhang()
        {
            InitializeComponent();
        }
        private void mnuhoadonbanhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hoadonbanhang Hoadon = new Hoadonbanhang();
            Hoadon.ShowDialog();
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
            Quanlykho qlk = new Quanlykho();
            qlk.ShowDialog();
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
            Nhacungcap ncc = new Nhacungcap();
            ncc.ShowDialog();
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
            BCDoanhthu bcdt = new BCDoanhthu();
            bcdt.ShowDialog();
        }

        private void mnuBctonkho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Baocaotonkho bctk = new Baocaotonkho();
            bctk.ShowDialog();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmhome home = new frmhome();
            home.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmhome home = new frmhome();
            home.ShowDialog();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangnhap dn = new frmDangnhap();
            dn.ShowDialog();
        }

        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            Function.Connect();
            txtMakh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            load_datagrid();
            resetvalue();
        }
        DataTable tblkh;
        //DataTable tbllsgd;
        private void load_datagrid()
        {
            string sql;
            sql = "select MaKhachHang, TenKhachHang, SoDienThoai, DiemTichLuy from tblKhachHang";
            tblkh = Function.getdatatotable(sql);
            dgriddanhsachkh.DataSource = tblkh;
            dgriddanhsachkh.Columns[0].HeaderText = "Mã khách hàng";
            dgriddanhsachkh.Columns[1].HeaderText = "Tên khách hàng";
            dgriddanhsachkh.Columns[2].HeaderText = "Số điện thoại";
            dgriddanhsachkh.Columns[3].HeaderText = "Điểm tích lũy";
            dgriddanhsachkh.AllowUserToAddRows = false;
            dgriddanhsachkh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgriddanhsachkh_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakh.Focus();
                return;
            }
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMakh.Text = dgriddanhsachkh.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            txtTenkh.Text = dgriddanhsachkh.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            txtSodienthoaikh.Text = dgriddanhsachkh.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtDiemtichluy.Text = dgriddanhsachkh.CurrentRow.Cells["DiemTichLuy"].Value.ToString();
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            btnTimkiem.Enabled = true;
        }
        private void resetvalue()
        {
            txtMakh.Text = "";
            txtTenkh.Text = "";
            txtSodienthoaikh.Text = "";
            txtDiemtichluy.Text = "0";
            txtDiemtichluy.Enabled = false;
        }

        //Thêm mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnTimkiem.Enabled = false;
            resetvalue();
            txtMakh.Enabled = true;
            txtMakh.Focus();
        }

        //Bỏ qua
        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnBoqua.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTimkiem.Enabled = true;
            txtMakh.Enabled = false;
        }

        //Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMakh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã  khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakh.Focus();
                return;
            }
            if (txtTenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkh.Focus();
                return;
            }
            if (txtSodienthoaikh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSodienthoaikh.Focus();
                return;
            }

            sql = "SELECT MaKhachHang FROM tblKhachHang WHERE MaKhachHang=N'" + txtMakh.Text.Trim() + "'";
            if (Function.checkkey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakh.Focus();
                txtMakh.Text = "";
                return;
            }
            sql = "INSERT INTO tblKhachHang(MaKhachHang,TenKhachHang,SoDienThoai,DiemTichLuy) VALUES(N'" + txtMakh.Text.Trim() + "',N'" + txtTenkh.Text.Trim() + "'," + txtSodienthoaikh.Text.Trim() + "," + txtDiemtichluy.Text.Trim() + ")";
            Function.runsql(sql);
            load_datagrid();
            resetvalue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMakh.Enabled = false;
        }

        //Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkh.Focus();
                return;
            }

            if (txtSodienthoaikh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSodienthoaikh.Focus();
                return;
            }

            sql = "UPDATE tblKhachHang SET TenKhachHang=N'" + txtTenkh.Text.Trim().ToString() + "',SoDienThoai='" + txtSodienthoaikh.Text.Trim() + "',DiemTichLuy='" + txtDiemtichluy.Text.Trim() + "' WHERE MaKhachHang=N'" + txtMakh.Text + "'";
            Function.runsql(sql);
            load_datagrid();
            resetvalue();
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
        }

        //Kiểm tra điều kiện nhập của số điện thoại và điểm tích lũy
        private void txtSodienthoaikh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtDiemtichluy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;

            if (string.IsNullOrEmpty(txtTimkiem.Text))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string textSearch = txtTimkiem.Text.Trim().ToLower();

            sql = $"Select *  from tblKhachHang where LOWER(MaKhachHang) LIKE '%{textSearch}%' OR LOWER(TenKhachHang) LIKE '%{textSearch}%'";

            tblkh = Function.getdatatotable(sql);
            if (tblkh.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có" + tblkh.Rows.Count + "bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgriddanhsachkh.DataSource = tblkh;
            resetvalue();
        }

        private void dgriddanhsachkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgriddanhsachkh.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                string maKH = dgriddanhsachkh.CurrentCell.Value.ToString();

                string sqlGiaoDich = $"SELECT a.MaHoaDon, b.NgayBan, a.MaSanPham, c.TenSanPham, a.SoLuong, a.ThanhTien\r\nFROM  tblChiTietHoaDonBan a \r\nINNER JOIN tblHoaDonBan b ON a.MaHoaDon = b.MaHoaDon\r\nINNER JOIN tblSanPham c ON c.MaSanPham = a.MaSanPham\r\nWHERE b.MaKhachHang LIKE '%{maKH}%'";

                dgridLichsugiaodich.DataSource = Function.getdatatotable(sqlGiaoDich);
            }
        }
    }
}
