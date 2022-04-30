using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;

namespace Belchfaa
{
    internal class CurrentUserClass
    {
        public static int userId;
        public static string userName;
        public static string gender;
        public static int userAge;
        public static string userPassword;

        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public void update_user(ComboBox comboBox, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update users set gender =:gender , userName  =:name,userAge =:age , userPassword  =:password where userId =:Id ";
            cmd.Parameters.Add("gender", comboBox.Text);
            cmd.Parameters.Add("name", textBox2.Text);
            cmd.Parameters.Add("age", textBox3.Text.ToString());
            cmd.Parameters.Add("password", textBox4.Text);
            cmd.Parameters.Add("Id", CurrentUserClass.userId);
            
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("data has been updated successfully");
            }

        }
    }

    
}
