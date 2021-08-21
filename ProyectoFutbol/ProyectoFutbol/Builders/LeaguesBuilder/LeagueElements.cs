namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public class LeagueElements
    {
        public IWebDriver leagueElements;

        public LeagueElements(IWebDriver element)
        {
            leagueElements = element;
        }

        public static class LeagueLocators
        {
            public static By LeagueRows => By.CssSelector("#yw0 > table > tbody > tr");
            public static By LeagueValueByColumn(int col) => By.CssSelector($"#yw0 > table > tbody > tr > td:nth-child({ col })");
        }
    }
}
