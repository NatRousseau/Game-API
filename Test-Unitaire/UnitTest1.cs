using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICD_API.Controller;
using CICD_API;
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

            var result = Gc.Index();
            
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void CreateTest()
        {
            GamesController Gc = new GamesController();
            var Game = new Game{Id = 8, Name = "test", Genre = "test"};
            var result = Gc.Create(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
        
        [TestMethod]
        public void EditTest()
        {
            GamesController Gc = new GamesController();
            var Game = new Game{Id = 8, Name = "test", Genre = "coucou"};
            var result = Gc.Edit(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
        
        [TestMethod]
        public void DeleteTest()
        {
            GamesController Gc = new GamesController();
            var Game = new Game{Id = 8};
            var result = Gc.Delete(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
    }
}