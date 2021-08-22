namespace ProyectoFutbol.Builders.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;

    public class MainPageActions : BrowserActions
    {
        public IWebDriver Driver;
        
        public MainPageActions(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public void SendKeysToSearchBar(string league)
        {
            ScrollIntoViewOfElement(MainPageElements.MainPageLocators.searchBarInput);
            SendKeysToElement(MainPageElements.MainPageLocators.searchBarInput, league);
        }

        public void ClickSearchButton()
        {
            ClickElement(MainPageElements.MainPageLocators.searchButton);
        }

    }
}
