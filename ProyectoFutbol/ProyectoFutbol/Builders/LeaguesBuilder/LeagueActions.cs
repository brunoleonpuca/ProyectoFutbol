namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;

    public class LeagueActions : BrowserActions
    {
        public IWebDriver Driver;
        public List<League> leagues = new List<League>();

        public LeagueActions(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public League GetLeagueInformation(string leagueName)
        {
            League league = new League();

            try
            {
                league.name = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.name))[0].Text;
                league.country = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueCountry)[0].GetAttribute("alt");
                league.clubQuantity = int.Parse(FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.clubQuantity))[0].Text);
                league.playerQuantity = int.Parse(FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.playerQuantity))[0].Text);
                league.totalMarketValue = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.totalMarketValue))[0].Text;
                league.continent = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.continent))[0].Text;
            }
            catch
            {
                throw new Exception(LeagueExceptions.LeagueBuildException(leagueName));
            }

            return league;
        }

        public void ClickLeague()
        {
            ClickElement(LeagueElements.LeagueLocators.LeagueLink);
        }
    }

    public static class LeagueExceptions
    {
        public static string LeagueBuildException(string league) => $"Couldn't build the league: { league }";
    }
}