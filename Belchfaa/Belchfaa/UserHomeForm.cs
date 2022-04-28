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
    }
}
