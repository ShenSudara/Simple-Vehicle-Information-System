using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Info.config
{
    class DatabaseConnection
    {
        //Gloabal objects
        private SqlConnection con = null;
        private const string CONNECTION_STRING = "Data Source=.;Initial Catalog=vehicleinfodb;Integrated Security=True";
        
        //constructor: initialize the new sql connection
        public DatabaseConnection()
        {
            con = new SqlConnection();
        }

        //open a new sql connection
        public void openConnection()
        {
            con.ConnectionString = CONNECTION_STRING;
            con.Open();
        }

        //close a new sql connection
        public void closeConnection()
        {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            con.Close();
        }

        //get a new connection
        public SqlConnection getConnection()
        {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            return con;
        }

        //start a transaction
        public SqlTransaction startTransaction() {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            SqlTransaction transaction = con.BeginTransaction();
            return transaction;
        }

        //commit transaction
        public void commitTransaction(SqlTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException("transaction should be initialized");
            transaction.Commit();
        }

        //roll back transaction
        public void rollbackTransaction(SqlTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException("transaction should be initialized");
            transaction.Rollback();
        }

        //execute a query with sql command
        public int executeQuery(SqlCommand cmd)
        {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            if (cmd == null || cmd.CommandText == null || cmd.CommandText == string.Empty) throw new ArgumentNullException("sql command should be initialized");

            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }

        //execute a sql command with transaction
        public int executeQuery(SqlCommand cmd, SqlTransaction transaction)
        {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            if (cmd == null || cmd.CommandText == null || cmd.CommandText == string.Empty) throw new ArgumentNullException("sql command should be initialized");
            if(transaction == null) throw new ArgumentNullException("transaction should be initialized");

            cmd.Connection = con;
            cmd.Transaction = transaction;
            return cmd.ExecuteNonQuery();
        }

        //get data table from a sql command
        public DataTable getDataTable(SqlCommand cmd)
        {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            if (cmd == null || cmd.CommandText == null || cmd.CommandText == string.Empty) throw new ArgumentNullException("sql command should be initialized");

            DataTable dt = new DataTable();
            cmd.Connection = con;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        //get single value from sql command
        public object getSingleValue(SqlCommand cmd)
        {
            if (con == null || con.State == ConnectionState.Closed) throw new NullReferenceException("database connection should be initialized");
            if (cmd == null || cmd.CommandText == null || cmd.CommandText == string.Empty) throw new ArgumentNullException("sql command should be initialized");

            cmd.Connection = con;
            object value = cmd.ExecuteScalar();
            if (value != null && value != DBNull.Value)
            {
                return value;
            }
            return null;
        }
    }
}
