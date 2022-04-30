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
            currentUser = new CurrentUserClass();
            ds = currentUser.Getuser(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentUser.saveData(ds);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
