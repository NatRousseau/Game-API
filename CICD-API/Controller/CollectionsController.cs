using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CICD_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CICD_API.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    public class CollectionsController : Microsoft.AspNetCore.Mvc.Controller
    {
        public CollectionsController(Micro_API_DBContext DbContext)
        {
            Database = DbContext;
        }

        private Micro_API_DBContext Database;
        
        // GET
        [HttpGet]
        public async Task<List<Models.Collection>> Index()
        {
            return await Database.Collections.ToListAsync();
        }
        
        // POST
        [HttpPost]
        public async Task<List<Models.Collection>> Create([FromBody] Collection collectionData)
        {
            // CICD_API.Models.Collection dbCollection = new CICD_API.Models.Collection
            // {
            //     CollectionName = Name,
            //     IdUser = User
            // };
            Database.Collections.Add(collectionData);
            Database.SaveChanges();
            return await Database.Collections.ToListAsync();
        }
        //Put
        [HttpPut]
        public async Task<List<Models.Collection>> Edit([FromBody] Collection collectionData)
        {
            Database.Collections.Update(collectionData);
            Database.SaveChanges();
            return await Database.Collections.ToListAsync();
        }
        //DELETE
        [HttpDelete]
        public async Task<List<Models.Collection>> Delete([FromBody] Collection collectionData)
        {
            Database.Collections.Remove(collectionData);
            Database.SaveChanges();
            return await Database.Collections.ToListAsync();
        }
    }
}