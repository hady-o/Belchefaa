using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belchfaa
{
    internal class SharedPreference
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        OracleCommand cmd;
        OracleCommand loginCmd;
        public void AddData(int id, string gender, string name, string pass, int age)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"insert into login
                                values(:id,:gender,:name,:age,:pass)";
            cmd.Parameters.Add("id", id);
            cmd.Parameters.Add("gender", gender);
            cmd.Parameters.Add("Name", name);
            cmd.Parameters.Add("age", (age));
            cmd.Parameters.Add("pass", pass);
            int r = cmd.ExecuteNonQuery();
           
            conn.Dispose();
        }


        public void clearData()
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from login";
           
            int r = cmd.ExecuteNonQuery();

            conn.Dispose();
        }


        public bool getData()
        {


            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;


            cmd.CommandText = "select * from login";
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (!(dr[0].ToString().Equals("")))
                {
                    CurrentUserClass.userId = int.Parse(dr[0].ToString());
                    CurrentUserClass.userAge = int.Parse(dr[3].ToString());
                    CurrentUserClass.userName = dr[2].ToString();
                    CurrentUserClass.gender = dr[1].ToString();
                    CurrentUserClass.userPassword = dr[4].ToString();

                    return true;
                    //MessageBox.Show("Login successfuly");
                    // MessageBox.Show("your name is: " + dr[1]);
                }
                else
                {
                 
                    return false;
                }
                dr.Close();
            }
            else
            {
             
                dr.Close();
                return false;
            }

            conn.Dispose();

        }
    }
}
