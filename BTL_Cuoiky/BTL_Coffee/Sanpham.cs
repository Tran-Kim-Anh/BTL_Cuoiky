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
    public partial class Sanpham : Form
    {
        public Sanpham()
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

        private void Sanpham_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Class.Function.FillCombo("SELECT MaLoai, TenLoai FROM tblLoaiSanPham", cbomaloai, "MaLoai", "TenLoai");
            cbomaloai.SelectedIndex = -1;
            Resetvalues();
        }
        DataTable tblsp;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblSanPham";
            tblsp = Class.Function.getdatatotable(sql);
            dgridSanpham.DataSource = tblsp;
            dgridSanpham.Columns[0].HeaderText = "Mã sản phẩm";
            dgridSanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgridSanpham.Columns[2].HeaderText = "Giá nhập";
            dgridSanpham.Columns[3].HeaderText = "Giá bán";
            dgridSanpham.Columns[4].HeaderText = "Số lượng";
            dgridSanpham.Columns[5].HeaderText = "Mã loại";
            dgridSanpham.AllowUserToAddRows = false;
            dgridSanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinSP()
        {
            string str;
            str = "SELECT MaSanPham FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            txtmasanpham.Text = Function.Getfieldvalues(str);
            str = "SELECT TenSanPham FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            txttensanpham.Text = Function.Getfieldvalues(str);
            str = "SELECT GiaNhap FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            txtgianhap.Text = Function.Getfieldvalues(str);
            str = "SELECT GiaBan FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            txtGiaban.Text = Function.Getfieldvalues(str);
            str = "SELECT SoLuong FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            txtsoluong.Text = Function.Getfieldvalues(str);
            str = "SELECT Anh FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            txtanh.Text = Function.Getfieldvalues(str);
            pbanh.Image = Image.FromFile(txtanh.Text);
            str = "SELECT MaLoai FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'";
            cbomaloai.SelectedValue = Function.Getfieldvalues(str);
        }
        private void Resetvalues()
        {
            txtmasanpham.Text = "";
            txttensanpham.Text = "";
            txtgianhap.Text = "";
            txtGiaban.Text = "0";
            txtgianhap.Text = "0";
            txtGiaban.Enabled = false;
            txtgianhap.Enabled = false;
            txtsoluong.Text = "";
            txtanh.Text = "";
            pbanh.Image = null;
            cbomaloai.Text = "";
        }

        private void dgridSanpham_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasanpham.Focus();
                return;
            }
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmasanpham.Text = dgridSanpham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txttensanpham.Text = dgridSanpham.CurrentRow.Cells["TenSanPham"].Value.ToString();
            txtgianhap.Text = dgridSanpham.CurrentRow.Cells["GiaNhap"].Value.ToString();
            txtGiaban.Text = dgridSanpham.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtsoluong.Text = dgridSanpham.CurrentRow.Cells["SoLuong"].Value.ToString();
            ma = dgridSanpham.CurrentRow.Cells["MaLoai"].Value.ToString();
            cbomaloai.Text = Function.Getfieldvalues("SELECT TenLoai FROM tblLoaiSanPham WHERE MaLoai = N'" + ma + "'");
            txtanh.Text = Function.Getfieldvalues("SELECT Anh FROM tblSanPham WHERE MaSanPham = N'" + txtmasanpham.Text + "'");
            pbanh.Image = Image.FromFile(txtanh.Text);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            Resetvalues();
            txtmasanpham.Enabled = true;
            txtmasanpham.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmasanpham.Focus();
                return;
            }
            if (txttensanpham.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttensanpham.Focus();
                return;
            }
            if (txtgianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá nhập sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgianhap.Focus();
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }
            if (txtanh.Text == "")
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtanh.Focus();
                return;
            }
            if (cbomaloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaloai.Focus();
                return;
            }
            sql = "SELECT MaSanPham FROM tblSanPham WHERE MaSanPham=N'" + txtmasanpham.Text + "'";
            if (Function.checkkey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmasanpham.Focus();
                txtmasanpham.Text = "";
                return;
            }
            sql = "INSERT INTO tblSanPham(MaSanPham,TenSanPham,GiaNhap, GiaBan, SoLuong, MaLoai, Anh) VALUES(N'" + txtmasanpham.Text + "',N'" + txttensanpham.Text + "',N'" + txtgianhap.Text + "',N'" + txtGiaban.Text + "',N'" + txtsoluong.Text + "',N'" + cbomaloai.SelectedValue.ToString() + "',N'" + txtanh.Text + "')";
            Function.runsql(sql);
            Load_DataGridView();
            Resetvalues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmasanpham.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "C:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                pbanh.Image = Image.FromFile(dlgOpen.FileName);
                txtanh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttensanpham.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttensanpham.Focus();
                return;
            }
            if (txtgianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá nhập của sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgianhap.Focus();
                return;
            }
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá bán của sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaban.Focus();
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }
            if (cbomaloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaloai.Focus();
                return;
            }
            if (txtanh.Text == "")
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtanh.Focus();
                return;
            }
            sql = "UPDATE tblSanPham SET  TenSanPham=N'" + txttensanpham.Text + "',GiaNhap=N'" + txtgianhap.Text + "',GiaBan='" + txtGiaban.Text + "',SoLuong=N'" + txtsoluong.Text + "',Anh=N'" + txtanh.Text + "',MaLoai=N'" + cbomaloai.SelectedValue.ToString() + "' WHERE MaSanPham=N'" + txtmasanpham.Text + "'";
            Function.runsql(sql);
            Load_DataGridView();
            Resetvalues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSanPham WHERE MaSanPham=N'" + txtmasanpham.Text + "'";
                Function.Runsqldel(sql);
                Load_DataGridView();
                Resetvalues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            Resetvalues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmasanpham.Enabled = false;
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaSanPham, TenSanPham, GiaNhap, GiaBan, SoLuong, Anh, MaLoai FROM tblSanPham";
            tblsp = Function.getdatatotable(sql);
            dgridSanpham.DataSource = tblsp;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một sản phẩm để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttimkiem.Focus();
                return;
            }
            txtmasanpham.Text = txttimkiem.Text;
            Load_ThongtinSP();
            Load_DataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            double gn, gb;
            if (txtgianhap.Text == "")
                gn = 0;
            else
                gn = Convert.ToDouble(txtgianhap.Text);
            gb = gn * 1.10;
            txtGiaban.Text = gb.ToString();
        }
    }
}
