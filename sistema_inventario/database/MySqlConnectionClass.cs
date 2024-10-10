using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sistema_gestion_inventario.databases
{
    internal class MySqlConnectionClass
    {
        private string connectionString;
        public MySqlConnectionClass() {
            // Reemplaza los valores por los datos de tu servidor de MySQL
            connectionString = "server=localhost;port=3307;database=db;uid=user;pwd=password;";
        }
        // Método para abrir la conexión
        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexión establecida con éxito.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }

            return connection;
        }

        // Método para cerrar la conexión
        public void CloseConnection(MySqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        // Método para ejecutar una consulta SQL
        public void ExecuteQuery(string query)
        {
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Consulta ejecutada con éxito.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }
                finally
                {
                    CloseConnection(connection);
                }
            }
        }
    }
}
