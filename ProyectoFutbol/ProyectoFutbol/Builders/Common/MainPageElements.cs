namespace ProyectoFutbol.Builders.Common
{
    using OpenQA.Selenium;

    public static class MainPageLocators
    {
        public static By searchBarInput => By.CssSelector("#schnellsuche > input.header-suche");
        public static By searchButton => By.CssSelector("#schnellsuche > input.header-suche-abschicken");
        public static By goToMainButton => By.CssSelector("#header > div.row > div:nth-child(1) > a > img");
        public static By goUp => By.Id("arrow-up-xy");
    }
}
