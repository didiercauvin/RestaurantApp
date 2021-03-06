using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver.V1;
using RestaurantApp.Data;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private readonly RestaurantAppData _data;

        public GroupsController(RestaurantAppData data)
        {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<Group> Get()
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
        public IActionResult Post([FromBody] Group group)
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