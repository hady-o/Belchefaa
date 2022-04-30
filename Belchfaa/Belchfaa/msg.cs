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
    public partial class msg : Form
    {
        int timerleft = 300;
        public msg()
        {
            InitializeComponent();
        }

        public void Load(string text)
        {
            label2.Text = text;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerleft == 0)
            {
                this.Hide();
            }
            else
            { 
            timerleft--;
            }
               

        }
        private void button1_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }   

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
