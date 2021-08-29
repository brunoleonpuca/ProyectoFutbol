namespace ProyectoFutbol.db
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using MySql.Data.MySqlClient;
    using ProyectoFutbol.Builders.LeaguesBuilder;

    public class DataAccess
    {
        private MySqlCommand cmd;

        public bool WriteLeagues(List<League> leagues)
        {
            bool b;
            try
            {
                using (MySqlConnection connection = Helper.CnnVal())
                {
                    connection.Open();

                    for (int i = 0; i < leagues.Count; i++)
                    {
                        MySqlDataReader MyReader;

                        string query = @"Insert into proyectofutboldb.leagues(idleague,name,country,continent,playerQuantity,teamQuantity,marketValue) Values('"
                        + leagues[i].LeagueID + "','" + leagues[i].Name + "','" + leagues[i].Country + "','" + leagues[i].Continent + "','" + leagues[i].PlayerQuantity + "','" + leagues[i].TeamQuantity + "','" + leagues[i].TotalMarketValue + "');";

                        cmd = new MySqlCommand(query, connection);
                        MyReader = cmd.ExecuteReader();
                        while (MyReader.Read())
                        {
                        }
                        MyReader.Close();
                    }

                    

                    connection.Close();
                    b = true;
                }
            }
            catch(Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }


            return b;
        }
    }
}