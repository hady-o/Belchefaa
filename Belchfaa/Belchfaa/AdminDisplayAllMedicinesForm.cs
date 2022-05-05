using System;
using System.IO;
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
        MedicineQuaryClass medicine_name;

        AdminClass adminClass;
        DataSet dataSet;
        public AdminDisplayAllMedicinesForm()
        {
            InitializeComponent();
        }

        private void AdminDisplayAllMedicinesForm_Load(object sender, EventArgs e)
        {
            medicine_name = new MedicineQuaryClass();
            adminClass = new AdminClass();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            // Add all categories from a text file
            string[] all_categories = File.ReadAllLines("Categories.txt");
            foreach(string category in all_categories)
            {
                comboBox1.Items.Add(category);
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSet = adminClass.getMedicineByCategory(dataGridView1, comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataSet = adminClass.getMedicines(dataGridView1);
  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataSet temp = adminClass.getMedicineByName(textBox1.Text);
            if (temp.Tables[0].Rows.Count != 0)
            {
                dataSet = temp;
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            else
            {
                msg mg = new msg();
                mg.Load("Not Found");
                mg.ShowDialog();
            }
        }
    }
}
