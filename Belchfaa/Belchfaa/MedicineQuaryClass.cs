﻿using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belchfaa
{
    internal class MedicineQuaryClass
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public static OracleConnection conn;
        
        public bool serchForMedicine(string name )
        {
            bool found=false;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = conn;

            cmd4.CommandText = @"select * from medicines  
                where upper(medName) like upper(:name)";
            cmd4.Parameters.Add("name", name); 


            OracleDataReader dr = cmd4.ExecuteReader();

            if (dr.Read())
            {
                if (!(dr[0].ToString().Equals("")))
                {
                    CurrentMed.medId = int.Parse(dr[0].ToString());
                    CurrentMed.medName = dr[1].ToString();
                    CurrentMed.medPrice = int.Parse(dr[3].ToString());
                    CurrentMed.medAmount = int.Parse(dr[4].ToString());
                    CurrentMed.medCategory = dr[5].ToString();
                    found = true;
                    new MedDetailsForm().Show();
                }
                else
                {
                    MessageBox.Show("Not Found");

                }
                dr.Close();
            }
            else
            {
                MessageBox.Show("Not Found");
                dr.Close();

            }
            conn.Dispose();
            return found;   

        }


        public OracleDataReader allMedicines()
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = conn;
            cmd4.CommandText = "select * from medicines";
           
            OracleDataReader dr = cmd4.ExecuteReader();
            return dr;

            
            conn.Dispose();


        }

        public void insertMedicine()
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = conn;
            cmd4.CommandText = "insert into medicines values(:id, :name, 'medicine', :price, :amount, :cat)";
            cmd4.Parameters.Add("id", 1);
            cmd4.Parameters.Add("name", "med1");
            cmd4.Parameters.Add("price", 150);
            cmd4.Parameters.Add("amount", 15);
            cmd4.Parameters.Add("cat", "cat1");

            int r = cmd4.ExecuteNonQuery();

            if (r!=-1)
            {
                MessageBox.Show("inserted succsesfully");
            }
            conn.Dispose();


        }

    }
}
