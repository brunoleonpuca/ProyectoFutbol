namespace ProyectoFutbol.Scaper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using ProyectoFutbol.Builders.LeaguesBuilder;
    using ProyectoFutbol.db;

    public class Scraper : ScraperBase
    {
        private readonly List<League> leagues = new List<League>();
        private readonly DataAccess da = new DataAccess();
        private StringBuilder leagueBuilder = new StringBuilder();

        //[Test]
        //public void CheckConnection()
        //{
        //    onMainPageActions.SendKeysToSearchBar(LeagueConsts.consts[0]);
        //    onMainPageActions.ClickSearchButton();
        //    leagues.Add(onLeagueActions.GetLeagueInformation(LeagueConsts.consts[0]));
        //}

        [Test]
        public void GetLeagues()
        {

            //for (int i = 0; i < LeagueConsts.consts.Count; i++)
            //{
            //    onMainPageActions.SendKeysToSearchBar(LeagueConsts.consts[i]);
            //    onMainPageActions.ClickSearchButton();
            //    onLeagueActions.ClickLeague();
            //    onLeagueActions.GetLeagueInformationFromLeaguePage(); //Aca deberia manejar la nueva data y agregarla a 'leagues'
            //}

            for (int i = 0; i < LeagueConsts.consts.Count; i++)
            {
                onMainPageActions.ClickModalMessage();
                onMainPageActions.SendKeysToSearchBar(LeagueConsts.consts[i]);
                onMainPageActions.ClickSearchButton();
                leagues.Add(onLeagueActions.GetLeagueInformation(LeagueConsts.consts[i]));
                onLeagueActions.ClickLeague();
            }

            Assert.IsTrue(da.WriteLeagues(leagues));
        }

        [Test]
        public void GetAll()
        {
            try
            {
                for (int i = 0; i < LeagueConsts.consts.Count; i++)
                {
                    onMainPageActions.ClickModalMessage();
                    onMainPageActions.SendKeysToSearchBar(LeagueConsts.consts[i]);
                    onMainPageActions.ClickSearchButton();
                    leagues.Add(onLeagueActions.GetLeagueInformation(LeagueConsts.consts[i]));
                    onLeagueActions.ClickLeague();
                    leagues[i].Teams = onTeamActions.GetTeams();

                    for (int j = 0; j < leagues[i].Teams.Count; j++)
                    {
                        onMainPageActions.ClickModalMessage();
                        onTeamActions.ClickTeam(j);
                        leagues[i].Teams[j].Players = onPlayerActions.GetPlayers();
                        onMainPageActions.GoBack();
                    }

                    onMainPageActions.ClickGoUp();
                }
            }
            catch(Exception ex)
            {
                new Exception(ex.Message);
            }

            Assert.IsTrue(da.WriteLeaguesObjectTextfile(leagues));
            //Assert.IsTrue(da.WriteLeagues(leagues));
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