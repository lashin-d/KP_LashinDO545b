using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HotelDBClientApp
{
    public class DatabaseManager
    {
        private readonly string connectionString;
        private MySqlConnection connection;

        public DatabaseManager(string connString)
        {
            connectionString = connString;
            connection = new MySqlConnection(connectionString);
        }

        public string ConnectionString => connectionString;

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка виконання запиту: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка виконання команди: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public object ExecuteScalar(string query)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка виконання команди: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}