namespace ProyectoFutbol.Scaper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class Scraper : ScraperBase
    {

        [Test]
        public void GetLeagues()
        {
            for (int i = 0; i < LeagueConsts.consts.Count; i++)
            {
                onMainPageActions.SendKeysToSearchBar(LeagueConsts.consts[i]);
                onMainPageActions.ClickSearchButton();


            }
            
        }



    }

    public static class LeagueConsts
    {
        public static List<string> consts = new List<string>
        {
            { "Liga Profesional de Fútbol" },
            { "Liga inglesa" },
            { "Liga española" },
            { "Liga italiana" },
            { "Liga francesa" }
        };
    }
}
