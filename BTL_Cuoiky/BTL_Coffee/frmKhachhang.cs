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
    }
}
