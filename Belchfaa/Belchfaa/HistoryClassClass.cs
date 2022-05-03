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
        public int addToHistory(int userId, double total)
        {
            int id = 0;
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select max (historyID) from userHistory";
            OracleDataReader dr = cmd2.ExecuteReader();
            cmd.CommandText = @"insert into userHistory
                                values(:Id, :userId, :total,:time)";
            if (dr.Read())
            {
                if (!(dr[0].ToString().Equals("")))
                {
                    id = int.Parse(dr[0].ToString()) + 1;
                    cmd.Parameters.Add("id", int.Parse(dr[0].ToString()) + 1);
                }
                else
                {
                    id = 1;
                    cmd.Parameters.Add("id", 1);
                }
                dr.Close();
               
            }

           
            cmd.Parameters.Add("userId", userId);
            cmd.Parameters.Add("total", total);
            cmd.Parameters.Add("time", DateTime.Now.ToString());
          
            int r = cmd.ExecuteNonQuery();
           
            conn.Dispose();
            return id;
        }

        public void addMedToHistory(int hisId, int medId,int amount)
        {
            int id = 0;
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;           
            cmd.CommandText = @"insert into History
                                values(:hisId, :medId, :amount)";
            cmd.Parameters.Add("hisId", hisId);
            cmd.Parameters.Add("medId", medId);
            cmd.Parameters.Add("am", amount);
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
