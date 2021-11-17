using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace apiMascota.Models
{
    public class CBaseDatos
    {
        public MySqlConnection connection;

        public CBaseDatos()
        {
            connection = new MySqlConnection("datasource=localhost;port=3310;username=root;password=Sena1234;database=facturas");
        }
        public string ejecutarSQL(string sql)
        {
            string resultado = "";

            connection.Open();

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            int filasResultado = cmd.ExecuteNonQuery();

            if (filasResultado > -1)
            {
                resultado = "Correcto";
            }
            else
            {
                resultado = "Incorrecto";
            }

            connection.Close();


            return resultado;

        }

    }
}
