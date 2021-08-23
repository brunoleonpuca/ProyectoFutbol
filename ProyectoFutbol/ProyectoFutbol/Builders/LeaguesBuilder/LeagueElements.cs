namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using OpenQA.Selenium;

    public static class LeagueLocators
    {
        public static By LeagueRows => By.CssSelector("#yw0 > table > tbody > tr");
        public static By LeagueValueByColumn(int col) => By.CssSelector($"#yw0 > table > tbody > tr > td:nth-child({ col })");
        public static By LeagueLink => By.CssSelector("#yw0 > table > tbody > tr > td:nth-child(2) > a");
        public static By LeagueValueCountry => By.CssSelector("#yw0 > table > tbody > tr > td:nth-child(3) > img");
    }
}
