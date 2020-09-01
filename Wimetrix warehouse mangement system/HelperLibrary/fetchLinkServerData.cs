using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HelperLibrary
{
    public static class fetchLinkServerData
    {
        public static string server { get; set; }
        public static string userID { get; set; }
        public static string password { get; set; }
        public static string databasename { get; set; }

        static string myconnection = $"Data Source= {server}; User ID={userID}; Password={password}; Initial Catalog= {databasename};Max Pool Size=6000 ";

        static public SqlConnection con;
        static public SqlDataReader mdr;


        public static string assign()
        {
            return myconnection = $"Data Source= {server}; User ID={userID}; Password={password}; Initial Catalog= {databasename};Max Pool Size=6000 ";
            
        }


        #region Connection Test

        public static bool OpenConnection()

        {
            string myconnection = $"Data Source= {server}; User ID={userID}; Password={password}; Initial Catalog= {databasename};Max Pool Size=3000 ";
            

            con = new SqlConnection(myconnection);

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    return true;
                }
                return true;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(" Check Server Ip Or Contact administrator",
                "Error in Connecting to Server ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator" + ex.Message);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }


        }
        public static bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
        #endregion

        public static DataTable read_table(string tablename, string columns)
        {
            DataTable dataset = new DataTable();
            con = new SqlConnection(myconnection);
            try
            {
                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM OPENQUERY (ORAWIMTX,'SELECT " + columns + " FROM "  +tablename + " ');", con);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dataset);
                    CloseConnection();

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Fetching Data " + ex.Message);
            }
            return dataset;

        }
        public static List<String> GetOrders()
        {
            List<String> dataset = new List<string>();
            con = new SqlConnection(myconnection);
            try
            {
                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM OPENQUERY (ORAWIMTX,'SELECT Distinct orderID FROM  V_cutreport ');", con);

                    mdr = cmd.ExecuteReader();
                    while (mdr.Read()) { dataset.Add(mdr["orderID"].ToString()); }
                    CloseConnection();

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Fetching Data " + ex.Message);
            }
            return dataset;

        }
        //public static string get_all_workers(string workerID)
        //{
        //    con.ConnectionString = myconnection;
        //    string type = "";
        //    string unitID = "";
        //    string job_status = "";
        //    string reply = "";


        //    string tablename = fetch_tablename("workers");

        //    if (Sql.OpenConnection() == true)
        //    {
        //        try
        //        {
        //            SqlDataReader md = Sql.get_data_table_where(tablename, "*", "workerID", workerID);
        //            while (md.Read())
        //            {
        //                type = md["type"].ToString();
        //                unitID = md["unit_code"].ToString();
        //                job_status = md["status"].ToString();
        //                reply = type + "-" + unitID + "-" + job_status;

        //            }
        //            Sql.CloseConnection();
        //            return reply;
        //        }
        //        catch (Exception ex)
        //        {
        //            alerts.messageBox("Error", "Error Code: Fetch Worker Details");
        //            Sql.errorLog("Fetch Worker Details", "Error in Fetch Worker Details" + "\n" + ex.Message);
        //            return reply = null;
        //        }
        //    }
        //    else
        //    {
        //        return reply = null;

        //    }
        //}

        public static DataTable read_table_where(string tablename, string columns,string where_column,string value)
        {
            DataTable dataset = new DataTable();
            con = new SqlConnection(myconnection);
            try
            {
                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand("select * FROM OPENQUERY (ORAWIMTX,'SELECT" + columns + "FROM" + tablename + " where " + where_column + " = '"+ value  +"'');", con);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dataset);
                    CloseConnection();

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Fetching Data " + ex.Message);
            }
            return dataset;

        }

        
        
    }

  

}

