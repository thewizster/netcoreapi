using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webextant.Models;

namespace Webextant.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        public IPeopleRepository PeopleItems { get; set; }

        public PeopleController(IPeopleRepository peopleItems)
        {
            PeopleItems = peopleItems;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return PeopleItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetById(string id)
        {
            var item = PeopleItems.Find(id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBodyAttribute] Person item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            PeopleItems.Add(item);
            return CreatedAtRoute("GetPerson", new { id = item.Key }, item);
        }

        [HttpPutAttribute("{id}")]
        public IActionResult Update(string id, [FromBody] Person item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var person = PeopleItems.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            PeopleItems.Update(item);
            return new NoContentResult();
        }

        [HttpDeleteAttribute("{id}")]
        public void Delete(string id)
        {
            PeopleItems.Remove(id);
        }
    }
}