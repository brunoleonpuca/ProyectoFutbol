namespace ProyectoFutbol.Builders.LeaguesBuilder
{
    using OpenQA.Selenium;

    public static class LeagueLocators
    {
        public static By LeagueValueByColumn(int col) => By.CssSelector($"#yw0 > table > tbody > tr > td:nth-child({ col })");
        public static By LeagueLink => By.CssSelector("#yw0 > table > tbody > tr > td:nth-child(2) > a");
        public static By LeagueValueCountry => By.CssSelector("#yw0 > table > tbody > tr > td:nth-child(3) > img");
        public enum columnValues
        {
            name = 2, teamQuantity = 4, playerQuantity = 5, totalMarketValue = 6, continent = 8
        }
    }

    public static class LL
    {
        public static By CompetitionsButton => By.CssSelector("#naviid_wettbewerbe > a");
        public static By LeagueValuable(int pos) => By.CssSelector($"#wettbewerb_head > div > div > div.box-content > div.box-personeninfos > div:nth-child(2) > table > tbody > tr:nth-child({ pos }) > td");
        public static By LeagueValuablePlayerValue => By.CssSelector($"#wettbewerb_head > div > div > div.box-content > div.box-personeninfos > div:nth-child(2) > table > tbody > tr:nth-child(4) > td > span");
        public static By ContainerInfo => By.CssSelector("#wettbewerb_head > div > div > div > div > div > table > tbody:nth-child(1) > tr");
        public enum valuableValues
        {
            team = 1, player = 3
        }
    }

    public static class PromiedosLeagueLocators
    {
        public static By ArgentinaLeague => By.CssSelector("#accordian > ul > li:nth-child(5) > ul > li:nth-child(2) > a");

        public static By TeamsButton => By.CssSelector("#botoneraliga > a:nth-child(2) > div");
    }
}