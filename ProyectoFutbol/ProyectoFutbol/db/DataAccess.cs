namespace ProyectoFutbol.db
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using ProyectoFutbol.Builders.LeaguesBuilder;
    using ProyectoFutbol.Builders.TeamsBuilder;

    public class DataAccess
    {
        private MySqlCommand cmd;

        public bool ResetLeaguesTable()
        {
            bool b;
            try
            {
                using (MySqlConnection connection = Helper.CnnVal())
                {
                    connection.Open();
                    
                    string drop = "DROP TABLE IF EXISTS proyectofutboldb.leagues";
                    
                    cmd = new MySqlCommand(drop, connection);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    string createLeagues = @"CREATE TABLE leagues(leagueid INT PRIMARY KEY NOT NULL,
                    name VARCHAR(45), country VARCHAR(45), continent VARCHAR(45), teamQuantity INT,
                    playerQuantity INT, marketValue VARCHAR(45), moreValuablePlayer VARCHAR(45), 
                    moreTitlesTeam VARCHAR(45))";

                    cmd = new MySqlCommand(createLeagues, connection);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                    b = true;
                }
            }
            catch(Exception ex)
            {
                new Exception(ex.Message);
                b = false;
            }

            return b;
        }

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
                        + leagues[i].LeagueID + "','" + leagues[i].Name + "','" + leagues[i].Country + "','" + leagues[i].Region + "','" + leagues[i].PlayerQuantity + "','" + leagues[i].TeamQuantity + "','" + leagues[i].TotalMarketValue + "');";

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
                new Exception(ex.Message);
                return false;
            }

            return b;
        }

        //Work In Progress
        public bool WriteTeams(List<Team> teams)
        {
            bool b;
            try
            {
                using (MySqlConnection connection = Helper.CnnVal())
                {
                    connection.Open();

                    for (int i = 0; i < teams.Count; i++)
                    {
                        MySqlDataReader MyReader;

                        //string query = "Insert into proyectofutboldb.leagues(idleague,name,country,continent,playerQuantity,teamQuantity,marketValue) Values('"
                        //+ leagues[i].LeagueID + "','" + leagues[i].Name + "','" + leagues[i].Country + "','" + leagues[i].Continent + "','" + leagues[i].PlayerQuantity + "','" + leagues[i].TeamQuantity + "','" + leagues[i].TotalMarketValue + "');";

                        string query = "";

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
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return false;
            }

            return b;
        }

        public bool WriteLeaguesObjectTextfile(List<League> leagues)
        {
            bool b;
            // Create your data or fetch them;
            string json = JsonConvert.SerializeObject(leagues, Formatting.Indented);

            try
            {
                //write string to file
                if (File.Exists(@"C:\repos\ProyectoFutbol\leagues.txt"))
                {
                    File.Delete(@"C:\repos\ProyectoFutbol\leagues.txt");
                    File.WriteAllText(@"C:\repos\ProyectoFutbol\leagues.txt", json);
                    b = true;
                }
                else
                {
                    File.WriteAllText(@"C:\repos\ProyectoFutbol\leagues.txt", json);
                    b = true;
                }
            }
            catch
            {
                b = false;
            }
            
            return b;
        }
    }
}