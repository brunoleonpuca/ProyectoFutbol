﻿namespace ProyectoFutbol.Scaper
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using ProyectoFutbol.Builders.LeaguesBuilder;

    public class Scraper : ScraperBase
    {
        private readonly List<League> leagues = new List<League>();

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

                    for (int j = 0; j < leagues[i].teams.Count; j++)
                    {
                        onTeamActions.ClickTeam(j);
                        leagues[i].teams[j].players = onPlayerActions.GetPlayers();
                        onMainPageActions.GoBack();
                    }

                    onMainPageActions.ClickGoUp();
                }
            }
            catch
            {
                PreviewDataGather.JsonBuilder(leagues);
            }
            finally
            {
                PreviewDataGather.JsonBuilder(leagues);
            }
        }
    }

    public class PreviewDataGather
    {
        public static void JsonBuilder(List<League> leagues)
        {
            string path = @"C:\repos\ProyectoFutbol\futbolFile.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Write the data gathered;
            string LigaProfParsed = JsonConvert.SerializeObject(leagues[0]);
            string PremierParsed = JsonConvert.SerializeObject(leagues[1]);
            string LaLigaParsed = JsonConvert.SerializeObject(leagues[2]);
            string SerieAParsed = JsonConvert.SerializeObject(leagues[3]);
            string LigueParsed = JsonConvert.SerializeObject(leagues[4]);

            //Debug.WriteLine(output);

            File.WriteAllText(path, LigaProfParsed
                           + "\n" + PremierParsed
                           + "\n" + LaLigaParsed
                           + "\n" + SerieAParsed
                           + "\n" + LigueParsed);

            File.Open(path, FileMode.Open);
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
