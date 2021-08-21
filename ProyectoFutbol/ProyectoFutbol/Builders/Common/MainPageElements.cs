namespace ProyectoFutbol.Builders.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;

    public class MainPageElements
    {
        public IWebDriver mainPageElements;

        public MainPageElements(IWebDriver element)
        {
            mainPageElements = element;
        }

        public static class MainPageLocators
        {
            public static By searchBarInput => By.CssSelector("#schnellsuche > input.header-suche");
            public static By searchButton => By.CssSelector("#schnellsuche > input.header-suche-abschicken");
            public static By goToMainButton => By.CssSelector("#header > div.row > div:nth-child(1) > a > img");
            public static By goUp => By.Id("arrow-up-xy");
        }

        public IWebElement searchBarInput => mainPageElements.FindElement(MainPageLocators.searchBarInput);
        public IWebElement searchButton => mainPageElements.FindElement(MainPageLocators.searchButton);
        public IWebElement goToMainButton => mainPageElements.FindElement(MainPageLocators.goToMainButton);
        public IWebElement goUp => mainPageElements.FindElement(MainPageLocators.goUp);
    }
}
