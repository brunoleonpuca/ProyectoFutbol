namespace ProyectoFutbol.Scaper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;

    public class ScraperBase
    {
        public static BrowserDriver selectBrowser = new BrowserDriver();
        public static IWebDriver driver = selectBrowser.SelectDefaultBrowser();
        public BrowserActions actions = new BrowserActions(driver);
        public Config config = new Config();

        [OneTimeSetUp]
        public void BeforeAll()
        {
            actions.Get(config.TransferMrktURL);
            actions.GoToPreviousTab();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            selectBrowser.KillDriver();
        }
    }
}
