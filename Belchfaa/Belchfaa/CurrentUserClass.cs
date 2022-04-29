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

        OracleDataAdapter adapter;
        OracleCommandBuilder commandBuilder;
        DataSet ds;
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public DataSet Getuser(DataGridView dataGridView)
        {
            string cmd = "select * from users where users.userid = :id ";
            adapter = new OracleDataAdapter(cmd, ordb);
            adapter.SelectCommand.Parameters.Add("id", CurrentUserClass.userId);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
            return ds;

        }
        public void saveData(DataSet ds)
        {

            commandBuilder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("data has been updated successfully");
        }

    }

    
}
