using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Services.Data;
using Services.Operation;

namespace Web.Api
{
    [ApiController]
    [Route("api")]
    public class MatchController : ControllerBase
    {
        protected IConfiguration TheConfiguration { get; }
        protected IRepository TheRepository { get; }
        protected MatchOperation GetMatchOperationInstance() { return new MatchOperation(TheConfiguration, TheRepository); }
        public MatchController(IConfiguration configuration, IRepository repository)
        {
            TheConfiguration = configuration;
            TheRepository = repository;
        }

        [HttpGet("teams")]
        public ActionResult<Match> GetTeams()
        {
            try
            {
                return GetMatchOperationInstance().GetMatch();
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}