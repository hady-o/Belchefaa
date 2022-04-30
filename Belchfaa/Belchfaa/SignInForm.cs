using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;
namespace Belchfaa
{
    public partial class SignInForm : Form
    {
        LoginAndRegister login;

        public SignInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "admin22" && textBox1.Text == "2022")
                {
                    this.Close();
                    new AdminHomeForm().Show();
                }

                else if (login.signIn(textBox1, textBox2))
                {
                    this.Close();
                    new UserHomeForm().Show();
                }
            }
            catch (Exception ex)
            {
                msg mg = new msg();
                mg.Load(ex.Message);
                mg.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            login = new LoginAndRegister();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
