using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using Microsoft.Data.SqlClient;


namespace Lab_8
{
    public class DataBase
    {
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(); // создание конструктора строк подключения 
        SqlConnection sql_connection;

        public DataBase()
        {
            connectionStringBuilder.DataSource = @"PETYA";
            connectionStringBuilder.InitialCatalog = "Airport";
            //connectionStringBuilder.UserID = "admin";
            //connectionStringBuilder.Password = "admin";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.Encrypt = false;
            connectionStringBuilder.ConnectionString = connectionStringBuilder.ToString(); // добавлено
            sql_connection = new SqlConnection(connectionStringBuilder.ConnectionString);
        }

        public void OpenConnection()
        {
            if (sql_connection.State == System.Data.ConnectionState.Closed)
            {
                sql_connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sql_connection.State == System.Data.ConnectionState.Open)
            {
                sql_connection.Close();
            }
        }

        public SqlConnection SqlConnect()
        {
            return sql_connection;
        }


    }

}
