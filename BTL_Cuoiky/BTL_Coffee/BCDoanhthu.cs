using BTL_Cuoiky.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class BCDoanhthu : Form
    {
        public BCDoanhthu()
        {
            InitializeComponent();
        }

        private void dgridBcdoanhthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void BCDoanhthu_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
            Function.FillCombo("SELECT MaHoaDon FROM tblHoaDonBan", cbomahoadon, "MaHoaDon", "MaHoaDon");
            Function.FillCombo("SELECT MaNhanVien FROM tblNhanVien", cbomanhanvien, "MaNhanVien", "MaNhanVien");
            cbomahoadon.SelectedIndex = -1;
            cbomanhanvien.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            cbomahoadon.SelectedValue = "";
            cbomanhanvien.SelectedValue = "";
            msktungay.Text = "";
            mskDenngay.Text = "";
            txtTongtien.Text = "0";
            return;
        }
        DataTable tbldt;

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql, sql1;
            if ((cbomahoadon.Text == "") && (cbomanhanvien.Text == "") && (msktungay.Text == "") && (mskDenngay.Text == ""))
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoaDonBan WHERE 1=1";
            if (cbomahoadon.SelectedValue != null)
            {
                sql = sql + " and MaHoaDon =N'" + cbomahoadon.Text + "'";
            }
            if (cbomanhanvien.SelectedValue != null)
            {
                sql = sql + " and MaNhanVien =N'" + cbomanhanvien.Text + "'";
            }
            if (msktungay.Text != "  /  /")
            {
                if (mskDenngay.Text == "  /  /")
                {
                    MessageBox.Show("Hãy nhập đến ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDenngay.Focus();
                    return;
                }
            }
            if (mskDenngay.Text != "  /  /")
            {
                if (msktungay.Text == "  /  /")
                {

                    MessageBox.Show("Hãy nhập từ ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Focus();
                    return;
                }
            }
            if (msktungay.Text != "  /  /" && mskDenngay.Text != "  /  /")
            {
                if (!Function.Isdate(mskDenngay.Text))
                {
                    MessageBox.Show("Hãy nhập lại đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDenngay.Focus();
                    mskDenngay.Text = "";
                    return;
                }
                if (!Function.Isdate(msktungay.Text))
                {
                    MessageBox.Show("Hãy nhập lại từ ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Focus();
                    msktungay.Text = "";
                    return;
                }
                if (DateTime.ParseExact(msktungay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(mskDenngay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDenngay.Text = "";
                    msktungay.Text = "";
                    return;
                }
                sql = sql + " and TuNgay =N'" + msktungay.Text + "'";
                sql = sql + " and DenNgay =N'" + mskDenngay.Text + "'";
            }
            sql1 = " where 1=1";
            if (cbomahoadon.SelectedValue != null)
            {
                sql1 = sql1 + " and MaHoaDon =N'" + cbomahoadon.Text + "'";
            }
            if (cbomanhanvien.SelectedValue != null)
            {
                sql1 = sql1 + " and MaNhanVien =N'" + cbomanhanvien.Text + "'";
            }
            if (msktungay.Text != "  /  /")
            {
                if (mskDenngay.Text == "  /  /")
                {
                    MessageBox.Show("Hãy nhập lại đến ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDenngay.Focus();
                    return;
                }
            }
            if (mskDenngay.Text != "  /  /")
            {
                if (msktungay.Text == "  /  /")
                {

                    MessageBox.Show("Hãy nhập từ ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Focus();
                    return;
                }
            }
            if (msktungay.Text != "  /  /" && mskDenngay.Text != "  /  /")
            {
                if (!Function.Isdate(mskDenngay.Text))
                {
                    MessageBox.Show("Hãy nhập lại đến ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDenngay.Focus();
                    mskDenngay.Text = "";
                    return;
                }
                if (!Function.Isdate(msktungay.Text))
                {
                    MessageBox.Show("Hãy nhập lại từ ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktungay.Focus();
                    msktungay.Text = "";
                    return;
                }
                if (DateTime.ParseExact(msktungay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(mskDenngay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDenngay.Text = "";
                    msktungay.Text = "";
                    return;
                }
                sql1 = sql1 + " and TuNgay =N'" + msktungay.Text + "'";
                sql1 = sql1 + " and DenNgay =N'" + mskDenngay.Text + "'";
            }
            tbldt = Function.getdatatotable(sql);
            if (tbldt.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tbldt.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridBcdoanhthu.DataSource = tbldt;
            ResetValues();
            txtTongtien.Text = Function.Getfieldvalues("SELECT sum(TongTien) FROM  tblHoaDonBan  " + sql1 + "      ");
            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHoaDon,TuNgay,TongTien,MaNhanVien,MaKhachHang,MaBan,DenNgay FROM tblHoaDonBan";
            tbldt = Function.getdatatotable(sql);
            dgridBcdoanhthu.DataSource = tbldt;
            txtTongtien.Text = Function.Getfieldvalues("SELECT sum(TongTien) FROM  tblHoaDonBan  " + sql + "      ");
            lblbangchu.Text = "Bằng chữ: " + Function.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["E10:F10:G10"].Font.Size = 14;
            exRange.Range["E10:F10:G10"].Font.Name = "Times new roman";
            exRange.Range["E10:F10:G10"].Font.Bold = true;
            exRange.Range["E10:F10:G10"].Font.ColorIndex = 3;
            exRange.Range["E10:F10:G10"].MergeCells = true;
            exRange.Range["E10:F10:G10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E10:F10:G10"].Value = "Báo cáo doanh thu";

            exRange.Range["H15:H15"].Value = "Tổng tiền:";
            exRange.Range["H16:H16"].Value = txtTongtien.Text;

            exRange.Range["A12:F12"].Font.Bold = true;
            exRange.Range["A12:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Mã hoá đơn";
            exRange.Range["C12:C12"].Value = "Từ ngày";
            exRange.Range["D12:D12"].Value = "Tổng tiền";
            exRange.Range["E12:E12"].Value = "Mã nhân viên";
            exRange.Range["F12:F12"].Value = "Mã khách hàng";
            exRange.Range["G12:G12"].Value = "Mã bàn";
            exRange.Range["H12:H12"].Value = "Đến ngày";
            for (int row = 0; row < tbldt.Rows.Count; row++)
            {
                exSheet.Cells[1][row + 13] = row + 1;
                for (int col = 0; col < tbldt.Columns.Count; col++)
                {
                    if (tbldt.Columns[col].ColumnName == "TuNgay")
                    {
                        DateTime TuNgay = Convert.ToDateTime(tbldt.Rows[row]["TuNgay"]);
                        exSheet.Cells[col + 2][row + 13] = TuNgay.ToShortDateString();
                    }
                    else
                    {
                        exSheet.Cells[col + 2][row + 13] = tbldt.Rows[row][col].ToString();
                    }
                }
                for (int col = 0; col < tbldt.Columns.Count; col++)
                {
                    if (tbldt.Columns[col].ColumnName == "DenNgay")
                    {
                        DateTime DenNgay = Convert.ToDateTime(tbldt.Rows[row]["DenNgay"]);
                        exSheet.Cells[col + 2][row + 13] = DenNgay.ToShortDateString();
                    }
                    else
                    {
                        exSheet.Cells[col + 2][row + 13] = tbldt.Rows[row][col].ToString();
                    }
                }
            }
            for (hang = 0; hang < tbldt.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot < tbldt.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 13] = tbldt.Rows[hang][cot].ToString();
                }
            }
            exApp.Visible = true;
        }
    }
}
