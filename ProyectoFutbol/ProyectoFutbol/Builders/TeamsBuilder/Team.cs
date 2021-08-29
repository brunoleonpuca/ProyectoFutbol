namespace ProyectoFutbol.Builders.TeamsBuilder
{
    using System.Collections.Generic;
    using ProyectoFutbol.Builders.PlayersBuilder;

    public class Team
    {
        public int TeamID { get; set; }
        public static int GlobalTeamID = 0;
        public string Name { get; set; }
        public string MarketValue { get; set; }







        public List<Player> Players { get; set; }
    }
}