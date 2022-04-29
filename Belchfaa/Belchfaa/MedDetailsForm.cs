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
    public partial class MedDetailsForm : Form
    {
        CartClass  cart;
        MedicineQuaryClass MedicineQuaryClass;
        public MedDetailsForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MedDetails_Load(object sender, EventArgs e)
        {
            textBox1.Text = CurrentMed.medName;
            textBox2.Text = CurrentMed.medPrice.ToString()+" L.E.";
            textBox3.Text = CurrentMed.medAmount.ToString()+" items";
            textBox4.Text = CurrentMed.medCategory;
            MedicineQuaryClass = new MedicineQuaryClass();
            cart = new CartClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "" || textBox5.Text == null)
            {
                MessageBox.Show("please enter your quantity");
            }
            else if (int.Parse(textBox5.Text) > CurrentMed.medAmount || int.Parse(textBox5.Text) < 1)
            {
                MessageBox.Show("Invalid quantity");
            }
            else
            {

                try
                {
                    cart.addToCart(CurrentUserClass.userId, CurrentMed.medId, CurrentMed.medAmount, int.Parse(textBox5.Text.ToString()));
                        
                    }
                catch (Exception ex)
                {
                    cart.increaseCartAmount(CurrentUserClass.userId, CurrentMed.medId, CurrentMed.medAmount, int.Parse(textBox5.Text.ToString()));
                       
                    }


            }
        }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid quantity");
                }
            this.Close();
            MedicineQuaryClass.serchForMedicine(CurrentMed.medName);
        }

private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "")
                {
                    cart.removefromCart(CurrentUserClass.userId, CurrentMed.medId, CurrentMed.medAmount);
                    
                }
                else if (int.Parse(textBox5.Text) < 1)
                {
                    MessageBox.Show("Invalid quantity");
                }
                else
                {
                   
                   cart.decreaseCartAmount(CurrentUserClass.userId, CurrentMed.medId, CurrentMed.medAmount, int.Parse(textBox5.Text.ToString()));
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
            MedicineQuaryClass.serchForMedicine(CurrentMed.medName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            switch(CurrentData.posistion)
            {
                case 0:
                    new SearchForm().Show();
                    break;
                case 1:
                    new DisplayAllMedicnesForm().Show();
                    break ;
                case 2:
                    new DisplayCartForm().Show();
                    break;
                default:
                    new SearchForm().Show();
                    break;
            }
            
        }
    }
}
