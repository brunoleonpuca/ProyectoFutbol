namespace ProyectoFutbol.BrowserSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class BrowserActions
    {
        protected readonly IWebDriver driver;
        public BrowserActions browserActions;
        public IWebElement element1;
        public IList<IWebElement> elements;
        public List<IWebElement> elem;

        private void sleep(int waitTime = 1) => Thread.Sleep(waitTime * 20);
        
        private WebDriverWait wait(int timeSpan = 5) => new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));

        public BrowserActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Browser actions
        /// <summary>
        /// Navigate to specific URL (Must be defined in 'app.config')
        /// </summary>
        /// <param name="url">URL</param>
        public void Get(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                new Exception(BrowserActionsExceptionsConsts.URLNotFound(url));
            }
        }

        /// <summary>
        /// Refreshes the actual URL
        /// </summary>
        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Navigates to the last URL
        /// </summary>
        public void GoBack()
        {
            driver.Navigate().Back();
        }

        public void GoToPreviousTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        /// <summary>
        /// Automatically scrolls into the view of the element
        /// </summary>
        /// <param name="locator"></param>
        public void ScrollIntoViewOfElement(By locator)
        {
            try
            {
                IWebElement element = driver.FindElement(locator);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Console.WriteLine("Page is scrolled to view the element");
            }
            catch
            {
                throw new Exception(ScraperActionsExceptionsConsts.ElementIsNotScrollable);
            }
        }

        /// <summary>
        /// Clicks the existing element in the URL
        /// </summary>
        public void ClickElement(By locator)
        {
            try
            {
                elements = WaitUntilElementIsClickableASAP(locator);
            }
            catch (Exception e)
            {
                if (e is ElementNotVisibleException)
                {
                    throw new Exception(ScraperActionsExceptionsConsts.ElementIsNotVisible);
                }
                else if (e is StaleElementReferenceException)
                {
                    throw new Exception(ScraperActionsExceptionsConsts.StaleElementReferenceException);
                }
                else if (e.Message.Contains(ScraperActionsExceptionsConsts.OtherElementIsClickedMessage))
                {
                    throw new Exception(ScraperActionsExceptionsConsts.OtherElementIsClickedException);
                }

                throw e;
            }
        }

        /// <summary>
        /// Type a text into element, If forceClear is false, it doesn't clear the input before typing
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <param name="forceClear"></param>
        /// <param name="attempts"></param>
        public void SendKeysToElement(By locator, string text, bool forceClear = false, int attempts = 10)
        {
            for (int i = 0; i < attempts; i++)
            {
                IWebElement element = driver.FindElement(locator);
                try
                {
                    if (forceClear)
                    {
                        element.Click();
                        element.SendKeys(Keys.Control + "a");
                        element.SendKeys(Keys.Delete);
                    }
                    else element.Clear();
                    element.SendKeys(text);

                    return;
                }
                catch (Exception e)
                {
                    if (i < 9) sleep();
                    else throw e;
                }

            }
        }
        #endregion

        #region Element builders
        /// <summary>
        /// Finds the element by It's locator
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="attempts"></param>
        /// <returns></returns>
        protected IWebElement FindSingleElement(By locator, int attempts = 10)
        {
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    return driver.FindElement(locator);
                }
                catch (Exception e)
                {
                    if (i < attempts - 1) sleep();
                    else
                    {
                        if (e is NoSuchElementException) throw new Exception(BrowserActionsExceptionsConsts.ElementNotFound(locator));
                        throw e;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Finds all the elements match by the locator
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="attempts"></param>
        /// <returns></returns>
        protected IList<IWebElement> FindTryMultipleElements(By locator)
        {
            try
            {
                elements = WaitUntilElementIsEnabledOrDisplayedASAP(locator);
                return elements;
            }
            catch (Exception e)
            {
                if (e is NoSuchElementException) throw new Exception(BrowserActionsExceptionsConsts.ElementsNotFound(locator));
                throw e;
            }
        }

        //protected List<T> GetListOfItems<T>(By locator)
        //{
        //    List<T> listOfItems = new List<T>();

        //    return listOfItems;
        //}
        #endregion

        #region Waiters
        public void WaitUntil(Func<bool> condition, int timeSpan = 10)
        {
            bool result;
            wait(timeSpan).Until<bool>(x => result = condition());
        }

        public IList<IWebElement> WaitUntilElementsAreDisplayed(By locator, int attempts = 2)
        {
            try
            {
                elements = driver.FindElements(locator);

                if (elements[0].Displayed || elements[0].Enabled) return elements;
                else
                {
                    for (int j = 0; j < attempts * 10; j++)
                    {
                        if (elements[1].Displayed || elements[1].Enabled) return elements;
                        sleep();
                    }
                }
            }
            catch (System.Exception) { sleep(); }

            return null;
            throw new Exception(ScraperActionsExceptionsConsts.ElementIsNotDisplayed);
        }

        /// <summary>
        /// Waits until the element is clickable or enabled in the URL
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="attempts"></param>
        /// <returns></returns>
        public bool WaitUntilElementIsClickable(By locator, int attempts = 10)
        {
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    if (driver.FindElement(locator).Enabled) return true;
                    else
                    {
                        for (int j = 0; j < attempts * 10; j++)
                        {
                            if (driver.FindElement(locator).Enabled) return true;
                            sleep();
                        }
                    }
                }
                catch (System.Exception) { sleep(); }
            }

            return false;
            throw new Exception(ScraperActionsExceptionsConsts.ElementIsNotClickable);
        }

        protected bool ElementVisible(IWebElement element)
        {
            return element.GetCssValue("visibility").Contains("visible");
        }

        protected bool ElementClickable(IWebElement element)
        {
            //return element.GetCssValue("cursor").Contains("pointer");
            return element.Displayed;

        }

        public List<IWebElement> WaitUntilElementIsClickableASAP(By locator)
        {
            IList<IWebElement> element = new List<IWebElement>();
            try
            {
                element = driver.FindElements(locator);
                WaitUntil(() => ElementClickable(element[0]));
                element[0].Click();
            }
            catch
            {

            }

            return element.ToList();
        }

        public List<IWebElement> WaitUntilElementIsEnabledOrDisplayedASAP(By locator)
        {
            IList<IWebElement> element = new List<IWebElement>();
            try
            {
                element = driver.FindElements(locator);
                WaitUntil(() => ElementVisible(element[0]));
            }
            catch
            {

            }
            
            return element.ToList();
        }
        #endregion
    }

    #region Scraper Exceptions Consts
    public static class ScraperActionsExceptionsConsts
    {
        public const string ElementIsNotDisplayed = "Exceeded timeout to wait for the element to be displayed";
        public const string ElementIsNotClickable = "Exceeded timeout to wait for the element to be enabled/clickable";
        public const string ElementIsNotScrollable = "Exceeded timeout to wait for the element to be scrollable";
        public const string ElementIsNotVisible = "ElementNotVisibleException: The element is not visible";
        public const string StaleElementReferenceException = "StaleElementReferenceException: The DOM has changed before the element has been clicked";
        public const string OtherElementIsClickedMessage = "Other element would receive the click";
        public const string OtherElementIsClickedException = "The element could not be clicked because another one is blocking it";
    }
    #endregion

    #region Browser Exceptions Consts
    public static class BrowserActionsExceptionsConsts
    {
        public static string URLNotFound(string url) => $"Couldn't navigate to URL: { url }";
        public static string ElementNotFound(By locator) => $"The element { locator } was not found";
        public static string ElementsNotFound(By locator) => $"The elements { locator } were not found";
    }
    #endregion
}
