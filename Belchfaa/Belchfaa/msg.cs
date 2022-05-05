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
        public msg()
        {
            InitializeComponent();
        }

        public void Load(string text)
        {
            label2.Text = text;
        
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }   

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
