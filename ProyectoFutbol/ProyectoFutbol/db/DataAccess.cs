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
        public bool CheckConnection(League league)
        {
            string query = @"Insert into proyectofutboldb.leagues(idleague,name,country,continent,playerQuantity,teamQuantity,marketValue) Values('" + league.LeagueID + "','" + league.Name + "','" + league.Country + "','" + league.Continent + "','" + league.PlayerQuantity + "','" + league.TeamQuantity + "','" + league.TotalMarketValue + "');";
            bool b;
            try
            {
                using (MySqlConnection connection = Helper.CnnVal())
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader MyReader;

                    //cmd.Parameters.Add(new MySqlParameter("@idleague", league.LeagueID));
                    //cmd.Parameters.Add(new MySqlParameter("@name", league.Name));
                    //cmd.Parameters.Add(new MySqlParameter("@country", league.Country));
                    //cmd.Parameters.Add(new MySqlParameter("@continent", league.Continent));
                    //cmd.Parameters.Add(new MySqlParameter("@teamQuantity", league.TeamQuantity));
                    //cmd.Parameters.Add(new MySqlParameter("@playerQuantity", league.PlayerQuantity));
                    //cmd.Parameters.Add(new MySqlParameter("@marketValue", league.TotalMarketValue));

                    MyReader = cmd.ExecuteReader();
                    while (MyReader.Read())
                    {
                    }
                    connection.Close();
                    b = true;
                }
            }
            catch(Exception ex)
            {
                b = false;
                new Exception(ex.Message);
            }

            return b;
        }

        public void WriteLeagues(List<League> leagues)
        {
            using (MySqlConnection connection = Helper.CnnVal())
            {
                //connection.Query<League>($"SELECT * FROM Leagues'").ToList();

                foreach (var league in leagues)
                {
                    SaveToDatabase(connection, league); 
                }

                Console.Read();
            }
        }

        /// <summary>
        /// Insert to database
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="league"></param>
        /// <returns></returns>
        public static bool SaveToDatabase(MySqlConnection connection, League league)
        {
            try
            {
                string insertQuery = @"Insert into AllItemsTable(LocalTimestamp,Id,Description,Processed,Position1,Position2) Values(@LocalTimestamp,@Id,@Description,@Processed,@Position1,@Position2)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@LocalTimestamp", league.LeagueID));
                    cmd.Parameters.Add(new MySqlParameter("@Id", league.Name));
                    cmd.Parameters.Add(new MySqlParameter("@Description", league.Country));
                    cmd.Parameters.Add(new MySqlParameter("@Processed", league.Continent));
                    cmd.Parameters.Add(new MySqlParameter("@Processed", league.TeamQuantity));
                    cmd.Parameters.Add(new MySqlParameter("@Processed", league.PlayerQuantity));
                    cmd.Parameters.Add(new MySqlParameter("@Processed", league.TotalMarketValue));

                    //for (int index = 0; index < league.Position.Count; index++)
                    //{
                    //    if (index == 0)
                    //        cmd.Parameters.Add(new SqlParameter("@Position1", league.Position[index].ToString()));
                    //    else
                    //        cmd.Parameters.Add(new SqlParameter("@Position2", league.Position[index].ToString()));
                    //}

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception objEx)
            {
                return false;
            }
        }
    }
}
