using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HelperLibrary
{
    public static class fetchData
    {
        static string config_tablename = "dbo.tableConfig";
        public static string server { get; set; }
        public static string userID { get; set; }
        public static string password { get; set; }
        public static string databasename { get; set; }

        static string myconnection = $"Data Source= {server}; User ID={userID}; Password={password}; Initial Catalog= {databasename};Max Pool Size=3000 ";

        static public SqlConnection con;
        static public SqlDataReader mdr;
        public static List<string> fetch_all_sectionID()
        {
            con = new SqlConnection(myconnection);
            List<string> sectionID_list = new List<string>();

            string tablename = fetch_tablename("sections");

            if (tablename.Contains("error"))
            {
                return sectionID_list = null;
            }
            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.get_data_table(tablename, "sectionID");
                    while (md.Read())
                    {
                        sectionID_list.Add(md["sectionID"].ToString());

                    }
                    Sql.CloseConnection();
                    return sectionID_list;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD02");
                    Sql.errorLog("FD02", "Error in Fetching SectionID -- " + ex.Message);
                    return sectionID_list = null;
                }
            }
            else
            {
                return sectionID_list = null;
            } 
        }
        public static List<string> fetch_userID()
        {
            con = new SqlConnection(myconnection);
            List<string> userID = new List<string>();
            string tablename = fetch_tablename("users");

            if (tablename.Contains("error"))
            {
                return userID = null;
            }


            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.get_data_table(tablename, "userID");
                    while (md.Read())
                    {
                        userID.Add(md["userID"].ToString());

                    }
                    Sql.CloseConnection();
                    return userID;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD03");
                    Sql.errorLog("FD03", "Error in Fetching userID -- " + ex.Message);
                    return userID = null;
                }
            }
            else
            {
                return userID = null;
            }

        }
        public static string get_machineDetails(string machineID)
        {
            con.ConnectionString = myconnection;
            string lineID = "";
            string unitID = "";
            string  reply=""; 
            string tablename = fetch_tablename("machine"); 

            if (Sql.OpenConnection() == true)
            {
                try
                { 
                    SqlDataReader md = Sql.get_data_table_where(tablename, "*", "machineID", machineID);
                    while (md.Read())
                    {
                        lineID = md["lineID"].ToString();
                        unitID = md["unitID"].ToString();
                        reply = lineID + "-" + unitID;
                    }
                    Sql.CloseConnection();
                    return  reply;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: Fetch Machines Details");
                    Sql.errorLog("Fetch Machine Details", "Error in Fetch Machine Details" + "\n" + ex.Message);
                    return reply = null;
                }
            }
            else
            {
                return reply = null;

            }
        }
        public static string get_workersDetails(string workerID)
        {
            con.ConnectionString = myconnection;
            string type = "";
            string unitID = "";
            string job_status = "";
           string reply = "";
           
             
            string tablename = fetch_tablename("workers"); 

            if (Sql.OpenConnection() == true)
            {
                try
                { 
                    SqlDataReader md = Sql.get_data_table_where(tablename, "*", "workerID", workerID);
                    while (md.Read())
                    {
                        type = md["type"].ToString();
                        unitID = md["unit_code"].ToString();
                        job_status = md["status"].ToString();
                        reply = type + "-" + unitID + "-"+ job_status;
                       
                    }
                    Sql.CloseConnection();
                    return  reply;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: Fetch Worker Details");
                    Sql.errorLog("Fetch Worker Details", "Error in Fetch Worker Details" + "\n" + ex.Message);
                    return reply = null;
                }
            }
            else
            {
                return reply = null;

            }
        }
        public static List<string> fetch_all_lineID()
        {
            con = new SqlConnection(myconnection);
            List<string> lineID = new List<string>();
            string tablename = fetch_tablename("lines");

            if (tablename.Contains("error"))
            {
                return lineID = null;
            }


            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.get_data_table(tablename, "lineID");
                    while (md.Read())
                    {

                        lineID.Add(md["lineID"].ToString());

                    }
                    Sql.CloseConnection();
                    return lineID;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD04");
                    Sql.errorLog("FD04", "Error in Fetching lineID -- " + ex.Message);
                    return lineID = null;

                }
            }
            else
            {
                return lineID = null;
            }

        }

        public static List<string> fetch_all_machineID()
        {
            con = new SqlConnection(myconnection);
            List<string> machineID = new List<string>();

            string tablename = fetch_tablename("machines");

            if (tablename.Contains("error"))
            {
                return machineID = null;
            }


            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.get_data_table(tablename, "machineID");
                    while (md.Read())
                    {

                        machineID.Add(md["machineID"].ToString());

                    }
                    Sql.CloseConnection();
                    return machineID;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD05");
                    Sql.errorLog("FD05", "Error in Fetching MachineID -- " + ex.Message);
                    return machineID = null;

                }
            }
            else
            {
                return machineID = null;
            }



        }

        public static List<string> fetch_all_workers()
        {
            con = new SqlConnection(myconnection);
            List<string> workerID = new List<string>();
            string tablename = fetch_tablename("workers");

            if (tablename.Contains("error"))
            {
                return workerID = null;
            } 
            if (Sql.OpenConnection() == true)
            {
                try
                { 
                    SqlDataReader md = Sql.get_data_table(tablename, "workerID");
                    while (md.Read())
                    {
                        workerID.Add(md["workerID"].ToString());
                    }
                    Sql.CloseConnection();

                    return workerID;
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD06");
                    Sql.errorLog("FD06", "Error in Fetching WorkerID -- " + ex.Message);
                    return workerID = null;
                }
            }
            else
            {
                return workerID = null;
            } 
        }

        public static List<string> fetch_all_personlogin()
        {
            con = new SqlConnection(myconnection);
            List<string> personlogin = new List<string>();
            string tablename = fetch_tablename("personlogin");

            if (tablename.Contains("error"))
            {
                return personlogin = null;
            } 
            if (Sql.OpenConnection() == true)
            {
                try
                { 
                    SqlDataReader md = Sql.get_data_table(tablename, "personName");
                    while (md.Read())
                    {

                        personlogin.Add(md["personName"].ToString());

                    }
                    Sql.CloseConnection(); 
                    return personlogin; 

                }
                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD08");
                    Sql.errorLog("FD08", "Error in Fetching personName in Personlogin -- " + ex.Message);
                    return personlogin = null;
                }
            }
            else
            {
                return personlogin = null;
            } 
        }

        public static List<string> fetch_orderID()
        {
            con = new SqlConnection(myconnection);
            List<string> orderID = new List<string>();
            string tablename = "[wim_spts].[cutreport]";
            if (tablename.Contains("error"))
            {
                return orderID = null;
            }
             
            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.customRead("Select Distinct OrderID FROM " + tablename );
                    while (md.Read())
                    {
                        orderID.Add(md["OrderID"].ToString());

                    }
                    Sql.CloseConnection();
                    return orderID;
                }

                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD07");
                    Sql.errorLog("FD07", "Error in Fetching OrderID -- " + ex.Message);
                    return orderID = null; 
                }
            }
            else
            {
                return orderID = null;
            } 
        }

        public static List<string> fetch_StyleID()
        {
            con = new SqlConnection(myconnection);
            List<string> StyleID = new List<string>();
            string tablename = "[wim_spts].[stylebulletin]";
            if (tablename.Contains("error"))
            {
                return StyleID = null;
            }

            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.customRead("Select distinct styleCode FROM " + tablename);
                    while (md.Read())
                    {
                        StyleID.Add(md["styleCode"].ToString());

                    }
                    Sql.CloseConnection();
                    return StyleID;
                }

                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD07");
                    Sql.errorLog("FD07", "Error in Fetching StyleID -- " + ex.Message);
                    return StyleID = null;
                }
            }
            else
            {
                return StyleID = null;
            }
        }
        public static string get_personlogin_ID(string personName)
        {
            con = new SqlConnection(myconnection);
            string peronlogin = null ;
            string tablename = fetch_tablename("personlogin");
            if (tablename.Contains("error"))
            {
                return peronlogin = null;
            }

            if (Sql.OpenConnection() == true)
            {
                try
                {
                    SqlDataReader md = Sql.get_data_table_where(tablename, "PersonID, PersonName", "PersonName",personName);
                    while (md.Read())
                    {
                        peronlogin = md["PersonID"].ToString();

                    }
                    Sql.CloseConnection();
                    return peronlogin;
                }

                catch (Exception ex)
                {
                    alerts.messageBox("Error", "Error Code: FD09");
                    Sql.errorLog("FD09", "Error in Fetching Person login ID -- " + ex.Message);
                    return peronlogin = null;
                }
            }
            else
            {
                return peronlogin = null;
            }
        }


        public static string fetch_tablename(string tabletitle)
        {
            con = new SqlConnection(myconnection);
            if (Sql.OpenConnection() == true)
            {
                try
                {
                    string tablename = string.Empty;
                    SqlDataReader md = Sql.get_data_table_where(config_tablename, "*", "tableName", tabletitle);
                    while (md.Read())
                    {
                        tablename = md["databaseName"].ToString();

                    }
                    Sql.CloseConnection();
                    if (string.IsNullOrEmpty(tablename))
                    {
                        alerts.messageBox("Error", "Error Code: FD01");
                        return "error";
                    }
                    else
                    {
                        return tablename;
                    }
                }
                catch (Exception ex)
                {
                    alerts.messageBox("Database Error", "Error Code: FD03");
                    Sql.errorLog("FD03", "Error in Fetching TableTitle" + "\n" + ex.Message);
                    return "error";
                }
            }
            else
            {
                return "error ConnectionLost";

            }

        }

    }
}
