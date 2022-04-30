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
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }


        private void AboutUs_Load(object sender, EventArgs e)
        {
            label1.Text = "BELSHIFA";
            label4.Text = "application has been developed by a team of 7 developers to provide users with\r";
            label5.Text="a flexible medicine ordering service. It allows users to search for the required medicine and \r" +
                "they can also provide the system with any info regarding the required medicine to avoid \r" +
                "mistakes. After ordering, the system searches for the nearest pharmacy that has the\r" +
                "required medicine to connect to it and speed up the delivery process.\r";
            label2.Text="Team members:\r" +
                "             Hadi Atef Sayed\r" +
                "             Aya Mohamed AbdelAziz\r"+
                "             Hadi Ahmed AbdelSalam\r"+
                "             Hadi Ehab Ragaa\r"+
                "             Haytham Mahmoud ElSayed\r"+
                "             Hani Mohamed Sayed\r"+
                "             Waseem Abdo Fathy\r";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
