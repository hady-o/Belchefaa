using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Belchfaa
{
    public partial class DisplayAllMedicnesForm : Form
    {
        MedicineQuaryClass medicine;
        CartClass cart;
        public DisplayAllMedicnesForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            medicine = new MedicineQuaryClass();
            cart = new CartClass();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            OracleDataReader category_dr = medicine.getAllCategories();
            while (category_dr.Read())
            {
                comboBox1.Items.Add(category_dr[0]);
            }

            OracleDataReader dr = medicine.allMedicines();
            while (dr.Read())
            {
                ListViewItem list = new ListViewItem(dr[1].ToString());

                list.SubItems.Add(dr[3].ToString() + " L.E.");
                list.SubItems.Add(dr[4].ToString() + " items");
                list.SubItems.Add(dr[5].ToString());

                listView1.Items.Add(list);
               
            }
            dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (medicine.serchForMedicine(listView1.SelectedItems[0].Text))
                {
                    CurrentData.posistion = 1;
                    this.Close();
                }
            }
           catch(Exception ex)
            {
                msg mg = new msg();
                mg.Load("please select one item to display");
                mg.ShowDialog();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleDataReader dr = medicine.allMedicines();
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem list = new ListViewItem(dr[1].ToString());

                list.SubItems.Add(dr[3].ToString() + " L.E.");
                list.SubItems.Add(dr[4].ToString() + " items");
                list.SubItems.Add(dr[5].ToString());

                listView1.Items.Add(list);

            }
            if (listView1.Items.Count == 0)
            {
                msg mg = new msg();
                mg.Load("There is no medicine now");
                mg.ShowDialog();
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleDataReader dr = medicine.medicineByCategory(comboBox1.Text);
            listView1.Items.Clear();
            while (dr.Read())
            {
                ListViewItem list = new ListViewItem(dr[1].ToString());

                list.SubItems.Add(dr[3].ToString() + " L.E.");
                list.SubItems.Add(dr[4].ToString() + " items");
                list.SubItems.Add(dr[5].ToString());

                listView1.Items.Add(list);

            }
            if (listView1.Items.Count == 0)
            {
                msg mg = new msg();
                mg.Load("This medicine doesn't exist");
                mg.ShowDialog();
            }
                dr.Close();
            
        }
    }
}
