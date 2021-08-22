namespace ProyectoFutbol.Builders.TeamsBuilder
{
    using System.Collections.Generic;
    using ProyectoFutbol.Builders.PlayersBuilder;

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string marketValue { get; set; }
        public List<Player> players { get; set; }
    }
}
