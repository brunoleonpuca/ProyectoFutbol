namespace ProyectoFutbol.Scaper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using ProyectoFutbol.Builders.LeaguesBuilder;

    public class Scraper : ScraperBase
    {
        private List<League> leagues = new List<League>();

        [Test]
        public void GetLeagues()
        {
            try
            {
                for (int i = 0; i < LeagueConsts.consts.Count; i++)
                {
                    onMainPageActions.SendKeysToSearchBar(LeagueConsts.consts[i]);
                    onMainPageActions.ClickSearchButton();
                    leagues.Add(onLeagueActions.GetLeagueInformation(LeagueConsts.consts[i]));
                    onLeagueActions.ClickLeague();
                    leagues[i].teams = onTeamActions.GetTeams();

                }
            }
            catch
            {

            }
            finally
            {
                //Write the data gathered
                for (int i = 0; i < LeagueConsts.consts.Count; i++)
                {
                    string output = JsonConvert.SerializeObject(leagues[i]);
                    //League deserializedProduct = JsonConvert.DeserializeObject<League>(output);
                    Debug.WriteLine(output);
                }
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
