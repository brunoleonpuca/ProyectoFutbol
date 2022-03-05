namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System.Collections.Generic;
    using ProyectoFutbol.Builders.TeamsBuilder;

    public class League
    {
        public static int GlobalLeagueID = 0;
        public int LeagueID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int TeamQuantity { get; set; }
        public int PlayerQuantity { get; set; }
        public string TotalMarketValue { get; set; }
        public string Continent { get; set; }
        public string MostValuablePlayer { get; set; }
        public string MostTitlesTeam { get; set; }

        public List<Team> Teams { get; set; }
    }
}