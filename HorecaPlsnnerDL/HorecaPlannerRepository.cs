using HorecaPlannerBL.Interfaces;
using HorecaPlannerBL.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorecaPlsnnerDL
{
    public class HorecaPlannerRepository : IHorecaPlannerRepository
    {
        private string connectionString;

        public HorecaPlannerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Werknemer> GeefWerknemers()
        {
            List<Werknemer> data = new();
            string query = "SELECT * FROM werknemer";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new Werknemer((int)reader["id"], (string)reader["naam"], (string)reader["telnr"], (string)reader["email"]));
                    }
                }
            }
            return data;
        }

        public bool HeeftWerknemer(Werknemer werknemer)
        {
            string query = "SELECT count(*) FROM werknemer WHERE email = @email";
            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@email", werknemer.Email);
                connection.Open();
                if((int)cmd.ExecuteScalar() ==0) return false; else return true;
            }
        }

        public void VoegWerknemerToe(Werknemer werknemer)
        {
            string query = "INSERT INTO werknemer(naam, telnr, email) OUTPUT INSERTED.ID VALUES(@naam, @telnr, @email)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@naam", werknemer.Naam);
                cmd.Parameters.AddWithValue("@telnr", werknemer.Telnr);
                cmd.Parameters.AddWithValue("@email", werknemer.Email);
                connection.Open();
                werknemer.Id = (int)cmd.ExecuteScalar();
            }
        }
    }
}
