namespace ProyectoFutbol.Builders.TeamsBuilder
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using ProyectoFutbol.BrowserSetup;

    public class TeamActions : BrowserActions
    {
        public IWebDriver Driver;
        public List<Team> teams = new List<Team>();

        public TeamActions(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public List<Team> GetTeams()
        {
            int teamsCount = FindTryMultipleElements(TeamLocators.TeamsCount).Count;
            List<Team> teams = new List<Team>();

            //Improve speed of the teams like the players.cs
            for (int i = 1; i < teamsCount + 1; i++)
            {
                Team team = new Team();
                IWebElement nameElement = FindTryMultipleElements(TeamLocators.TeamName(i))[0];
                IWebElement marketValueElement = FindTryMultipleElements(TeamLocators.TeamMarketValue(i))[0];
                
                try
                {
                    team.Name = nameElement != null ? nameElement.GetAttribute("innerHTML") : null;
                    team.MarketValue = marketValueElement != null ? marketValueElement.GetAttribute("innerHTML") : null;
                    team.TeamID = i;
                }
                catch
                {
                    throw new Exception(TeamExceptions.TeamBuildException(i.ToString()));
                }

                teams.Add(team);
            }

            return teams;
        }

        public void ClickTeam(int i)
        {
            ClickElement(TeamLocators.TeamNameButton(i + 1));
        }
    }

    public static class TeamExceptions
    {
        public static string TeamBuildException(string team) => $"Couldn't build the team: { team }";
    }
}
