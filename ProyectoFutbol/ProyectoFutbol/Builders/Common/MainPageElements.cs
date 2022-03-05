namespace ProyectoFutbol.Builders.Common
{
    using OpenQA.Selenium;

    public static class MainPageLocators
    {
        public static By searchBarInput => By.ClassName("tm-header__input--search-field");
        public static By searchButton => By.ClassName("tm-header__input--search-send");
        public static By goToMainButton => By.CssSelector("#header > div.row > div:nth-child(1) > a > img");
        public static By goUp => By.Id("arrow-up-xy");
        public static By modalMessageBox => By.XPath("");
        public static By messageModalAcceptButton => By.XPath("//*[@id='notice']/div[3]/div[2]/button");
    }
}