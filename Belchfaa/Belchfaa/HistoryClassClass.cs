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

        public List<List<ListViewItem>> selectHistory(int userId)
        {
            List <List<ListViewItem>> l =new List <List<ListViewItem>>();
            CurrentData.historyTotal.Clear();
            CurrentData.historyTime.Clear();
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select uh.historyid,uh.total ,uh.timep
                                from userhistory uh
                                where uh.userid = :userId";
            cmd.Parameters.Add("userId", userId);
            OracleDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                List<ListViewItem> l2 = new List<ListViewItem>();
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = @"select m.medname , m.medprice , h.amount
                                    from userhistory uh, history h , medicines m
                                    where uh.historyid =:hisId and uh.historyid = h.historyid and m.medid = h.medid";
                cmd2.Parameters.Add("hisId", dr[0]);
                OracleDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {

                    ListViewItem list2 = new ListViewItem(dr2[0].ToString());

                    list2.SubItems.Add(dr2[1].ToString());
                    list2.SubItems.Add(dr2[2].ToString());
                    l2.Add(list2);
                        
                }
                l.Add(l2);
                CurrentData.historyTotal.Add(double.Parse(dr[1].ToString())); 
                CurrentData.historyTime.Add(dr[2].ToString()); 
                dr2.Close();
            }
            //CurrentData.historyTotal = double.Parse(dr[1].ToString());
            //CurrentData.historyTime = dr[2].ToString();
            dr.Close();
            conn.Dispose();
            return l;
        }
    }
}
