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
    internal class AdminClass
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder commandBuilder;
        DataSet ds;
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        public DataSet getMedicines(DataGridView dataGridView)
        {
            string cmd = "select * from medicines";
            adapter = new OracleDataAdapter(cmd,ordb);
            ds =new DataSet();
            adapter.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
            return ds;
            
        }
        public DataSet getMedicineByCategory(DataGridView data, string selected_item)
        {
            string cmd = "select * FROM medicines where medcategory = :category";
            adapter = new OracleDataAdapter(cmd, ordb);
            ds = new DataSet();
            adapter.SelectCommand.Parameters.Add("category", selected_item);
            adapter.Fill(ds);
            data.DataSource = ds.Tables[0];
            return ds;
        }
        public void saveData(DataSet ds)
        {            
            commandBuilder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            msg mg = new msg();
            mg.Load("Data has been updated successfully");
            mg.Show();
        }

        public DataSet getusers(DataGridView dataGridView)
        {
            string cmd = "select * from users";
            adapter = new OracleDataAdapter(cmd, ordb);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
            return ds;

        }

        
    }
    
}
