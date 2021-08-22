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
            int teamsCount = FindTryMultipleElements(TeamElements.TeamLocators.TeamsCount).Count;
            List<Team> teams = new List<Team>();
            for (int i = 1; i < teamsCount + 1; i++)
            {
                Team team = new Team();
                IWebElement nameElement = FindTryMultipleElements(TeamElements.TeamLocators.TeamName(i))[0];
                IWebElement marketValueElement = FindTryMultipleElements(TeamElements.TeamLocators.TeamMarketValue(i))[0];
                
                try
                {
                    team.name = nameElement != null ? nameElement.GetAttribute("innerHTML") : null;
                    team.marketValue = marketValueElement != null ? marketValueElement.GetAttribute("innerHTML") : null;
                    team.id = i;
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
            ClickElement(TeamElements.TeamLocators.TeamNameButton(i + 1));
        }
    }

    public static class TeamExceptions
    {
        public static string TeamBuildException(string team) => $"Couldn't build the team: { team }";
    }
}
