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
            string[] text = File.ReadAllLines("Governorates.txt");
            foreach(string governorate in text)
            {
                comboBox1.Items.Add(governorate);
            }
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
            int id = 0;
            if(comboBox1.SelectedIndex > -1 && textBox4.Text != "")
            {
                msg mg = new msg();
                mg.Load("Your Process has been Confirmed successfully");
                mg.Show();

                c.clearCart(CurrentUserClass.userId);
                id =  cHistory.addToHistory(CurrentUserClass.userId, (PaymentClass.subTotal * 0.05) + PaymentClass.subTotal);

                for (int i = 0; i < CurrentData.medIds.Count; i++)
                {
                    cHistory.addMedToHistory(id, CurrentData.medIds[i],CurrentData.medAmounts[i]);
                }
                this.Close();
                new UserHomeForm().Show();
            }
            else
            {              
                msg mg = new msg();
                mg.Load("please enter your location");
                mg.Show();
                this.Close();
                new PaymentForm().Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && textBox4.Text != "")
            {
                msg mg = new msg();
                mg.Load("Your Process has been Confirmed successfully");
                mg.Show();

                c.clearCart(CurrentUserClass.userId);
                cHistory.addToHistory(CurrentUserClass.userId, (PaymentClass.subTotal * 0.05) + PaymentClass.subTotal);
                this.Close();
                new UserHomeForm().Show();
            }
            else
            {
                msg mg = new msg();
                mg.Load("please enter your location");
                mg.Show();
                this.Close();
                new PaymentForm().Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
