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
    }
}
