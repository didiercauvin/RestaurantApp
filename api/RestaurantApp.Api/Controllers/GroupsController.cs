using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver.V1;
using RestaurantApp.Data.Neo4j;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private readonly IDriver _driver;
        private RestaurantAppData _data;

        public GroupsController(IDriver driver)
        {
            _driver = driver;
            _data = new RestaurantAppData(driver);
        }

        [HttpGet]
        public IEnumerable<AppGroup> Get()
        {
            return _data.Group.GetAll();
        }

        [HttpGet("{id}", Name = "GetGroup")]
        public IActionResult Get(Guid id)
        {
            var group = _data.Group.Get(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AppGroup group)
        {
            if (group == null)
            {
                return BadRequest();
            }

            group = _data.Group.Add(group);

            return CreatedAtRoute("GetGroup", new {id = group.Id}, group);
        }
    }

    

}