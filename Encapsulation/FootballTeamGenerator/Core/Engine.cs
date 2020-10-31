using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    var cmdArgs = command.Split(';', StringSplitOptions.None).ToArray();

                    var cmdType = cmdArgs[0];

                    switch (cmdType)
                    {
                        case "Team":
                            AddTeam(cmdArgs);
                            break;
                        case "Add":
                            AddPlayerToTeam(cmdArgs);
                            break;
                        case "Remove":
                            RemovePlayer(cmdArgs);
                            break;
                        case "Rating":
                            PrintRating(cmdArgs);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }


        }

        private void PrintRating(string[] cmdArgs)
        {
            var teamName = cmdArgs[1];

            this.ValidateTeamExists(teamName);
            var team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayer(string[] cmdArgs)
        {
            var teamName = cmdArgs[1];
            var playerName = cmdArgs[2];

            this.ValidateTeamExists(teamName);
            var team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayerToTeam(string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            string playerName = cmdArgs[2];

            this.ValidateTeamExists(teamName);
            var team = this.teams.First(t => t.Name == teamName);

            var stats = this.CreateStats(cmdArgs.Skip(3).ToArray());

            var player = new Player(playerName, stats);

            team.AddPlayer(player);
        }

        private void AddTeam(string[] cmdArgs)
        {
            var teamName = cmdArgs[1];

            var team = new Team(teamName);

            this.teams.Add(team);
        }

        private void ValidateTeamExists(string name)
        {
            if (this.teams.All(t => t.Name != name))
            {
                throw new ArgumentException(string.Format(GlobalConstants.MissingTeamExceptionMessage, name));
            }
        }

        private Stats CreateStats(string[] cmdArgs)
        {
            var endurance = int.Parse(cmdArgs[0]);
            var sprint = int.Parse(cmdArgs[1]);
            var dribble = int.Parse(cmdArgs[2]);
            var passing = int.Parse(cmdArgs[3]);
            var shooting = int.Parse(cmdArgs[4]);

            var stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }
    }
}
