namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class League
    {
        public string name { get; set; }
        public int clubNumber { get; set; }
        public int playerNumber { get; set; }
        public string totalMarketValue { get; set; }
        public string continent { get; set; }

        //public List<Team> teams { get; set; }

        public enum columnValues
        {
            name = 2, clubNumber = 4, playerNumber = 5, totalMarketValue = 6, continent = 8
        }
    }
}
