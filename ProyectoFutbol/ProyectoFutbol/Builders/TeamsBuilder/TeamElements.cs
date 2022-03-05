namespace ProyectoFutbol.Builders.TeamsBuilder
{
    using OpenQA.Selenium;

    public static class TeamLocators
    {
        public static By TeamsCount => By.CssSelector("#yw1 > table > tbody > tr > td:nth-child(3) > a");
        public static By TeamNameButton(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td:nth-child(1) > a");
        public static By TeamName(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td:nth-child(2)");
        public static By TeamMarketValue(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({row}) > td:nth-child(7) > a");
    }
}