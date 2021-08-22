namespace ProyectoFutbol.Builders.TeamsBuilder
{
    using OpenQA.Selenium;

    public class TeamElements
    {
        public static class TeamLocators
        {
            public static By TeamsCount => By.CssSelector("#yw1 > table > tbody > tr > td:nth-child(3) > a");
            public static By TeamRow(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row })");
            public static By TeamName(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td.hauptlink.no-border-links.show-for-small.show-for-pad > a");
            public static By TeamNameButton(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td > a > img");
            public static By TeamMarketValue(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td:nth-child(10) > a");
        }
    }
}
