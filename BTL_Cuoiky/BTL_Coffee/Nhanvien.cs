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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void btnphanquyen_Click(object sender, EventArgs e)
        {
            Phanquyen phanquyen = new Phanquyen();
            phanquyen.Show();
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
        private bool luu;
        private void comboboxCaLam()
        {
            DataTable dataTable = new DataTable();
            cboCaLam.Items.Clear();
            dataTable.Columns.Add("TenCa", typeof(string));
            dataTable.Rows.Add("Sáng");
            dataTable.Rows.Add("Chiều");
            dataTable.Rows.Add("Tối");
            cboCaLam.DataSource = dataTable;
            cboCaLam.DisplayMember = "TenCa";
            cboCaLam.ValueMember = "TenCa";
        }
        private void comboboxChucVu()
        {
            DataTable dataTable = new DataTable();
            dataTable = Function.getdatatotable("SELECT * FROM tblchucvu");
            cbomachucvu.DataSource = dataTable;
            cbomachucvu.DisplayMember = "TenChucVu";
            cbomachucvu.ValueMember = "MaChucVu";
        }
        private void comboboxTaiKhoan()
        {
            DataTable dataTable = new DataTable();
            dataTable = Function.getdatatotable("SELECT * FROM tblTaiKhoan");
            cboTenTaiKhoan.DataSource = dataTable;
            cboTenTaiKhoan.DisplayMember = "TenTaiKhoan";
            cboTenTaiKhoan.ValueMember = "TenTaiKhoan";
        }
        private void HienThiNhanVien()
        {
            dgridNhanvien.DataSource = Function.getdatatotable("SELECT * FROM tblNhanVien WHERE MaNhanVien LIKE N'%" + txtTimKiem.Text + "%' OR TenNhanVien LIKE N'%" + txtTimKiem.Text + "%'");
            dgridNhanvien.Columns[0].HeaderText = "Mã NV";
            dgridNhanvien.Columns[1].HeaderText = "Tên NV";
            dgridNhanvien.Columns[2].HeaderText = "Địa chỉ";
            dgridNhanvien.Columns[3].HeaderText = "Số điện thoại";
            dgridNhanvien.Columns[4].HeaderText = "Giới tính";
            dgridNhanvien.Columns[5].HeaderText = "Ngày sinh";
            dgridNhanvien.Columns[6].HeaderText = "Ngày vào làm";
            dgridNhanvien.Columns[7].HeaderText = "Ca làm";
            dgridNhanvien.Columns[8].HeaderText = "Mã chức vụ";
            dgridNhanvien.Columns[9].HeaderText = "Tên tài khoản";
            dgridNhanvien.ColumnHeadersHeight = 30;
            if (dgridNhanvien.Rows.Count == 0)
            {
                txtMaNhanVien.Text = "";
                txtTenNhanVien.Text = "";
                txtdiachi.Text = "";
                txtSoDienThoai.Text = "";
                rdoNam.Checked = false;
                rdoNu.Checked = false;
                masktxtngaysinh.Text = "";
                mastxtNgayVaoLam.Text = "";
            }
            else
            {
                var row = this.dgridNhanvien.Rows[0];
                txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                txtTenNhanVien.Text = row.Cells[1].Value.ToString();
                txtdiachi.Text = row.Cells[2].Value.ToString();
                txtSoDienThoai.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                masktxtngaysinh.Text = row.Cells[5].Value.ToString();
                mastxtNgayVaoLam.Text = row.Cells[6].Value.ToString();
                cboCaLam.Text = row.Cells[7].Value.ToString();
                cbomachucvu.SelectedValue = row.Cells[8].Value.ToString();
                cboTenTaiKhoan.SelectedValue = row.Cells[9].Value.ToString();

            }
        }
        private void Nhanvien_Load(object sender, EventArgs e)
        {
            Function.Connect();
            comboboxCaLam();
            comboboxChucVu();
            comboboxTaiKhoan();
            HienThiNhanVien();
            boolcontrols(true);
        }
        private void boolcontrols(bool iss)
        {
            btnThem.Enabled = iss;
            btnSua.Enabled = iss;
            btnXoa.Enabled = iss;
            btnLuu.Enabled = !iss;
            btnBoqua.Enabled = !iss;
            btnThoat.Enabled = iss;
            txtMaNhanVien.Enabled = !iss;
            txtTenNhanVien.Enabled = !iss;
            txtSoDienThoai.Enabled = !iss;
            txtdiachi.Enabled = !iss;
            rdoNu.Enabled = !iss;
            rdoNu.Enabled = !iss;
            masktxtngaysinh.Enabled = !iss;
            mastxtNgayVaoLam.Enabled = !iss;
            cboCaLam.Enabled = !iss;
            cbomachucvu.Enabled = !iss;
            cboTenTaiKhoan.Enabled = !iss;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtdiachi.Text = "";
            txtSoDienThoai.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            masktxtngaysinh.Text = "";
            mastxtNgayVaoLam.Text = "";
            txtdiachi.Text = "";
            txtSoDienThoai.Text = "";
            boolcontrols(false);
            luu = true;
            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridNhanvien.Rows.Count == 0)
            {
                return;
            }
            luu = false;
            txtMaNhanVien.Enabled = false;
            boolcontrols(false);
            txtMaNhanVien.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridNhanvien.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa nhà nhân viên này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE tblnhanvien WHERE MaNhanVien = '" + dgridNhanvien.Rows[dgridNhanvien.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    HienThiNhanVien();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Dữ liệu đã phát sinh khóa ngoại, không xóa được", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
            boolcontrols(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("SĐT không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return;
            }
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Chưa chọn giới tính", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return;
            }
            if (masktxtngaysinh.Text == "")
            {
                MessageBox.Show("Ngày sinh không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                masktxtngaysinh.Focus();
                return;
            }
            if (mastxtNgayVaoLam.Text == "")
            {
                MessageBox.Show("Ngày vào làm không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                mastxtNgayVaoLam.Focus();
                return;
            }
            if (cbomachucvu.Text == "")
            {
                MessageBox.Show("Chức vụ không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomachucvu.Focus();
                return;
            }
            if (cboTenTaiKhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTenTaiKhoan.Focus();
                return;
            }
            string gioitinh = "";
            if (rdoNam.Checked)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            if (luu == true)
            {
                string sqlcheck = "SELECT * FROM tblnhanvien WHERE MaNhanVien = '" + txtMaNhanVien.Text + "'";
                string ma_ncc = Function.Getfieldvalues(sqlcheck);
                if (ma_ncc == txtMaNhanVien.Text)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNhanVien.Focus();
                    return;
                }
                string sql = "INSERT INTO tblnhanvien(MaNhanVien,TenNhanVien,DiaChi,SoDienThoai,GioiTinh,NgaySinh,NgayVaoLam,CaLam,MaChucVu,TenTaiKhoan) VALUES (N'" + txtMaNhanVien.Text + "',N'" + txtTenNhanVien.Text + "',N'" + txtdiachi.Text + "'," + txtSoDienThoai.Text + ",N'" + gioitinh + "','" + Function.Convertdatetime(masktxtngaysinh.Text) + "','" + Function.Convertdatetime(mastxtNgayVaoLam.Text) + "',N'" + cboCaLam.Text + "','" + cbomachucvu.SelectedValue.ToString() + "','" + cboTenTaiKhoan.SelectedValue.ToString() + "')";
                Function.runsql(sql);
                MessageBox.Show("Thêm thành công.");
                HienThiNhanVien();
                boolcontrols(true);
            }
            else
            {
                try
                {
                    string sql = "UPDATE tblnhanvien SET TenNhanVien = N'" + txtTenNhanVien.Text + "',DiaChi = N'" + txtdiachi.Text + "',SoDienThoai = " + txtSoDienThoai.Text + ",GioiTinh = N'" + gioitinh + "',NgaySinh ='" + Function.Convertdatetime(masktxtngaysinh.Text) + "' , NgayVaoLam = '" + Function.Convertdatetime(mastxtNgayVaoLam.Text) + "' ,CaLam = N'" + cboCaLam.Text + "',MaChucVu ='" + cbomachucvu.SelectedValue.ToString() + "' ,TenTaiKhoan = '" + cboTenTaiKhoan.SelectedValue.ToString() + "' WHERE MaNhanVien = N'" + txtMaNhanVien.Text + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Sửa thành công.");
                    HienThiNhanVien();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNhanVien.Focus();
                    return;
                }
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

        private void dgridNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgridNhanvien.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                txtTenNhanVien.Text = row.Cells[1].Value.ToString();
                txtdiachi.Text = row.Cells[2].Value.ToString();
                txtSoDienThoai.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                masktxtngaysinh.Text = row.Cells[5].Value.ToString();
                mastxtNgayVaoLam.Text = row.Cells[6].Value.ToString();
                cboCaLam.Text = row.Cells[7].Value.ToString();
                cbomachucvu.SelectedValue = row.Cells[8].Value.ToString();
                cboTenTaiKhoan.SelectedValue = row.Cells[9].Value.ToString();
            }
        }

        private void mnuTaikhoan_Click(object sender, EventArgs e)
        {
            Phanquyen frm = new Phanquyen();
            frm.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien nv = new Nhanvien();
            nv.ShowDialog();
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNam.Checked)
            {
                rdoNu.Checked = false;
            }
            else
            {
                rdoNu.Checked = true;
            }
        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNu.Checked)
            {
                rdoNam.Checked = false;
            }
            else
            {
                rdoNam.Checked = true;
            }
        }

    }
}
