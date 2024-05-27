using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using BTL_Cuoiky.Class;
using System.Globalization;

namespace BTL_Cuoiky.BTL_Coffee
{
    public partial class BCBanhang : Form
    {
        public BCBanhang()
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

        private void mnuNCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhacungcap ncc = new Nhacungcap();
            ncc.ShowDialog();
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

        private void BCBanhang_Load(object sender, EventArgs e)
        {
            Function.Connect();
            btnTimkiem.Enabled = true;
            btnInbaocao.Enabled = true;
            btnHtspbanchay.Enabled = true;
            lblTheokhoang.Enabled = false;
            Function.FillCombo("Select MaSanPham,TenSanPham from tblSanPham", cboMasanpham, "MaSanPham", "TenSanPham");
            cboMasanpham.SelectedIndex = -1;
            
        }
        DataTable tblbcbh;
        private void load_datagridbc()
        {
            //string sql;
            //sql = "SELECT b.MaSanPham, TenSanPham, DonGiaBan, SUM(b.SoLuong) AS SoLuongBan, (SUM(b.SoLuong)*DonGiaBan) AS TienBan FROM tblHoaDonBan a INNER JOIN tblChiTietHoaDonBan b ON a.MaHoaDon = b.MaHoaDon INNER JOIN tblSanPham c ON b.MaSanPham = c.MaSanPham \r\nGROUP BY b.MaSanPham, TenSanPham, DonGiaBan";
            //tblbcbh = Function.getdatatotable(sql);
            dgridBcbanhang.DataSource = tblbcbh;
            dgridBcbanhang.Columns[0].HeaderText = "Mã sản phẩm";
            dgridBcbanhang.Columns[1].HeaderText = "Tên sản phẩm";
            dgridBcbanhang.Columns[2].HeaderText = "Đơn giá bán";
            dgridBcbanhang.Columns[3].HeaderText = "Số lượng bán";
            dgridBcbanhang.Columns[4].HeaderText = "Tiền bán";
            dgridBcbanhang.AllowUserToAddRows = false;
            dgridBcbanhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        //In báo cáo
        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblSanPham;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "KANA Coffee";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)57082495";

            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "BÁO CÁO BÁN HÀNG";

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.MaSanPham, TenSanPham, DonGiaBan, SUM(b.SoLuong) AS SoLuongBan, (SUM(b.SoLuong)*DonGiaBan) AS TienBan FROM tblHoaDonBan a INNER JOIN tblChiTietHoaDonBan b ON a.MaHoaDon = b.MaHoaDon INNER JOIN tblSanPham c ON b.MaSanPham = c.MaSanPham \r\nGROUP BY b.MaSanPham, TenSanPham, DonGiaBan";
            tblSanPham = Function.getdatatotable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A6:F6"].Font.Bold = true;
            exRange.Range["A6:F6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C6:F6"].ColumnWidth = 12;
            exRange.Range["A6:A6"].Value = "STT";
            exRange.Range["B6:B6"].Value = "Mã sản phẩm";
            exRange.Range["C6:C6"].Value = "Tên sản phẩm";
            exRange.Range["D6:D6"].Value = "Số lượng bán";
            exRange.Range["E6:E6"].Value = "Đơn giá bán";
            exRange.Range["F6:F6"].Value = "Tiền bán";
            for (hang = 0; hang <= tblSanPham.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 7
                exSheet.Cells[1][hang + 7] = hang + 1;
                for (cot = 0; cot <= tblSanPham.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 7
                    exSheet.Cells[cot + 2][hang + 7] = tblSanPham.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 10];
            exRange.Font.Bold = true;
            exRange.Value2 = tblSanPham.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 11]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblSanPham.Rows[0][2].ToString());

            exSheet.Name = "Báo cáo bán hàng";
            exApp.Visible = true;
        }

        //Tìm kiếm 
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
           
            
            sql = "SELECT b.MaSanPham, TenSanPham, DonGiaBan, SUM(b.SoLuong) AS SoLuongBan, (SUM(b.SoLuong)*DonGiaBan) AS TienBan FROM tblHoaDonBan a INNER JOIN tblChiTietHoaDonBan b ON a.MaHoaDon = b.MaHoaDon INNER JOIN tblSanPham c ON b.MaSanPham = c.MaSanPham ";

            string sqlCondition = " WHERE ";
            string sqlGroup = " \r\nGROUP BY b.MaSanPham, TenSanPham, DonGiaBan";

            var fromDate = mskTuNgay.Value;
            var toDate = mskDenNgay.Value;

            if (fromDate > toDate)
            {
                MessageBox.Show("Mời bạn nhập ngày bắt đầu nhỏ hơn ngày kết thúc!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDenNgay.Focus();
                return;
            }

            if (cboMasanpham.SelectedValue != null)
            {
                sqlCondition += $" b.MaSanPham =N'{cboMasanpham.Text}'";

                sqlCondition += $" and NgayBan >= '{fromDate}'";
                sqlCondition += $" and NgayBan <= '{toDate}'";
               
            }
            else
            {
                sqlCondition += $" NgayBan >= '{fromDate}'";
                sqlCondition += $" and NgayBan <= '{toDate}'";
            }

            sql = sql + sqlCondition + sqlGroup;

            tblbcbh = Function.getdatatotable(sql);
            if (tblbcbh.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblbcbh.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridBcbanhang.DataSource = tblbcbh;
            load_datagridbc();

        }

        //Hiển thị danh sách số lượng sản phẩm theo thứ tự từ nhiều nhất đến ít nhất
        private void btnHtspbanchay_Click(object sender, EventArgs e)
        {
            btnTimkiem.Enabled = true;
            dgridBcbanhang.DataSource = null;

            string sql;
            //Tìm kiếm Top 1
            //sql = "SELECT TOP 1 b.MaSanPham, TenSanPham, DonGiaBan, SUM(b.SoLuong) AS SoLuong, (SUM(b.SoLuong)*DonGiaBan) AS TienBan FROM tblHoaDonBan a INNER JOIN tblChiTietHoaDonBan b ON a.MaHoaDon = b.MaHoaDon INNER JOIN tblSanPham c ON b.MaSanPham = c.MaSanPham GROUP BY b.MaSanPham, TenSanPham, DonGiaBan\r\nORDER BY SUM(b.SoLuong) DESC";
            
            //TÌM KIẾM THEO THỨ TỰ SỐ LƯỢNG GIẢM DẦN
            sql = "SELECT b.MaSanPham, TenSanPham, DonGiaBan, SUM(b.SoLuong) AS SoLuong, (SUM(b.SoLuong)*DonGiaBan) AS TienBan FROM tblHoaDonBan a INNER JOIN tblChiTietHoaDonBan b ON a.MaHoaDon = b.MaHoaDon INNER JOIN tblSanPham c ON b.MaSanPham = c.MaSanPham GROUP BY b.MaSanPham, TenSanPham, DonGiaBan\r\nORDER BY SUM(b.SoLuong) DESC";

            tblbcbh = Function.getdatatotable(sql);

            if (tblbcbh.Rows.Count == 0)
            {
                MessageBox.Show("Không có data");
                return;
            }
            load_datagridbc();
 
        }
    }
}
