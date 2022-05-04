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
    public partial class AdminHomeForm : Form
    {
        public AdminHomeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new AdminDisplayAllMedicinesForm().Show();
        }

        private void AdminHomeForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new DisplayAllUsersForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new SignInForm().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new userInteractionsForm().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            new medicinesExpireForm().Show();
        }
    }
}
