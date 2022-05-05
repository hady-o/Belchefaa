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
    public partial class UserInfo : Form
    {
        CurrentUserClass currentUser;
        DataSet ds;
        public UserInfo()
        {
            InitializeComponent();
        }
        private void UserInfo_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = CurrentUserClass.userId.ToString();
            textBox2.Text = CurrentUserClass.userName;
            textBox3.Text = CurrentUserClass.userAge.ToString() + " years";
            comboBox1.Text = CurrentUserClass.gender;
            textBox4.Text = CurrentUserClass.userPassword;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentUser = new CurrentUserClass();
            currentUser.update_user(comboBox1, textBox2, textBox3, textBox4);
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            comboBox1.Items.Add("Not Say");
            textBox3.Text = CurrentUserClass.userAge.ToString();
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
