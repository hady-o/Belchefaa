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
    public partial class HistoryForm : Form
    {
        HistoryClassClass history;
        int j = 0;
        List<List<ListViewItem>> l = new List<List<ListViewItem>>();

        public HistoryForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserHomeForm().Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            
            history = new HistoryClassClass();
            l = history.selectHistory(CurrentUserClass.userId);
            if (l.Count > 0)
            {
                for (int i = 0; i < l[j].Count; i++)
                {
                    listView1.Items.Add(l[j][i]);
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            if (l.Count > 0 && j+1 >= 0 && j+1 < l.Count)
            {
                j++;

                listView1.Items.Clear();
                for (int i = 0; i < l[j].Count; i++)
                {
                    listView1.Items.Add(l[j][i]);
                }
            }
            else
            {
                MessageBox.Show("invalid");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            
            if (l.Count > 0 && j-1 >= 0 && j-1 < l.Count)
            {
                j--;
                listView1.Items.Clear();
                for (int i = 0; i < l[j].Count; i++)
                {
                    listView1.Items.Add(l[j][i]);
                }
            }
            else
            {
                MessageBox.Show("invalid");
            }
        }
    }
}
