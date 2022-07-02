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
            return new Match { Teams = null };
        }
    }
}