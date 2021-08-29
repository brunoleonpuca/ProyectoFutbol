namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System.Collections.Generic;
    using ProyectoFutbol.Builders.TeamsBuilder;

    public class League
    {
        public int LeagueID { get; set; }
        public static int GlobalLeagueID = 0;
        
        public string Name { get; set; }
        public string Country { get; set; }
        public int TeamQuantity { get; set; }
        public int PlayerQuantity { get; set; }
        public string TotalMarketValue { get; set; }
        public string Continent { get; set; }
        public List<Team> Teams { get; set; }

        public enum columnValues
        {
            name = 2, teamQuantity = 4, playerQuantity = 5, totalMarketValue = 6, continent = 8
        }
    }
}
