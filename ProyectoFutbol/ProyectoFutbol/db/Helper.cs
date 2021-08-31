namespace ProyectoFutbol
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    public static class Helper
    {
        private static readonly Config config = new Config();
        private static MySqlConnection databaseConnection = null;

        public static MySqlConnection CnnVal()
        {
            if (databaseConnection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[config.ConnectionString].ConnectionString;
                databaseConnection = new MySqlConnection(connectionString);
            }

            return databaseConnection;
        }


    }
}
