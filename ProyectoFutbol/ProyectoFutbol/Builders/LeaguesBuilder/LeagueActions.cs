namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;
    using ProyectoFutbol.Scaper;

    public class LeagueActions : BrowserActions
    {
        public LeagueElements leagueElements;
        public IWebDriver Driver;
        public List<League> leagues = new List<League>();

        public LeagueActions(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            leagueElements = new LeagueElements(Driver);
        }

        public League GetLeagueInformation()
        {
            League league = new League
            {
                name = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.name))[0].Text,
                clubNumber = int.Parse(FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.clubNumber))[0].Text),
                playerNumber = int.Parse(FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.playerNumber))[0].Text),
                totalMarketValue = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.totalMarketValue))[0].Text,
                continent = FindTryMultipleElements(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.continent))[0].Text
            };

            return league;
        }

        public void ClickLeague()
        {
            ClickElement(LeagueElements.LeagueLocators.LeagueValueByColumn((int)League.columnValues.name));
        }
    }
}