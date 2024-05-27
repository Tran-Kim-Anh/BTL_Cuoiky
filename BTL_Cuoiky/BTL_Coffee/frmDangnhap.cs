using BTL_Cuoiky.BTL_Coffee;
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
namespace BTL_Cuoiky
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
            txtMatkhau.PasswordChar = '*';
        }
        DataTable tbldangnhap;
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            Class.Function.Connect();
            int quyen;
            if (rdoAdmin.Checked)
            {
                quyen = 0;
            }
            else if (rdoNVBH.Checked)
            {
                quyen = 1;
            }
            else if (rdoNVK.Checked)
            {
                quyen = 2;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản");
                return;

            } 

            string sql;
            sql = "SELECT TenTaiKhoan, Matkhau, Quyen FROM tblTaiKhoan WHERE TenTaiKhoan='" + txtDangnhap.Text + "'AND Matkhau='" + txtMatkhau.Text + "'AND Quyen='"+quyen+"'";
            tbldangnhap=Class.Function.getdatatotable(sql);
            if (tbldangnhap.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmhome home = new frmhome();
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmDangnhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
