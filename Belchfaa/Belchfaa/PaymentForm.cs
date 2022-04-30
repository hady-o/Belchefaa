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
    public partial class PaymentForm : Form
    {
        CartClass c;
        HistoryClassClass cHistory;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            cHistory = new HistoryClassClass();
            textBox1.Text = PaymentClass.subTotal.ToString() + " L.E.";
            textBox2.Text = (PaymentClass.subTotal*0.05).ToString() + " L.E.";
            textBox3.Text = (PaymentClass.subTotal*0.05 +PaymentClass.subTotal).ToString() + " L.E.";
            c = new CartClass();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new DisplayCartForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox4.Text=="")
            {
                msg mg = new msg();
                mg.Load("please enter your location");
                mg.Show();
                this.Close();
                new PaymentForm().Show();  
            }
            else
            {
                msg mg = new msg();
                mg.Load("Your Process has been Confirmed successfully");
                mg.Show();
             
                c.clearCart(CurrentUserClass.userId);
                cHistory.addToHistory(CurrentUserClass.userId, (PaymentClass.subTotal * 0.05)+PaymentClass.subTotal);
                this.Close();
                new UserHomeForm().Show();
            }
        }
    }
}
