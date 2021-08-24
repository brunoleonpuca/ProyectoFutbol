namespace ProyectoFutbol.Builders.PlayersBuilder
{
    using System.Collections.Generic;
    using System.Linq;
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
            List<Player> players = new List<Player>();
            //int playersCount = FindTryMultipleElements(PlayerLocators.PlayersCount).Count;



            List<IWebElement> _players = FindTryMultipleElements(PlayerLocators.PlayersRows).ToList();

            for (int i = 0; i < _players.Count; i++)
            {
                Player _player = new Player();

                List<string> cleanPlayer = _players[i].Text.Replace("\r\n", " ").Split(' ').ToList();

                #region Player Mapper
                /*
              
              NEED FIX FOR GOALKEEPERS NAMES
              If It's still breaking goalkeepers maybe try the .Trim function
            
              Or this Regex solution:
               var oldString = "the quick brown\rfox jumped over\nthe box\r\nand landed on some rocks.";
               var newString = string.Join(" ", Regex.Split(oldString, @"(?:\r\n|\n|\r)"));
               Console.Write(newString);
            
            
                CAPAZ EL FIX PUEDE SER BUSCAR PRIMERO LA POSICION Y DESPUES LOS NOMBRES, TOTAL LOS BUGEADOS
                SON UNICAMENTE LOS ARQUEROS...NADA...PARA PENSAR


             */
                if (cleanPlayer.Count == 14)
                {
                    _player.number = cleanPlayer[0] == "-" ? 0 : int.Parse(cleanPlayer[0]);
                    _player.name = cleanPlayer[1] + " " + cleanPlayer[2] + " " + cleanPlayer[3] + " " + cleanPlayer[4];
                    _player.position = cleanPlayer[5] + " " + cleanPlayer[6];
                    _player.dateOfBirth = cleanPlayer[7] + " " + cleanPlayer[8];
                    _player.marketValue = cleanPlayer[9] + "" + cleanPlayer[10] + " " + cleanPlayer[11];
                }
                else if (cleanPlayer.Count == 13)
                {
                    _player.number = cleanPlayer[0] == "-" ? 0 : int.Parse(cleanPlayer[0]);
                    _player.name = cleanPlayer[1] + " " + cleanPlayer[2] + " " + cleanPlayer[3];
                    _player.position = cleanPlayer[4] + " " + cleanPlayer[5];
                    _player.dateOfBirth = cleanPlayer[6] + " " + cleanPlayer[7];
                    _player.marketValue = cleanPlayer[8] + "" + cleanPlayer[9] + " " + cleanPlayer[10];
                }
                else if (cleanPlayer.Count == 12)
                {
                    _player.number = cleanPlayer[0] == "-" ? 0 : int.Parse(cleanPlayer[0]);
                    _player.name = cleanPlayer[1] + " " + cleanPlayer[2];
                    _player.position = cleanPlayer[3] + " " + cleanPlayer[4];
                    _player.dateOfBirth = cleanPlayer[5] + " " + cleanPlayer[6];
                    _player.marketValue = cleanPlayer[7] + "" + cleanPlayer[8] + " " + cleanPlayer[9];
                }
                else if (cleanPlayer.Count == 11)
                {
                    _player.number = cleanPlayer[0] == "-" ? 0 : int.Parse(cleanPlayer[0]);
                    _player.name = cleanPlayer[1] + " " + cleanPlayer[2];
                    _player.position = cleanPlayer[3];
                    _player.dateOfBirth = cleanPlayer[4] + " " + cleanPlayer[5];
                    _player.marketValue = cleanPlayer[6] + "" + cleanPlayer[7] + " " + cleanPlayer[8];
                }

                IWebElement countryElement = FindTryMultipleElements(PlayerLocators.PlayerCountry(i + 1))[0];
                _player.country = countryElement != null ? countryElement.GetAttribute("alt") : null;
                #endregion

                players.Add(_player);
            }

            #region Players Mappser - OLD
            //OLD WAY, SLOW WAY
            /*for (int i = 1; i <= playersCount; i++)
            {
                Player player = new Player();
                string _number = string.Empty;
                
                //IWebElement nameElement = FindTryMultipleElements(PlayerLocators.PlayerName(i))[0];
                //IWebElement numberElement = FindTryMultipleElements(PlayerLocators.PlayerNumber(i))[0];
                //IWebElement marketValueElement = FindTryMultipleElements(PlayerLocators.PlayerMarketValue(i))[0];
                //IWebElement dateOfBirthElement = FindTryMultipleElements(PlayerLocators.PlayerDateOfBirth(i))[0];
                //IWebElement positionElement = FindTryMultipleElements(PlayerLocators.PlayerPosition(i))[0];

                //player.name = nameElement != null ? nameElement.GetAttribute("innerHTML") : null;
                //player.number = numberElement.GetAttribute("innerHTML") == "-" ? 0 : int.Parse(numberElement.GetAttribute("innerHTML"));
                //player.marketValue = marketValueElement != null ? marketValueElement.GetAttribute("innerHTML").Split('€')[0] + '€' : null;
                //player.dateOfBirth = dateOfBirthElement != null ? dateOfBirthElement.GetAttribute("innerHTML") : null;
                //player.position = positionElement != null ? positionElement.GetAttribute("innerHTML") : null;

                try
                {
                    
                    IWebElement countryElement = FindTryMultipleElements(PlayerLocators.PlayerCountry(i))[0];
                    player.country = countryElement != null ? countryElement.GetAttribute("alt") : null;

                    players.Add(player);
                }
                catch
                {
                    throw new Exception(PlayerExceptions.PlayerBuildException(i.ToString()));
                }
            }*/
            #endregion

            return players;
        }
    }

    public static class PlayerExceptions
    {
        public static string PlayerBuildException(string player) => $"Couldn't build the player: { player }";
    }
}
