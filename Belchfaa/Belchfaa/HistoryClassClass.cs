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
        public void addToHistory(int userId, double total,int amount,double price)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"insert into userHistory
                                values(:userId,:total,:time,:amount,:price)";
            cmd.Parameters.Add("userId", userId);
            cmd.Parameters.Add("total", total);
            cmd.Parameters.Add("time", DateTime.Now.ToString());
            cmd.Parameters.Add("amount", amount);
            cmd.Parameters.Add("price", price);
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
                list.SubItems.Add(dr[3].ToString() );
                list.SubItems.Add(dr[4].ToString() );
               
                listView.Items.Add(list);
            }
            conn.Dispose();
        }
    }
}
