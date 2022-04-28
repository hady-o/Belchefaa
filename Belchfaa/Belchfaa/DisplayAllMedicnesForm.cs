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
            OracleDataReader dr = medicine.allMedicines();
            while (dr.Read())
            {
                ListViewItem list = new ListViewItem(dr[1].ToString());

                list.SubItems.Add(dr[3].ToString() + " $");
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
                MessageBox.Show("please select one item to display");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
