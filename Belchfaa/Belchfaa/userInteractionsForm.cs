using Oracle.DataAccess.Client;
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
    public partial class userInteractionsForm : Form
    {
        userInteractionsCrystalReport cr;
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        OracleCommand cmd;
        public userInteractionsForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new AdminHomeForm().Show();
        }

        private void userInteractionsForm_Load(object sender, EventArgs e)
        {
            cr = new userInteractionsCrystalReport();
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from users";
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr[2].ToString());

            dr.Close();
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
