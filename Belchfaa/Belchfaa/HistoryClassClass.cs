using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belchfaa
{
    internal class HistoryClassClass
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        OracleCommand cmd;
        public void addToHistory(int userId, double amount)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"insert into userHistory
                                values(:userId,:amount,:time)";
            cmd.Parameters.Add("userId", userId);
            cmd.Parameters.Add("amount", amount);
            cmd.Parameters.Add("time", DateTime.Now.ToString());
            int r = cmd.ExecuteNonQuery();
           
            conn.Dispose();
        }

        public void selectHistory(int userId, ListView listView)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from userHistory where userId=:userId";
            cmd.Parameters.Add("userId", userId);
            OracleDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                ListViewItem list = new ListViewItem(dr[1].ToString()+" L.E.");

                list.SubItems.Add(dr[2].ToString() );
               
                listView.Items.Add(list);
            }
            conn.Dispose();
        }
    }
}
