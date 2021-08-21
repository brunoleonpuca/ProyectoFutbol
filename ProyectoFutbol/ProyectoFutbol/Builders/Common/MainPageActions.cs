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
        public MainPageElements mainPageElements;
        public IWebDriver Driver;
        
        public MainPageActions(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            mainPageElements = new MainPageElements(Driver);
        }

        public void SendKeysToSearchBar(string league)
        {
            SendKeysToElement(mainPageElements.searchBarInput, league);
        }

        public void ClickSearchButton()
        {
            ClickElement(mainPageElements.searchButton);
        }

    }
}
