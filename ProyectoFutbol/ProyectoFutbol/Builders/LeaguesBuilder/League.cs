namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System.Collections.Generic;
    using ProyectoFutbol.Builders.TeamsBuilder;

    public class League
    {
        public string name { get; set; }
        public string country { get; set; }
        public int clubQuantity { get; set; }
        public int playerQuantity { get; set; }
        public string totalMarketValue { get; set; }
        public string continent { get; set; }
        public List<Team> teams { get; set; }

        public enum columnValues
        {
            name = 2, clubQuantity = 4, playerQuantity = 5, totalMarketValue = 6, continent = 8
        }
    }
}
