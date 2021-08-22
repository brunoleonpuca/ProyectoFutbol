namespace ProyectoFutbol.Builders.PlayersBuilder
{
    using OpenQA.Selenium;

    public class PlayerElements
    {
        public static class PlayerLocators
        {
            public static By PlayersCount => By.CssSelector("#yw1 > table > tbody > tr > td:nth-child(1)");
            public static By PlayersRows => By.CssSelector($"#yw1 > table > tbody > tr");
            public static By PlayerNumber(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td > div");
            public static By PlayerName(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td.posrela > table > tbody > tr:nth-child(1) > td.hauptlink > div:nth-child(1) > span > a");
            public static By PlayerPosition(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td.posrela > table > tbody > tr:nth-child(2) > td");
            public static By PlayerDateOfBirth(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td:nth-child(4)");
            public static By PlayerCountry(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td:nth-child(5) > img");
            public static By PlayerMarketValue(int row) => By.CssSelector($"#yw1 > table > tbody > tr:nth-child({ row }) > td.rechts.hauptlink");
        }
    }
}
