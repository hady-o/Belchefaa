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
    public partial class DisplayAllUsersForm : Form
    {
        AdminClass adminClass;
        DataSet ds;
        public DisplayAllUsersForm()
        {
            InitializeComponent();
        }

        private void DisplayAllUsersForm_Load(object sender, EventArgs e)
        {
            adminClass = new AdminClass();
            ds = adminClass.getusers(dataGridView2);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminClass.saveData(ds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new AdminHomeForm().Show();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
