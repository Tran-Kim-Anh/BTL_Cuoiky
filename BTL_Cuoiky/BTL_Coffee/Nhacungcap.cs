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
    public partial class Nhacungcap : Form
    {
        public Nhacungcap()
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
        private void HienThiNCC()
        {
            dgridNCC.DataSource = Function.getdatatotable("SELECT * FROM tblNhaCungCap");
            dgridNCC.Columns[0].HeaderText = "Mã NCC";
            dgridNCC.Columns[1].HeaderText = "Tên NCC";
            dgridNCC.Columns[2].HeaderText = "Địa chỉ";
            dgridNCC.Columns[3].HeaderText = "Số điện thoại";
            dgridNCC.ColumnHeadersHeight = 30;
            if (dgridNCC.Rows.Count == 0)
            {
                txtmanhacungcap.Text = "";
                txttennhacungcap.Text = "";
                txtdiachi.Text = "";
                masktxtsodienthoai.Text = "";
            }
            else
            {
                var row = this.dgridNCC.Rows[0];
                txtmanhacungcap.Text = row.Cells[0].Value.ToString();
                txttennhacungcap.Text = row.Cells[1].Value.ToString();
                txtdiachi.Text = row.Cells[2].Value.ToString();
                masktxtsodienthoai.Text = row.Cells[3].Value.ToString();
            }
        }
        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            Function.Connect();
            HienThiNCC();
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
            txtmanhacungcap.Enabled = !iss;
            txttennhacungcap.Enabled = !iss;
            masktxtsodienthoai.Enabled = !iss;
            txtdiachi.Enabled = !iss;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmanhacungcap.Text = "";
            txttennhacungcap.Text = "";
            txtdiachi.Text = "";
            masktxtsodienthoai.Text = "";
            boolcontrols(false);
            luu = true;
            txtmanhacungcap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridNCC.Rows.Count == 0)
            {
                return;
            }
            luu = false;
            txtmanhacungcap.Enabled = false;
            boolcontrols(false);
            txtmanhacungcap.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridNCC.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa nhà cung cấp này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE tblNhaCungCap WHERE MaNhaCungCap = '" + dgridNCC.Rows[dgridNCC.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    HienThiNCC();
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
            HienThiNCC();
            boolcontrols(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtmanhacungcap.Text == "")
            {
                MessageBox.Show("Mã nhà cung cấp không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanhacungcap.Focus();
                return;
            }
            if (txttennhacungcap.Text == "")
            {
                MessageBox.Show("Tên nhà cung cấp không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttennhacungcap.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (masktxtsodienthoai.Text == "")
            {
                MessageBox.Show("SĐT không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                masktxtsodienthoai.Focus();
                return;
            }
            if (luu == true)
            {
                string sqlcheck = "SELECT * FROM tblNhaCungCap WHERE MaNhaCungCap = '" + txtmanhacungcap.Text + "'";
                string ma_ncc = Function.Getfieldvalues(sqlcheck);
                if (ma_ncc == txtmanhacungcap.Text)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmanhacungcap.Focus();
                    return;
                }
                string sql = "INSERT INTO tblNhaCungCap(MaNhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai) VALUES (N'" + txtmanhacungcap.Text + "',N'" + txttennhacungcap.Text + "',N'" + txtdiachi.Text + "'," + masktxtsodienthoai.Text + ")";
                Function.runsql(sql);
                MessageBox.Show("Thêm thành công.");
                HienThiNCC();
                boolcontrols(true);
            }
            else
            {
                try
                {
                    string sql = "UPDATE tblNhaCungCap SET TenNhaCungCap = N'" + txttennhacungcap.Text + "',DiaChi = N'" + txtdiachi.Text + "',SoDienThoai = " + masktxtsodienthoai.Text + " WHERE MaNhaCungCap = N'" + txtmanhacungcap.Text + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Sửa thành công.");
                    HienThiNCC();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmanhacungcap.Focus();
                    return;
                }
            }
        }

        private void dgridNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgridNCC.Rows[e.RowIndex];
                txtmanhacungcap.Text = row.Cells[0].Value.ToString();
                txttennhacungcap.Text = row.Cells[1].Value.ToString();
                txtdiachi.Text = row.Cells[2].Value.ToString();
                masktxtsodienthoai.Text = row.Cells[3].Value.ToString();
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phanquyen nv = new Phanquyen();
            nv.ShowDialog();
            
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien nv = new Nhanvien();
            nv.ShowDialog();
        }
    }
}
