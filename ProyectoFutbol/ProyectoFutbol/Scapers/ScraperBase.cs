namespace ProyectoFutbol.Scaper
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;
    using ProyectoFutbol.Builders.Common;
    using ProyectoFutbol.Builders.LeaguesBuilder;
    using ProyectoFutbol.Builders.PlayersBuilder;
    using ProyectoFutbol.Builders.TeamsBuilder;

    public class ScraperBase : BrowserDriver
    {
        public static BrowserDriver selectBrowser = new BrowserDriver();
        public static IWebDriver driver = selectBrowser.SelectDefaultBrowser();
        public BrowserActions actions = new BrowserActions(driver);
        public Config config = new Config();

        public MainPageActions onMainPageActions = new MainPageActions(driver);
        public LeagueActions onLeagueActions = new LeagueActions(driver);
        public TeamActions onTeamActions = new TeamActions(driver);
        public PlayerActions onPlayerActions = new PlayerActions(driver);

        [OneTimeSetUp]
        public void BeforeAll()
        {
            actions.Get(config.TransferMrktURL);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            selectBrowser.KillDriver();
        }
    }
}