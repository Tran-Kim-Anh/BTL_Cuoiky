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
    public partial class Khuyenmai : Form
    {
        public Khuyenmai()
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

       

        private void Khuyenmai_Load(object sender, EventArgs e)
        {
            txtmakm.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        DataTable tblkm;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaKhuyenMai, TenKhuyenMai, MoTa, NgayBatDau, NgayKetThuc, GiaTri FROM tblKhuyenMai";
            tblkm = Class.Function.getdatatotable(sql);
            dgridkhuyenmai.DataSource = tblkm;
            dgridkhuyenmai.Columns[0].HeaderText = "Mã khuyến mãi";
            dgridkhuyenmai.Columns[1].HeaderText = "Tên khuyến mãi";
            dgridkhuyenmai.Columns[2].HeaderText = "Mô tả";
            dgridkhuyenmai.Columns[3].HeaderText = "Ngày bắt đầu";
            dgridkhuyenmai.Columns[4].HeaderText = "Ngày kết thúc";
            dgridkhuyenmai.Columns[5].HeaderText = "Giá trị";
            dgridkhuyenmai.AllowUserToAddRows = false;
            dgridkhuyenmai.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinKM()
        {
            string str;
            str = "SELECT MaKhuyenMai FROM tblKhuyenMai WHERE MaKhuyenMai = N'" + txtmakm.Text + "'";
            txtmakm.Text = Function.Getfieldvalues(str);
            str = "SELECT TenKhuyenMai FROM tblKhuyenMai WHERE MaKhuyenMai = N'" + txtmakm.Text + "'";
            txttenkm.Text = Function.Getfieldvalues(str);
            str = "SELECT MoTa FROM tblKhuyenMai WHERE MaKhuyenMai = N'" + txtmakm.Text + "'";
            txtmota.Text = Function.Getfieldvalues(str);
            str = "SELECT NgayBatDau FROM tblKhuyenMai WHERE MaKhuyenMai = N'" + txtmakm.Text + "'";
            mskngaybatdau.Text = Function.Convertdatetime(Function.Getfieldvalues(str));
            str = "SELECT NgayKetThuc FROM tblKhuyenMai WHERE MaKhuyenMai = N'" + txtmakm.Text + "'";
            mskngayketthuc.Text = Function.Convertdatetime(Function.Getfieldvalues(str));
            str = "SELECT GiaTri FROM tblKhuyenMai WHERE MaKhuyenMai = N'" + txtmakm.Text + "'";
            txtGiatri.Text = Function.Getfieldvalues(str);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmakm.Enabled = true;
            txtmakm.Focus();
        }
        private void ResetValues()
        {
            txtmakm.Text = "";
            txttenkm.Text = "";
            txtmota.Text = "";
            mskngaybatdau.Text = "";
            mskngayketthuc.Text = "";
            txtGiatri.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakm.Focus();
                return;
            }
            if (txttenkm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenkm.Focus();
                return;
            }
            if (txtmota.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmota.Focus();
                return;
            }
            if (mskngaybatdau.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaybatdau.Focus();
                return;
            }
            if (mskngayketthuc.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngayketthuc.Focus();
                return;
            }
            if (txtGiatri.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiatri.Focus();
                return;
            }
            sql = "SELECT MaKhuyenMai FROM tblKhuyenMai WHERE MaKhuyenMai=N'" + txtmakm.Text + "'";
            if (Function.checkkey(sql))
            {
                MessageBox.Show("Mã khuyến mãi này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakm.Focus();
                txtmakm.Text = "";
                return;
            }
            sql = "INSERT INTO tblKhuyenMai(MaKhuyenMai,TenKhuyenMai,MoTa,NgayBatDau,NgayKetThuc,GiaTri) VALUES (N'" + txtmakm.Text + "',N'" + txttenkm.Text + "',N'" + txtmota.Text + "',N'" + mskngaybatdau.Text + "',N'" + mskngayketthuc.Text + "','" + txtGiatri.Text + "')";
            Function.runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmakm.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkm.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenkm.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenkm.Focus();
                return;
            }
            if (txtmota.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmota.Focus();
                return;
            }
            if (mskngaybatdau.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaybatdau.Focus();
                return;
            }
            if (mskngayketthuc.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngayketthuc.Focus();
                return;
            }
            if (txtGiatri.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiatri.Focus();
                return;
            }
            sql = "UPDATE tblKhuyenMai SET  TenKhuyenMai=N'" + txttenkm.Text + "',MoTa=N'" + txtmota.Text + "',NgayBatDau='" + mskngaybatdau.Text.ToString() + "',NgayKetThuc=N'" + mskngayketthuc.Text.ToString() + "',GiaTri='" + txtGiatri.Text + "' WHERE MaKhuyenMai=N'" + txtmakm.Text + "'";
            Function.runsql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkm.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblKhuyenMai WHERE MaKhuyenMai=N'" + txtmakm.Text + "'";
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
            txtmakm.Enabled = false;
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaKhuyenMai, TenKhuyenMai, MoTa, NgayBatDau, NgayKetThuc, GiaTri FROM tblKhuyenMai";
            tblkm = Function.getdatatotable(sql);
            dgridkhuyenmai.DataSource = tblkm;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttimkiem.Focus();
                return;
            }
            txtmakm.Text = txttimkiem.Text;
            Load_ThongtinKM();
            Load_DataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
        }
    }
}
