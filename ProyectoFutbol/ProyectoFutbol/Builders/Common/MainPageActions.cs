namespace ProyectoFutbol.Builders.Common
{
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
            WaitUntilElementIsEnabledOrDisplayedASAP(MainPageLocators.searchBarInput);
            SendKeysToElement(MainPageLocators.searchBarInput, league);
        }

        public void ClickSearchButton()
        {
            ClickElement(MainPageLocators.searchButton);
        }

        public void ClickGoUp()
        {
            ClickElement(MainPageLocators.goUp);
        }

    }
}
