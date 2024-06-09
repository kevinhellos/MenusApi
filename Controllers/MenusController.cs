//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MenusApi.Controllers
{
    [Route("api/Menus")]
    public class MenusController : Controller
    {

        List<Menu> myMenus = new List<Menu>
            {
                new Menu { Id = 1, Name = "Hot dog", Price = 3.99, Category = "Fast Food" },
                new Menu { Id = 2, Name = "Doughnut", Price = 2.50, Category = "Dessert" },
                new Menu { Id = 3, Name = "Mushroom soup", Price = 20.99, Category = "Soup" }
        };

        // GET: api/Menus
        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return myMenus;
        }

        // GET api/Menus/{id}
        [HttpGet("{id}")]
        public ActionResult<Menu> Get(int id)
        {
            var menu = myMenus.FirstOrDefault(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            return menu;
        }

        // POST api/Menus
        public ActionResult<Menu> Post([FromBody] Menu menu)
        {
            if (menu == null)
            {
                return BadRequest();
            }
            var newId = myMenus.Any() ? myMenus.Max(m => m.Id) + 1 : 1;
            menu.Id = newId;
            myMenus.Add(menu);
            return CreatedAtAction(nameof(Get), new { id = menu.Id }, menu);
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
    }
}

