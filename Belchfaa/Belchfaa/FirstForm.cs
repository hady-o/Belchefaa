using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Belchfaa
{
    public partial class FirstForm : Form
    {
       
        CartClass c;
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        OracleCommand cmd;
        SharedPreference login;
        
        public FirstForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            c=new CartClass();
           
            login = new SharedPreference();
            if (login.getData())
            {
                Program.first.SetTopLevel(false);
                new UserHomeForm().Visible=true;
            }
            conn = new OracleConnection(ordb);
            conn.Open();


        }
        public static void gone(bool g)
        {
            Program.first.SetTopLevel(g);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Visible= false;
          
            new SignInForm().Show();
            Program.first.SetTopLevel(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Program.first.Visible = false;
           
            new SignUpForm().Visible=true;
            Program.first.SetTopLevel(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
            new AboutUs().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void FirstForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //this.Visible= false;

            new SignInForm().Show();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            //this.Visible = false;
            new SignUpForm().Show();   
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //this.Close();
            new AboutUs().Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
