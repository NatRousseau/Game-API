using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection;
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
            
            
        public static void MakeDto(object src, object dst)
        {
            FieldInfo[] dtoFields = dst.GetType().GetFields();

            foreach (FieldInfo field in src.GetType().GetFields())
            {
                FieldInfo f = dtoFields.FirstOrDefault(i => i.Name.ToLower() == field.Name.ToLower());

                if (f != null)
                {
                    f.SetValue(dst, field.GetValue(src));
                }
            }
        }
        
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            Database.Games.RemoveRange(Database.Games.ToList());
            var igdb = new IGDBClient(
                "guzm7eym3d3ecodc2b66poy0r5k3tj",
                "h702ugu6054gv4kkyi5aqyadj1srpn"
            );
            Game[] json = igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name,summary; where category = 0 & status = 0; sort rating desc; limit 20;").Result;
            foreach (var game in json)
            {
                CICD_API.Models.Game dbgame = new CICD_API.Models.Game
                {
                    name = game.Name,
                    summary = game.Summary
                };
                Database.Games.Add(dbgame);
            }
            Database.SaveChanges();
            // var game = games.First();
           // string json =  System.IO.File.ReadAllText("data.json");
           // List<Game> games =  JsonConvert.DeserializeObject<List<Game>>(json);
           return (new JsonResult(json));
        }
        /*// POST
        [HttpPost]
        public IActionResult Create([FromBody]Game game)
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            games.Add(game);
            string jsonEdit = JsonConvert.SerializeObject(games, Formatting.Indented);
            System.IO.File.WriteAllText("data.json", jsonEdit);
            return Ok("Le jeu à bien été crée");
        }
        //Put
        [HttpPut]
        public IActionResult Edit([FromBody] Game game)
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            Game myGame = games.FirstOrDefault(G => G.Id == game.Id);
            myGame.Titre = game.Titre;
            myGame.Genre = game.Genre;
            string jsonEdit = JsonConvert.SerializeObject(games, Formatting.Indented);
            System.IO.File.WriteAllText("data.json", jsonEdit);
            return Ok("Le jeu à bien été modifié");
        }
        //DELETE
        [HttpDelete]
        public IActionResult Delete([FromBody] Game game)
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            Game myGame = games.FirstOrDefault(G => G.Id == game.Id);
            games.Remove(myGame);
            string jsonEdit = JsonConvert.SerializeObject(games, Formatting.Indented);
            System.IO.File.WriteAllText("data.json", jsonEdit);
            return Ok("Le jeu à été supprimé");
        }*/
    }
}