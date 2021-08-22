namespace ProyectoFutbol.BrowserSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class BrowserDriver
    {
        private IWebDriver driver;
        private ChromeOptions options;
        private Config configuration = new Config();

        //This class is to download files:
        //private DriverManager webDriverManager;

        public IWebDriver SelectDefaultBrowser()
        {
            try
            {
                if (configuration.DefaultBrowser.Equals(DriverConsts.Chrome))
                {
                    options = new ChromeOptions();

                    //Loads adblock to chromedriver
                    options.AddExtension("C:\\repos\\ChromeExtensions\\4.35.0_0.crx");

                    driver = new ChromeDriver(options);
                    driver.Manage().Window.Maximize();
                }
            }
            catch
            {
                throw new Exception(DriverExceptionsConsts.BrowserNotValidException);
            }

            return driver;
        }

        public void KillDriver()
        {
            try
            {
                driver.Quit();
            }
            catch
            {
                throw new Exception(DriverExceptionsConsts.KillDriverException);
            }
        }

        public static class DriverConsts
        {
            public static string Chrome = "Chrome";
        }

        public static class DriverExceptionsConsts
        {
            public static string BrowserNotValidException = "The browser is not valid";
            public static string KillDriverException = "Couldn't kill driver";
        }
    }
}
