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
    public static  class Sql
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
        public static  bool   OpenConnection()
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

        /// <summary>
        /// Inserts a new row with data in the specified table
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="column_names"></param>
        /// <param name="column_data"></param>
        public  static string insert_multiplyRows_table( string tablename, string[] column_names, string[] column_data)
        { 
            con = new SqlConnection(myconnection);
            try
            {  
                if (OpenConnection() ==true)
                {

                    StringBuilder col = new StringBuilder();
                    StringBuilder data = new StringBuilder();
                    col.Append("(");
                    data.Append("('");

                    for (int b = 0; b < column_names.Length; b++)
                    {
                        col.Append(column_names[b]);
                        data.Append(column_data[b]);
                        if (b < column_names.Length - 1)
                        {
                            col.Append(",");
                            data.Append("','");
                        }
                    }
                    col.Append(")");
                    data.Append("')");

                    SqlCommand cmd = new SqlCommand("insert into " +tablename + col + "values " + data, con);

                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    CloseConnection();
                    return "saved";

                } 
                else
                {
                    return "conneciton_error";
                }
               
            }
            catch (SqlException ex)
            {
                if(ex.Message.Contains("duplicate"))
                {
                    return "duplicate";
                }
                else
                {
                    alerts.messageBox("SQL Error", "Error Code: Inserting Multiply Rows"  );
                    Sql.errorLog("SQ11", "Error in Inserting Multiply Rows -- " + ex.Message);
                    return ex.Message;
                }
            }
             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name of column(s) to be read. Use "*" to read all columns</param>
        /// <returns>DataReader</returns>
        public static SqlDataReader get_data_table(string tablename, string columns)
        {
            con = new SqlConnection(myconnection);

            try
            {
                
                if (OpenConnection() == true)
                { 
                    SqlCommand cmd = new SqlCommand("SELECT " + columns + " FROM " + tablename, con);
                    mdr = cmd.ExecuteReader();

                    return mdr;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return mdr;

        } /// <summary>
          /// 
          /// </summary>
          /// <param name="database">Name of database</param>
          /// <param name="tablename">Name of Table</param>
          /// <param name="columns">Name of column(s) to be read. Use "*" to read all columns</param>
          /// <returns>DataReader</returns>
          /// 

        public static SqlDataReader customRead(string custom)
        {
            con = new SqlConnection(myconnection);

            try
            {

                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand(custom, con);
                     mdr = cmd.ExecuteReader();
                    return mdr;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return mdr;

        }
        public static SqlDataReader customQery( string custom)
        {
            con = new SqlConnection(myconnection);

            try
            {
                
                if (OpenConnection() == true)
                { 
                    SqlCommand cmd = new SqlCommand(custom, con);
                   // mdr = cmd.ExecuteReader();
                    String reply = cmd.ExecuteNonQuery().ToString();
                    if (reply != "-1") 
                    {
                        MessageBox.Show("Something went Wrong");
                    }
                    return mdr;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return mdr;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name of column(s) to be read. Use "*" to read all columns</param>
        /// <param name="col_whr">Column containing the specific value</param>
        /// <param name="value">value</param>
        /// <returns>DataReader</returns>
        public static SqlDataReader get_data_table_where( string tablename, string columns, string col_whr, string value)
        {
            con = new SqlConnection(myconnection);

            try
            {
                if (OpenConnection() == true)
                {

                    SqlCommand cmd = new SqlCommand("SELECT " + columns + " FROM " + tablename + " WHERE " + col_whr + "='" + value + "';", con);
                    mdr = cmd.ExecuteReader();

                    return mdr;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mdr;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name of column(s) to be read. Use "*" to read all columns</param>
        /// <param name="col_username">Column containing the specific value</param>
        /// <param name="user_value">value</param>
        /// <param name="col_pass">value</param>
        /// <param name="pass_val">value</param>
        /// <returns>DataReader</returns>
        public static bool loginCheck(string tablename, string columns, string col_username, string user_value, string col_pass, string pass_val)
        {
            con = new SqlConnection(myconnection);

            try
            {
                if (OpenConnection() == true)
                {

                    SqlCommand cmd = new SqlCommand("SELECT " + columns + " FROM " + tablename + " WHERE " + col_username + "='" + user_value + "' AND "+col_pass+" = '"+pass_val+"' ;", con);
                    mdr = cmd.ExecuteReader();

                    if(mdr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

           

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name of column(s) to be read. Use "*" to read all columns</param>
        /// <param name="col_username">Column containing the specific value</param>
        /// <param name="user_value">value</param>
        /// <param name="col_pass">value</param>
        /// <param name="pass_val">value</param>
        /// <returns>DataReader</returns>
        public static SqlDataReader get_data_where_twoColumns(string tablename, string columns, string col_username, string user_value, string col_pass, string pass_val)
        {
            con = new SqlConnection(myconnection);

            try
            {
                if (OpenConnection() == true)
                {

                    SqlCommand cmd = new SqlCommand("SELECT " + columns + " FROM " + tablename + " WHERE " + col_username + "='" + user_value + "' AND " + col_pass + " = '" + pass_val + "' ;", con);
                    mdr = cmd.ExecuteReader();
 
                    return mdr;
                }
                
            }
            catch (SqlException ex)
            {
                Sql.errorLog("SQ03", "Error in Getting Specific Data from 2 Columns  -- " + ex.Message);
                alerts.messageBox("Database Error", "Erro:SQ03"); 
            }
            return mdr; 
        }


        /// <summary>
        /// Inserts a new row with data in the specified table
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="column_names"></param>
        /// <param name="column_data"></param>
        public static string insert_into_table(string tablename, string[] column_names, string[] column_data)
        {
            con = new SqlConnection(myconnection);
            if (OpenConnection() == true)
            {
                try
                { 
                    StringBuilder col = new StringBuilder();
                    StringBuilder data = new StringBuilder();
                    col.Append("(");
                    data.Append("('"); 
                    for (int b = 0; b < column_names.Length; b++)
                    {
                        col.Append(column_names[b]);
                        data.Append(column_data[b]);
                        if (b < column_names.Length - 1)
                        {
                            col.Append(",");
                            data.Append("','");
                        }
                    }
                    col.Append(")");
                    data.Append("')");

                    SqlCommand cmd = new SqlCommand("insert into " + tablename + col + "values" + data, con);

                    int i = cmd.ExecuteNonQuery();
                    cmd.Clone();
                    CloseConnection();
                    if (i != 0)
                    {
                        return "saved";
                    }
                    else
                    {
                        return "not_saved";
                    }


                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("duplicate"))
                    {
                        
                        return "duplicate";
                    }
                    else
                    {
                        Sql.errorLog("SQ02", "Error in SQL Insertion -- " + ex.Message);
                        alerts.messageBox("Database Error", "Error:SQ02");
                        return "SQL_Error";
                    }
                  
                   
                }

            } 
            else
            {
                return "connection_Error";
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">Name of database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name of column(s) to be read. Use "*" to read all columns</param>
        /// <returns>Datatable</returns>
        public static DataTable read_table(string tablename, string columns)
        {
            DataTable dataset = new DataTable();
            con = new SqlConnection(myconnection); 
            try
            {   
                if (OpenConnection() == true)
                {
                    SqlCommand cmd = new SqlCommand("SELECT " + columns + " FROM " + tablename, con);

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd; 

                    sda.Fill(dataset); 
                    CloseConnection();
                    
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Fetching Data "+ ex.Message );
            }
            return dataset;
             
        }

        /// <summary>
        /// Reads a row(s) containing a specific value
        /// </summary> 
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name(s) of column(s) to be read. Use "*" to read all columns</param>
        /// <param name="col_whr">Column containing the specific value</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public static DataTable read_where(string tablename, string columnsName, string col_whr, string value)
        {
            DataTable data = new DataTable();
            con = new SqlConnection(myconnection);
            if(tablename.Contains("error"))
            {
                return data = null;
            }

            try
            {
                if (OpenConnection() == true)
                {

                    SqlDataAdapter da = new SqlDataAdapter("SELECT " + columnsName + " FROM " + tablename + " WHERE " + col_whr + "='" + value + "';", con);

                    da.Fill(data);
                    con.Close();
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return data;
        }

        /// <summary>    
        /// Updates all values with a in column m, which correspond to b in column n.
        /// </summary>
        /// <param name="database">Name of Database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columnname">column to be updated (m)</param>
        /// <param name="new_value">the new value (a)</param>
        /// <param name="colwhr">column with corresponding value (n)</param>
        /// <param name="row_value">old value (b)</param>

        public static void update_table_where(string tablename, string[] column_names, string[] column_data, string colwhr, string row_value)
        {
            con = new SqlConnection(myconnection);
            if (OpenConnection() == true)
            {
                try
                {
                    StringBuilder col = new StringBuilder();

                    for (int b = 0; b < column_names.Length; b++)
                    {
                        col.Append(column_names[b]);

                        col.Append("='" + column_data[b] + "'");
                        if (b != column_names.Length - 1)
                        {
                            col.Append(",");
                        }
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE " + tablename + " SET  " + col + "  WHERE " + colwhr + "= '" + row_value + "'", con);

                    int i = cmd.ExecuteNonQuery();
                    cmd.Clone();
                    CloseConnection();
                    if (i != 0)
                    {
                        MessageBox.Show("Data Successfully Updated");

                    }
                    else
                    {
                        MessageBox.Show("Data Not Updated");

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Duplicate"))
                    {
                        MessageBox.Show("Data Already Exits");
                    }
                }
            }
        } /// <summary>    
        /// Updates all values with a in column m, which correspond to b in column n.
        /// </summary>
        /// <param name="database">Name of Database</param>
        /// <param name="tablename">Name of Table</param>
        /// <param name="columnname">column to be updated (m)</param>
        /// <param name="new_value">the new value (a)</param>
        /// <param name="colwhr">column with corresponding value (n)</param>
        /// <param name="row_value">old value (b)</param>

        public static string update_table_sync(string tablename, string[] column_names, string[] column_data, string colwhr, string row_value)
        {
            con = new SqlConnection(myconnection);
            string reply = "";
            
            if (OpenConnection() == true)
            {
                try
                {
                    StringBuilder col = new StringBuilder();

                    for (int b = 0; b < column_names.Length; b++)
                    {
                        col.Append(column_names[b]);

                        col.Append("='" + column_data[b] + "'");
                        if (b != column_names.Length - 1)
                        {
                            col.Append(",");
                        }
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE " + tablename + " SET  " + col + "  WHERE " + colwhr + "= '" + row_value + "'", con);

                    int i = cmd.ExecuteNonQuery();
                    cmd.Clone();
                    CloseConnection();
                    if (i != 0)
                    {
                       return reply = "Updated" ;

                    }
                    else
                    {
                        return reply = "Data Not Updated";

                    }
                }
                catch (Exception ex)
                {
                    Sql.errorLog("SQ Bulk Updatee", "Error in SQL Update -- " + ex.Message);
                    alerts.messageBox("Database Error", "Error: Bulk Update");
                    return "SQL_Error";

                }
            }
            return reply;
        }
        /// <summary>
        /// Error Log
        /// </summary> 
        /// <param name="tablename">Name of Table</param>
        /// <param name="columns">Name(s) of column(s) to be read. Use "*" to read all columns</param>
        /// <param name="col_whr">Column containing the specific value</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public static void errorLog( string errorCode, string errorDescription)
        {
            string table_errorlog = fetchData.fetch_tablename("errorlog");
          
            errorDescription = errorDescription.Replace("'", " ");
            DateTime now = DateTime.Now;
            string[] columnnames = { "errorCode", "errorDescription" ,"time"   };
            string[] columndata = { errorCode, errorDescription ,now.ToString()  };

            Sql.insert_into_table(table_errorlog, columnnames, columndata); 
        }



    }
}
