using Domain.Repository;
using Microsoft.Extensions.Configuration;
using Services.Data;

namespace Services.Operation
{
    public class MatchOperation
    {
        protected IConfiguration TheConfiguration { get; }
        protected IRepository TheAppRepository { get; }

        public MatchOperation(IConfiguration configuration, IRepository appRepository)
        {
            TheConfiguration = configuration;
            TheAppRepository = appRepository;
        }

        public Match GetMatch()
        {
            var evenPlayers = new List<Player>();
            var oddPlayers = new List<Player>();
            var teams = new List<Team>();
            // get the first 6 users
            var users = TheAppRepository.GetUsers().Take(6);
            foreach (var u in users)
            {
                // if users is even id
                if (u.Id % 2 == 0)
                {
                    evenPlayers.Add(new Player
                    {
                        Name = u.Name,
                        EmailAddress = u.Email,
                        City = u.Address?.City,
                        CompanyName = u.Company?.Name
                    });
                }
                // if user is odd id
                else
                {
                    oddPlayers.Add(new Player
                    {
                        Name = u.Name,
                        EmailAddress = u.Email,
                        City = u.Address?.City,
                        CompanyName = u.Company?.Name
                    });
                }
            }
            // if we have any even players we want to add them to a team
            if (evenPlayers.Count > 0)
            {
                teams.Add(new Team
                {
                    TeamName = "Team Even",
                    Players = evenPlayers
                });
            }
            // if we have any odd players we want to add them to a team
            if (oddPlayers.Count > 0)
            {
                teams.Add(new Team
                {
                    TeamName = "Team Odd",
                    Players = oddPlayers
                });
            }

            return new Match { Teams = teams };
        }


    }
}