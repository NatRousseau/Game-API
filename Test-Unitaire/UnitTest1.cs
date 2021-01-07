using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICD_API.Controller;
using CICD_API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Test_Unitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexTest()
        {
            GamesController Gc = new GamesController();
            IActionResult result = Gc.Index();
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void CreateTest()
        {
            GamesController Gc = new GamesController();
            object Game;
            Game = new Game{Id = 8, Name = "test", Genre = "test"};
            object result;
            result = Gc.Create(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
        
        [TestMethod]
        public void EditTest()
        {
            GamesController Gc = new GamesController();
            object Game;
            Game = new Game{Id = 8, Name = "test", Genre = "coucou"};
            object result;
            result = Gc.Edit(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
        
        [TestMethod]
        public void DeleteTest()
        {
            GamesController Gc = new GamesController();
            object Game;
            Game = new Game{Id = 8};
            object result;
            result = Gc.Delete(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
    }
}