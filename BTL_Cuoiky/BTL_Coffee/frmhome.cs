using Guna.UI2.WinForms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class frmhome : Form
    {
        public frmhome()
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

        private void mnuquanlykho_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quanlykho kho = new Quanlykho();
            kho.ShowDialog();
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
    }
}
