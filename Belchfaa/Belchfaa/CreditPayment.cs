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
    public partial class CreditPayment : Form
    {
        CartClass c;
        HistoryClassClass cHistory;
        public CreditPayment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            if(textBox1.TextLength == textBox1.MaxLength
                && textBox2.TextLength == textBox2.MaxLength
                && textBox4.TextLength == textBox4.MaxLength)
            {
                msg mg = new msg();
                mg.Load("Your Process has been Confirmed successfully");
                mg.ShowDialog();

                c.clearCart(CurrentUserClass.userId);
                id = cHistory.addToHistory(CurrentUserClass.userId, (PaymentClass.subTotal * 0.05) + PaymentClass.subTotal);

                for (int i = 0; i < CurrentData.medIds.Count; i++)
                {
                    cHistory.addMedToHistory(id, CurrentData.medIds[i], CurrentData.medAmounts[i]);
                }

                this.Close();
                new UserHomeForm().Show();
            }
            else
            {
               
                this.Close();
                msg mg = new msg();
                mg.Load("Please enter your credit card info correctly");
                mg.ShowDialog();
                new CreditPayment().Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new PaymentForm().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CreditPayment_Load(object sender, EventArgs e)
        {
            cHistory = new HistoryClassClass();
            c = new CartClass();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }
    }
}
