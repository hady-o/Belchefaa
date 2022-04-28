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
    public partial class DisplayCartForm : Form
    {
        MedicineQuaryClass medicine;
        CartClass cart;
        public DisplayCartForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void DisplayCartForm_Load(object sender, EventArgs e)
        {
            medicine = new MedicineQuaryClass();
            cart = new CartClass();
            cart.displayCart(CurrentUserClass.userId, listView1,textBox1);
            textBox1.Text = PaymentClass.subTotal.ToString() + " $";
            if(PaymentClass.subTotal==0)
            {
                MessageBox.Show("Your cart is Empty");
                this.Close();
                new UserHomeForm().Show();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (medicine.serchForMedicine(listView1.SelectedItems[0].Text))
                {
                    CurrentData.posistion = 2;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select one item to display");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new PaymentForm().Show();
        }
    }
}
