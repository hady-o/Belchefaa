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
    public partial class SignUpForm : Form
    {
        LoginAndRegister register;
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        OracleCommand cmd;
        
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            comboBox1.Items.Add("Not Say");
            register = new LoginAndRegister();
            textBox3.UseSystemPasswordChar = true;
            textBox4.UseSystemPasswordChar = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""||comboBox1.Text == "")
                {
                    Text = "please fill all data";
                    msg mg = new msg();
                    mg.Load(Text);
                    mg.ShowDialog();
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    Text = "wrong password confirmation";
                    msg mg = new msg();
                    mg.Load(Text);
                    mg.ShowDialog();
                }
                else
                {
                    register.signUp(textBox1, textBox2, textBox3, textBox4,comboBox1);
                }
            }
            catch (Exception ex)
            {
                msg mg = new msg();
                mg.Load(ex.Message);
                mg.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
