using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerApp.Infrastructure.Data.SqlHelper
{
    public class SqlHelper
    {
        #region Fields

        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private readonly bool _isTransactional;

        #endregion


        #region Properties

        //public static Dictionary<string, ParamsSql> MultipleExecutes { get; set; } = new Dictionary<string, ParamsSql>();

        #endregion


        #region Constructor

        public SqlHelper(string conString, bool isTransactional = false)
        {
            _connection = new SqlConnection(conString);
            _isTransactional = isTransactional;
        }

        #endregion



        public void OpenCommandConnection(SqlCommand command)
        {
            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();
        }
        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Closed) return;
            _connection.Close();
        }

        #region Commands

        public SqlDataReader ExecuteReader(string procName, Params parameters = null)
        {
            SqlDataReader readerToReturn;

            using (var command = _connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procName;
                if (parameters != null)
                {

                    foreach (SqlParameter parameter in parameters.Items.Values)
                        command.Parameters.AddWithValue("@" + parameter.ParameterName, parameter.Value);
                }

                OpenCommandConnection(command);

                readerToReturn = command.ExecuteReader();

            }

            return readerToReturn;

        }

        public static SqlDataReader ExecuteReader(string conString,string procName, Params parameters = null)
        {
            SqlDataReader readerToReturn;

            using (var conn = new SqlConnection(conString))
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (parameters != null)
                    {

                        foreach (SqlParameter parameter in parameters.Items.Values)
                            command.Parameters.AddWithValue("@" + parameter.ParameterName, parameter.Value);
                    }

                    if (command.Connection.State != ConnectionState.Open)
                        command.Connection.Open();

                    readerToReturn = command.ExecuteReader();

                }
            }           

            return readerToReturn;
        }

        #endregion

        public class Params
        {
            public Dictionary<string, SqlParameter> Items { get; set; } = new Dictionary<string, SqlParameter>();

            public void Add(string name, object value, ParameterDirection dir = ParameterDirection.Input, int size = 0)
            {
                Items.Add(name, new SqlParameter(name, value)
                {
                    Direction = dir,
                    Size = size
                });
            }
        }
    }

    public static class SqlParse
    {
        ///Methods to get values of 
        ///individual columns from sql data reader
        #region Get Values from Sql Data Reader
        public static string GetNullableString(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }

        public static int GetNullableInt32(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        public static double GetNullableDouble(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToDouble(reader[colName]);
        }

        public static decimal GetNullableDecimal(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToDecimal(reader[colName]);
        }

        public static bool GetBoolean(SqlDataReader reader, string colName)
        {
            return !reader.IsDBNull(reader.GetOrdinal(colName)) && Convert.ToBoolean(reader[colName]);
        }

        //this method is to check wheater column exists or not in data reader
        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
        {
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

    }
}
