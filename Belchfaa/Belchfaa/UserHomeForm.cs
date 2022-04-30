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
    public partial class UserHomeForm : Form
    {
        public UserHomeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new SearchForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new DisplayAllMedicnesForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new SignInForm().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                this.Close();
                new DisplayCartForm().Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            new HistoryForm().Show();
        }

        private void UserHomeForm_Load(object sender, EventArgs e)
        {
            if (CurrentUserClass.gender.ToString() == "Male")
            {
                picbox.Image = Properties.Resources.male;
            }
            else if (CurrentUserClass.gender.ToString() == "Female")
            {
                picbox.Image = Properties.Resources.female;
            }
            else
            {
                picbox.Image = Properties.Resources.not_say;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserInfo().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
