using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Belchfaa
{
    public partial class AdminDisplayAllMedicinesForm : Form
    {
        
        AdminClass adminClass;
        DataSet dataSet;
        public AdminDisplayAllMedicinesForm()
        {
            InitializeComponent();
        }

        private void AdminDisplayAllMedicinesForm_Load(object sender, EventArgs e)
        {
           adminClass = new AdminClass();
           dataSet = adminClass.getMedicines(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new AdminHomeForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminClass.saveData(dataSet);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
