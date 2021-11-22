using System;
using System.Data.SqlClient;
using Dapper;

namespace TP10.Models{
    public static class BD{

        private static string _connectionString = @"Server=DESKTOP-2SPI6BB\SQLEXPRESS;DataBase=BDPadron;Trusted_Connection=True;";
        public static Persona ConsultarPadron(int DNI)
        {
            Persona persona=null;
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Personas WHERE DNI = @DNI";
                persona = connection.QueryFirstOrDefault<Persona>(query, new { DNI });
            }
            return persona;
        }



        public static Establecimiento ConsultarEstablecimiento(int Id)
        {
            Establecimiento establecimiento=null;
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Establecimiento WHERE IdEstablecimiento = @id";
                establecimiento = connection.QueryFirstOrDefault<Establecimiento>(query, new { Id });
            }
            return establecimiento;

        }

        public static bool Votar(int DNI, int NumeroTramite)
        {
            bool estado = false;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Personas SET Voto = 1 WHERE DNI = @DNI";
                var affectedRows = connection.Execute(query, new { DNI});

                if(affectedRows > 0)
                    estado = true;
            }

            return estado;
        }

    }
}