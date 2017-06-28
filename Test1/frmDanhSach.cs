using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class frmDanhSach : Form
    {
        public frmDanhSach()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanhSach_Load(object sender, EventArgs e)
        {
            txtDanhSach.Text = Properties.Settings.Default["DanhSach"].ToString();
        }

        private void frmDanhSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default["DanhSach"] = txtDanhSach.Text;
            Properties.Settings.Default.Save();
        }
    }
}
