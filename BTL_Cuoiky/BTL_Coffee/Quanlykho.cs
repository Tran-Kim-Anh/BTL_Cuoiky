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

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class Quanlykho : Form
    {
        public Quanlykho()
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



        DataTable tblQLK;
        private void Quanlykho_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            resetvalues();
            dgridQuanlykho.DataSource = null;    
            Load_DataGridView();
            btnQuaytrolai.Enabled = false;
        }

        private void resetvalues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaphieunhap.Focus();
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            int ngay, thang, nam;
            if ((txtMaphieunhap.Text == "") &&(txtTongtien.Text=="") && (txtNhanvien.Text=="")&&(txtNgay.Text== "")&&(txtThang.Text=="")&&(txtNam.Text=="")&&(txtNhacungcap.Text==""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            sql = "SELECT tblPhieuNhap.MaPhieuNhap, tblPhieuNhap.NgayNhap, tblPhieuNhap.TongTien, tblNhanVien.TenNhanVien, tblNhaCungCap.TenNhaCungCap FROM tblPhieuNhap INNER JOIN tblNhanVien ON tblPhieuNhap.MaNhanVien=tblNhanVien.MaNhanVien INNER JOIN tblNhaCungCap ON tblPhieuNhap.MaNhaCungCap=tblNhaCungCap.MaNhaCungCap WHERE 1=1";
            if (txtMaphieunhap.Text != "")
                sql = sql + " AND MaPhieuNhap Like N'%" + txtMaphieunhap.Text + "%'";
            if (txtNgay.Text != "")
            {
                if (!int.TryParse(txtNgay.Text, out ngay) || ngay < 1 || ngay > 31)
                {
                    MessageBox.Show("Bạn phải nhập ngày từ 1 đến 31!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgay.Focus();
                    return;
                }
                sql = sql + " AND Day(NgayNhap) ='" + txtNgay.Text + "'";
            }    
                
            if (txtThang.Text != "")
            {
                if (!int.TryParse(txtThang.Text, out thang) || thang < 1 || thang > 12)
                {
                    MessageBox.Show("Bạn phải nhập tháng từ 1 đến 12!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtThang.Focus();
                    return;
                }
                sql = sql + " AND Month(NgayNhap) ='" + txtThang.Text + "'";
            }    
               
            if (txtNam.Text != "")
            {
                if (!int.TryParse(txtNam.Text, out nam) || nam < 1900)
                {
                    MessageBox.Show("Bạn phải nhập năm lớn hơn hoặc bằng 1900!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNam.Focus();
                    return;
                }
                sql = sql + " AND Year(NgayNhap) ='" + txtNam.Text + "'";
            }           
            if (txtTongtien.Text != "")
                sql = sql + " AND TongTien >='" + txtTongtien.Text + "'";
            if (txtNhanvien.Text != "")
                sql = sql + " AND tblNhanVien.TenNhanVien Like N'%" + txtNhanvien.Text + "%'";
            if (txtNhacungcap.Text != "")
                sql = sql + " AND tblNhaCungCap.TenNhaCungCap Like N'%" + txtNhacungcap.Text + "%'";

            tblQLK = Class.Function.getdatatotable(sql);
            if (tblQLK.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load_DataGridView();
                resetvalues();
            }
            else
            {
                MessageBox.Show("Có " + tblQLK.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgridQuanlykho.DataSource = tblQLK;
                dgridQuanlykho.Columns[0].HeaderText = "Mã phiếu";
                dgridQuanlykho.Columns[1].HeaderText = "Ngày nhập";
                dgridQuanlykho.Columns[2].HeaderText = "Tổng tiền";
                dgridQuanlykho.Columns[3].HeaderText = "Người lập phiếu";
                dgridQuanlykho.Columns[4].HeaderText = "Nhà cung cấp";
            }
            btnQuaytrolai.Enabled = true;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT tblPhieuNhap.MaPhieuNhap, tblPhieuNhap.NgayNhap, tblPhieuNhap.TongTien, tblNhanVien.TenNhanVien, tblNhaCungCap.TenNhaCungCap FROM tblPhieuNhap INNER JOIN tblNhanVien ON tblPhieuNhap.MaNhanVien=tblNhanVien.MaNhanVien INNER JOIN tblNhaCungCap ON tblPhieuNhap.MaNhaCungCap=tblNhaCungCap.MaNhaCungCap";
            tblQLK = Class.Function.getdatatotable(sql);
            dgridQuanlykho.DataSource = tblQLK;
            dgridQuanlykho.Columns[0].HeaderText = "Mã phiếu";
            dgridQuanlykho.Columns[1].HeaderText = "Ngày nhập";
            dgridQuanlykho.Columns[2].HeaderText = "Tổng tiền";
            dgridQuanlykho.Columns[3].HeaderText = "Người lập phiếu";
            dgridQuanlykho.Columns[4].HeaderText = "Nhà cung cấp";
            dgridQuanlykho.AllowUserToAddRows = false;
            dgridQuanlykho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgridQuanlykho_DoubleClick(object sender, EventArgs e)
        {
            string map;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                map = dgridQuanlykho.CurrentRow.Cells["MaPhieuNhap"].Value.ToString();
                Phieunhap frm = new Phieunhap();
                txtMaphieunhap.Text = map;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btnQuaytrolai_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            resetvalues();
            btnQuaytrolai.Enabled = false;
        }   
    }
}

