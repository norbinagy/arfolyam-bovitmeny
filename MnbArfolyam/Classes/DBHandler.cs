using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace MnbArfolyam.Classes
{
    public static class DBHandler
    {
        static SqlConnection connection;
        static SqlCommand command;

        static DBHandler()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Létrehoz egy új rekordot a Logs táblában, az adatbázisban a megadott felhasználó névvel.
        /// </summary>
        /// <param name="username">Felhasználó név</param>
        public static void InsertUser(string username)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO Logs (FelhasznaloNev) VALUES (@felhasznaloNev)";
                command.Parameters.AddWithValue("@felhasznaloNev", username);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lekérdezi a Logs tábla rekordjait.
        /// </summary>
        /// <returns>List az adatokkal</returns>
        public static List<DBLog> GetUsers()
        {
            try
            {
                List<DBLog> list = new List<DBLog>();
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Logs";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DBLog(Convert.ToInt32(reader["Id"]), reader["FelhasznaloNev"].ToString(), Convert.ToDateTime(reader["Idopont"]), reader["Indoklas"].ToString()));
                    }
                }
                return list;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Az Indoklas mezőt frissíti a kívánt rekordnál.
        /// </summary>
        /// <param name="id">A rekord azonosítója.</param>
        /// <param name="text">Az új szöveg.</param>
        public static void InsertReason(int id, string text)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = "UPDATE Logs SET Indoklas = @indoklas WHERE Id = @id";
                command.Parameters.AddWithValue("@indoklas", text);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
