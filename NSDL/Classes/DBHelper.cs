using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace NSDL.Classes
{
    public class DBHelper
    {
        // Get count of some table on specified column value    
        private string _webConfigKey = "";
        private SqlConnection _sqlConnection;
        public SqlCommand _sqlCommand = new SqlCommand();

        //Constructor to pass nothing
        public DBHelper() 
        {
            try
            {
                _webConfigKey = "connection_string";
                string con = System.Configuration.ConfigurationManager.ConnectionStrings[_webConfigKey].ConnectionString;
                _sqlConnection = new SqlConnection(con);
                _sqlCommand.Connection = _sqlConnection;
            }
            catch (Exception)
            {
                
            }
            
        }

        //Constructor to pass web config key
        public DBHelper(string webConfigConnectionKey)
        {
            _webConfigKey = webConfigConnectionKey;
            string con = System.Configuration.ConfigurationManager.ConnectionStrings[_webConfigKey].ConnectionString;
            _sqlConnection = new SqlConnection(con);
        }

        //Constructor to pass Sql connection
        public DBHelper(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        //Getting Connection String
        public void getConnectionString()
        {
            _sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[_webConfigKey].ConnectionString);
        }

        //Opening Connection 
        private void OpenConnection()
        {
            _sqlConnection.Open();
        }

        //Closing Connection
        private void CloseConnection()
        {
            _sqlConnection.Close();
        }

        //Create SQL Command
        private SqlCommand CreateSqlCommand(string strQuery)
        {
            return new SqlCommand(strQuery, _sqlConnection);
        }

        //Execute non query and return integer and pass string query
        public int executeNonQuery(string strQuery)
        {
            try
            {
                OpenConnection();
                return CreateSqlCommand(strQuery).ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }


        //Execute non query and return integer and pass sql command
        public int executeNonQuery(SqlCommand sqlQuery)
        {
            try
            {
                OpenConnection();
                return sqlQuery.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }


        //Execute non query stored procedure and return integer and pass sql command
        public int executeNonQuerySP(string sqlQuery)
        {
            try
            {
                OpenConnection();
                _sqlCommand.CommandType = CommandType.StoredProcedure; ;
                _sqlCommand.CommandText = sqlQuery;
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                return _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }


        //Execute query and return data table when you pass string query
        public DataTable executeQuery(string strQuery)
        {
            try
            {
                DataTable dtResult = new DataTable();
                OpenConnection();
                dtResult.Load(CreateSqlCommand(strQuery).ExecuteReader());
                return dtResult;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                CloseConnection();
            }

        }

        //Execute query and return data table when you pass string query
        public DataTable executeQuery(SqlCommand sqlQuery)
        {
            try
            {
                DataTable dtResult = new DataTable();
                OpenConnection();
                dtResult.Load(sqlQuery.ExecuteReader());
                return dtResult;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                CloseConnection();
            }

        }


        public DataSet executeDataSet(string strQuery)
        {
            try
            {

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(strQuery, _sqlConnection);
                OpenConnection();
                da.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                CloseConnection();
            }

        }


        public DataSet executeDataSetSP(string strQuery)
        {
            try
            {
                DataSet ds = new DataSet();
                _sqlCommand.CommandText = strQuery;
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(_sqlCommand);
                OpenConnection();
                da.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                CloseConnection();
            }

        }


        //Execute query and return string when you pass string query
        public string executeScalar(string strQuery)
        {
            try
            {
                OpenConnection();
                return CreateSqlCommand(strQuery).ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }

        }

        public string executeScalarSP(string strQuery)
        {
            try
            {
                OpenConnection();
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.CommandText = strQuery;
                return _sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }

        }


        //Execute query and return string when you pass string query
        public string executeScalar(string tableName, string primaryKeyColumnName, string primaryKeyValue, string returnColumn)
        {
            try
            {
                string strQuery = "SELECT TOP 1 " + returnColumn + " FROM " + tableName + " WHERE " + primaryKeyColumnName + " = '" + primaryKeyValue + "' ;";
                OpenConnection();
                return CreateSqlCommand(strQuery).ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }

        }

        public DbDataReader ExecuteReaderSP(string strQuery)
        {
            try
            {
                OpenConnection();
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.CommandText = strQuery;
                return _sqlCommand.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // Get count of some table on specified column value    
        public int getCount(string tableName, string columnName, string columnValue)
        {
            return Convert.ToInt32(executeScalar(tableName, columnName, columnValue, "Count(*)"));
        }

        //Get Web Config Value
        public string GetWebConfigValue(string webConfigKey)
        {
            return System.Configuration.ConfigurationManager.AppSettings[webConfigKey];
        }
        
        //Call this method to set session value
        public void setSessionValue(string key, string value)
        {
            HttpContext.Current.Session.Add(key,value);
        }

        public string GetDtValue(DataTable dt, string key)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string _return= "";
                if (dr.IsNull(key))
                {
                    _return = null;
                }
                else
                {
                    _return = dr[key].ToString().Trim();
                }
                return _return;
            }   
            else
            {
                return null;
            }
        }

        //Call this method to Get session value
        public string getSessionValue(string key)
        {
            return HttpContext.Current.Session[key].ToString();
        }

        public void AddParameter(string name, object value)
        {
            _sqlCommand.Parameters.AddWithValue(name,value);   
        }
        

    }
}