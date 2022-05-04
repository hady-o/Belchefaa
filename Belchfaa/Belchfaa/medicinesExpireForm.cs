using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belchfaa
{
    public partial class medicinesExpireForm : Form
    {
        medicinesExpireCrystalReport cr;
        public medicinesExpireForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new AdminHomeForm().Show();
        }

        private void medicinesExpireForm_Load(object sender, EventArgs e)
        {
            cr = new medicinesExpireCrystalReport();
            //crystalReportViewer1.ReportSource = cr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.Refresh();
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
