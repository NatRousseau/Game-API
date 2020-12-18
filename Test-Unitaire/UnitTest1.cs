using System.Collections.Generic;
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
            
            // Assert.IsNotNull(Gc.Index());
        }

        [TestMethod]
        public void CreateTest()
        {
            GamesController Gc = new GamesController();
            var Game = new Game();
            var result = Gc.Create(Game);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }
    }
}