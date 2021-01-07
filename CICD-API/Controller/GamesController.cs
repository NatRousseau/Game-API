using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CICD_API.Models;
using IGDB;
using Game = IGDB.Models.Game;

namespace CICD_API.Controller
{
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        public GamesController(Micro_API_DBContext DbContext)
        {
            Database = DbContext;
        }

        private Micro_API_DBContext Database;
        
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            Database.Games.RemoveRange(Database.Games.ToList());
            IGDBClient igdb = new IGDBClient(
                "guzm7eym3d3ecodc2b66poy0r5k3tj",
                "h702ugu6054gv4kkyi5aqyadj1srpn"
            );
            Game[] json = igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name,summary; where category = 0 & status = 0; sort rating desc; limit 20;").Result;
            foreach (Game game in json)
            {
                CICD_API.Models.Game dbgame = new CICD_API.Models.Game
                {
                    GameName = game.Name,
                    GameSummary = game.Summary
                };
                Database.Games.Add(dbgame);
            }
            Database.SaveChanges();
            return (new JsonResult(json));
        }
    }
}