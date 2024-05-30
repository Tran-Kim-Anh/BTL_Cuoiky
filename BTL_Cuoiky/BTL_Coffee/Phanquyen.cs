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
    public partial class Phanquyen : Form
    {
        public Phanquyen()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhanvien nv = new Nhanvien();
            nv.ShowDialog();
        }
        private bool luu;
        private void HienThiTaiKhoan()
        {
            dgridTK.DataSource = Function.getdatatotable("SELECT * FROM tblTaiKhoan");
            dgridTK.Columns[0].HeaderText = "Tên tài khoản";
            dgridTK.Columns[1].HeaderText = "Mật khẩu";
            dgridTK.Columns[2].HeaderText = "Quyền";
            dgridTK.ColumnHeadersHeight = 30;
            if (dgridTK.Rows.Count == 0)
            {
                txttentaikhoan.Text = "";
                txtmatkhau.Text = "";
                chkadmin.Checked = false;
                chknvbh.Checked = false;
                chknvk.Checked = false;
            }
            else
            {
                var row = this.dgridTK.Rows[0];
                txttentaikhoan.Text = row.Cells[0].Value.ToString();
                txtmatkhau.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "0")
                {
                    chkadmin.Checked = true;
                    chknvbh.Checked = false;
                    chknvk.Checked = false;
                }
                if (row.Cells[2].Value.ToString() == "1")
                {
                    chkadmin.Checked = false;
                    chknvbh.Checked = true;
                    chknvk.Checked = false;
                }
                if (row.Cells[2].Value.ToString() == "2")
                {
                    chkadmin.Checked = false;
                    chknvbh.Checked = false;
                    chknvk.Checked = true;
                }
            }
        }
       
        private void Phanquyen_Load(object sender, EventArgs e)
        {
            Function.Connect();
            HienThiTaiKhoan();
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
            txttentaikhoan.Enabled = !iss;
            txtmatkhau.Enabled = !iss;
            chkadmin.Enabled = !iss;
            chknvbh.Enabled = !iss;
            chknvk.Enabled = !iss;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txttentaikhoan.Text = "";
            txtmatkhau.Text = "";
            chkadmin.Checked = false;
            chknvbh.Checked = false;
            chknvk.Checked = false;
            boolcontrols(false);
            luu = true;
            txttentaikhoan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridTK.Rows.Count == 0)
            {
                return;
            }
            luu = false;
            txttentaikhoan.Enabled = false;
            boolcontrols(false);
            txttentaikhoan.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridTK.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa tài khoản này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE tblTaiKhoan WHERE TenTaiKhoan = '" + dgridTK.Rows[dgridTK.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    HienThiTaiKhoan();
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
            HienThiTaiKhoan();
            boolcontrols(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txttentaikhoan.Text == "")
            {
                MessageBox.Show("Tên tài khoản không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttentaikhoan.Focus();
                return;
            }
            if (txtmatkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmatkhau.Focus();
                return;
            }
            if (chkadmin.Checked == false && chknvbh.Checked == false && chknvk.Checked == false)
            {
                MessageBox.Show("Chưa check chọn vào quyền", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkadmin.Focus();
                return;
            }
            int quyen = 0;
            if (chkadmin.Checked == true)
            {
                quyen = 0;
            }
            if (chknvbh.Checked == true)
            {
                quyen = 1;
            }
            if (chknvk.Checked == true)
            {
                quyen = 2;
            }
            if (luu == true)
            {
                string sqlcheck = "SELECT * FROM tblTaiKhoan WHERE TenTaiKhoan = '" + txttentaikhoan.Text + "'";
                string ma_ncc = Function.Getfieldvalues(sqlcheck);
                if (ma_ncc == txttentaikhoan.Text)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttentaikhoan.Focus();
                    return;
                }

                string sql = "INSERT INTO tblTaiKhoan(TenTaiKhoan,MatKhau,Quyen) VALUES (N'" + txttentaikhoan.Text + "',N'" + txtmatkhau.Text + "'," + quyen + ")";
                Function.runsql(sql);
                MessageBox.Show("Thêm thành công.");
                HienThiTaiKhoan();
                boolcontrols(true);
            }
            else
            {
                try
                {
                    string sql = "UPDATE tblTaiKhoan SET MatKhau = N'" + txtmatkhau.Text + "',Quyen = " + quyen + " WHERE TenTaiKhoan = N'" + txttentaikhoan.Text + "'";
                    Function.runsql(sql);
                    MessageBox.Show("Sửa thành công.");
                    HienThiTaiKhoan();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttentaikhoan.Focus();
                    return;
                }
            }
        }

        private void dgridTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgridTK.Rows[e.RowIndex];
                txttentaikhoan.Text = row.Cells[0].Value.ToString();
                txtmatkhau.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "0")
                {
                    chkadmin.Checked = true;
                    chknvbh.Checked = false;
                    chknvk.Checked = false;
                }
                if (row.Cells[2].Value.ToString() == "1")
                {
                    chkadmin.Checked = false;
                    chknvbh.Checked = true;
                    chknvk.Checked = false;
                }
                if (row.Cells[2].Value.ToString() == "2")
                {
                    chkadmin.Checked = false;
                    chknvbh.Checked = false;
                    chknvk.Checked = true;
                }
            }
        }

        private void chkadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkadmin.Checked)
            {
                chknvbh.Checked = false;
                chknvk.Checked = false;
            }
        }

        private void chknvbh_CheckedChanged(object sender, EventArgs e)
        {
            if (chknvbh.Checked)
            {
                chkadmin.Checked = false;
                chknvk.Checked = false;
            }
        }

        private void chknvk_CheckedChanged(object sender, EventArgs e)
        {
            if (chknvk.Checked)
            {
                chkadmin.Checked = false;
                chknvbh.Checked = false;
            }
        }
    }
}
