using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
    public partial class SearchForm : Form
    {
        MedicineQuaryClass MedicineQuaryClass;
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        OracleCommand cmd;
        public SearchForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(MedicineQuaryClass.serchForMedicine(textBox1.Text))
            {

                CurrentData.posistion = 0;
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MedicineQuaryClass = new MedicineQuaryClass();
           //MedicineQuaryClass.insertMedicine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }
    }
}
