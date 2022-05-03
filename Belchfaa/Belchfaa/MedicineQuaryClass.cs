using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

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
            cmd4.CommandText = "GetMed2";
            cmd4.CommandType = CommandType.StoredProcedure;
         
            cmd4.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd4.Parameters.Add("name", name);
            cmd4.Parameters.Add("price", OracleDbType.Double, ParameterDirection.Output);
            cmd4.Parameters.Add("amount", OracleDbType.Int32, ParameterDirection.Output);
            cmd4.Parameters.Add("categoryId",  OracleDbType.Int32, ParameterDirection.Output);
         
                try
                {
                cmd4.ExecuteNonQuery();
                CurrentMed.medId = int.Parse(cmd4.Parameters[0].Value.ToString());
                CurrentMed.medName = cmd4.Parameters[1].Value.ToString();

                CurrentMed.medPrice = int.Parse(cmd4.Parameters[2].Value.ToString());
                CurrentMed.medAmount = int.Parse(cmd4.Parameters[3].Value.ToString());
             

                switch (int.Parse(cmd4.Parameters[4].Value.ToString()))
                {
                    case 1:
                        CurrentMed.medCategory = "cat1";
                        break;
                    case 2:
                        CurrentMed.medCategory = "cat2";
                        break;
                    case 3:
                        CurrentMed.medCategory = "cat3";
                        break;
                    case 4:
                        CurrentMed.medCategory = "cat4";
                        break;

                      
                }
                found = true;
                new MedDetailsForm().Show();



            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            //else
            //{
            //    msg mg = new msg();
            //    mg.Load("Not Found");
            //    mg.Show();

            //}


            //OracleDataReader dr=cmd4.ExecuteReader();

            //if (dr.Read())
            //{
            //    if (!(dr[0].ToString().Equals("")))
            //    {
            //        CurrentMed.medId = int.Parse(dr[0].ToString());
            //        CurrentMed.medName = dr[1].ToString();
            //        CurrentMed.medPrice = int.Parse(dr[3].ToString());
            //        CurrentMed.medAmount = int.Parse(dr[4].ToString());
            //        CurrentMed.medCategory = dr[5].ToString();
            //        found = true;
            //        new MedDetailsForm().Show();
            //    }
            //    else
            //    {
            //        msg mg = new msg();
            //        mg.Load("Not Found");
            //        mg.Show();

            //    }
            //    dr.Close();
            //}
            //else
            //{
            //    msg mg = new msg();
            //    mg.Load("Not Found");
            //    mg.Show();
            //    dr.Close();

            //}
            conn.Dispose();
            return found;   

        }


        public OracleDataReader allMedicines()
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = conn;
            cmd4.CommandText = "GetAllMeds";
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add("id", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd4.ExecuteReader();
            return dr;

            
            conn.Dispose(); 
            //dhd

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
                msg mg = new msg();
                mg.Load("Inserted succsesfully");
                mg.Show();
            }
            conn.Dispose();


        }

    }
}
