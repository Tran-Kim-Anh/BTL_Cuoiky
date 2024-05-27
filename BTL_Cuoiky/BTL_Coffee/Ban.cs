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
    public partial class Ban : Form
    {
        public Ban()
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

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien nv = new Nhanvien();
            nv.ShowDialog();
        }

        private void mnuKhuyenmai_Click(object sender, EventArgs e)
        {
            this.Hide();
            Khuyenmai KM = new Khuyenmai();
            KM.ShowDialog();
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

       

        private void Ban_Load(object sender, EventArgs e)
        {
            txtMaban.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        DataTable tblban;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaBan, TenBan, KhuVuc, TrangThai FROM tblBan";
            tblban = Class.Function.getdatatotable(sql);
            dgridquanlyban.DataSource = tblban;
            dgridquanlyban.Columns[0].HeaderText = "Mã bàn";
            dgridquanlyban.Columns[1].HeaderText = "Tên bàn";
            dgridquanlyban.Columns[1].HeaderText = "Khu vực";
            dgridquanlyban.Columns[1].HeaderText = "Trạng thái";
            dgridquanlyban.AllowUserToAddRows = false;
            dgridquanlyban.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaban.Enabled = true;
            txtMaban.Focus();
        }
        private void ResetValues()
        {
            txtMaban.Text = "";
            txtTenban.Text = "";
            txtKhuvuc.Text = "";
            txtTrangthai.Text = "";
        }

        private void dgridquanlyban_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaban.Focus();
                return;
            }
            if (tblban.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaban.Text = dgridquanlyban.CurrentRow.Cells["Maban"].Value.ToString();
            txtTenban.Text = dgridquanlyban.CurrentRow.Cells["Tenban"].Value.ToString();
            txtKhuvuc.Text = dgridquanlyban.CurrentRow.Cells["Khuvuc"].Value.ToString();
            txtTrangthai.Text = dgridquanlyban.CurrentRow.Cells["Trangthai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaban.Text == " ")
            {
                MessageBox.Show("Bạn phải nhập mã bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaban.Focus();
                return;
            }
            if (txtTenban.Text == " ")
            {
                MessageBox.Show("Bạn phải nhập tên bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenban.Focus();
                return;
            }
            if (txtKhuvuc.Text == " ")
            {
                MessageBox.Show("Bạn phải nhập khu vực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKhuvuc.Focus();
                return;
            }
            if (txtTrangthai.Text == " ")
            {
                MessageBox.Show("Bạn phải nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTrangthai.Focus();
                return;
            }
            sql = " select MaBan from tblBan where MaBan= N' " + txtMaban.Text + "'";
            if (Class.Function.checkkey(sql))
            {
                MessageBox.Show("Mã bàn này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaban.Focus();
                txtMaban.Text = " ";
                return;
            }
            sql = "INSERT INTO tblBan(MaBan,TenBan,KhuVuc,TrangThai) VALUES (N'" + txtMaban.Text + "',N'" + txtTenban.Text + "',N'" + txtKhuvuc.Text + "','" + txtTrangthai.Text + "')";
            Class.Function.runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaban.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblban.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaban.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenban.Focus();
                return;
            }
            if (txtKhuvuc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập khu vực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenban.Focus();
                return;
            }
            if (txtTrangthai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenban.Focus();
                return;
            }
            sql = "UPDATE tblBan SET  TenBan=N'" + txtTenban.Text + "',KhuVuc=N'" + txtKhuvuc.Text + "',TrangThai='" + txtTrangthai.Text + "' WHERE MaBan=N'" + txtMaban.Text + "'";
            Class.Function.runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblban.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaban.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblBan WHERE MaBan=N'" + txtMaban.Text + "'";
                Function.Runsqldel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaban.Enabled = false;
        }
    }
}
