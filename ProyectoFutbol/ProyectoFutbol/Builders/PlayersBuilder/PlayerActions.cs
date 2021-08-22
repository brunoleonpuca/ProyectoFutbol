namespace ProyectoFutbol.Builders.PlayersBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;

    public class PlayerActions : BrowserActions
    {
        public IWebDriver Driver;
        public List<Player> players = new List<Player>();

        public PlayerActions(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Goes through the list of players. Must change to entire table instead of rows to improve speed
        /// </summary>
        /// <returns>List of players</returns>
        public List<Player> GetPlayers()
        {
            int playersCount = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayersCount).Count;
            List<Player> players = new List<Player>();
            List<IWebElement> _players = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayersRows).ToList();
            //Devuelve todo menos el country, lo hace mas rapido que lo de abajo, mappear la data de "_players" haria todo mucho mas rapido

            for (int i = 1; i <= playersCount; i++)
            {
                Player player = new Player();
                string _number = string.Empty;

                try
                {
                    IWebElement nameElement = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayerName(i))[0];
                    IWebElement numberElement = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayerNumber(i))[0];
                    IWebElement countryElement = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayerCountry(i))[0];
                    IWebElement marketValueElement = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayerMarketValue(i))[0];
                    IWebElement dateOfBirthElement = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayerDateOfBirth(i))[0];
                    IWebElement positionElement = FindTryMultipleElements(PlayerElements.PlayerLocators.PlayerPosition(i))[0];

                    player.name = nameElement != null ? nameElement.GetAttribute("innerHTML") : null;
                    player.number = numberElement.GetAttribute("innerHTML") == "-" ? 0 : int.Parse(numberElement.GetAttribute("innerHTML"));
                    player.country = countryElement != null ? countryElement.GetAttribute("alt") : null;
                    player.marketValue = marketValueElement != null ? marketValueElement.GetAttribute("innerHTML").Split('€')[0] + '€' : null;
                    player.dateOfBirth = dateOfBirthElement != null ? dateOfBirthElement.GetAttribute("innerHTML") : null;
                    player.position = positionElement != null ? positionElement.GetAttribute("innerHTML") : null;

                    players.Add(player);
                }
                catch
                {
                    throw new Exception(PlayerExceptions.PlayerBuildException(i.ToString()));
                }
            }

            return players;
        }
    }

    public static class PlayerExceptions
    {
        public static string PlayerBuildException(string player) => $"Couldn't build the player: { player }";
    }
}
