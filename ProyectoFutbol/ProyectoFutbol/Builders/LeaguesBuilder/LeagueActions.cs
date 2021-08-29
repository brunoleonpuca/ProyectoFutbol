namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
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
                league.LeagueID = Interlocked.Increment(ref League.GlobalLeagueID);
                league.Name = FindTryMultipleElements(LeagueLocators.LeagueValueByColumn((int)League.columnValues.name))[0].Text;
                league.Country = FindTryMultipleElements(LeagueLocators.LeagueValueCountry)[0].GetAttribute("alt");
                league.TeamQuantity = int.Parse(FindTryMultipleElements(LeagueLocators.LeagueValueByColumn((int)League.columnValues.teamQuantity))[0].Text);
                league.PlayerQuantity = int.Parse(FindTryMultipleElements(LeagueLocators.LeagueValueByColumn((int)League.columnValues.playerQuantity))[0].Text);
                league.TotalMarketValue = FindTryMultipleElements(LeagueLocators.LeagueValueByColumn((int)League.columnValues.totalMarketValue))[0].Text;
                league.Continent = FindTryMultipleElements(LeagueLocators.LeagueValueByColumn((int)League.columnValues.continent))[0].Text;
            }
            catch
            {
                throw new Exception(LeagueExceptions.LeagueBuildException(leagueName));
            }

            return league;
        }

        public void ClickLeague()
        {
            ClickElement(LeagueLocators.LeagueLink);
        }
    }

    public static class LeagueExceptions
    {
        public static string LeagueBuildException(string league) => $"Couldn't build the league: { league }";
    }
}