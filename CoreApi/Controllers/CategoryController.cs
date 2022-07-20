using CoreApi.DAL.Concrete;
using CoreApi.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        public IActionResult List()
        {
            using var c = new Context();

            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var c = new Context();

            var value = c.Categories.Find(id);
            if (value == null)
                return NotFound();
            else
                return Ok(value);
        }

        [HttpPost]
        public IActionResult Add(Category p)
        {
            using var c = new Context();

            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using var c = new Context();

            var value = c.Categories.Find(id);
            if (value == null)
                return NotFound();
            else
            {
                c.Remove(value);
                c.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Update(Category p)
        {
            using var c = new Context();

            var value = c.Find<Category>(p.Id);
            if (value == null)
                return NotFound();
            else
            {
                value.Name = p.Name;
                c.Update(value);
                c.SaveChanges();

                return Ok();
            }
        }
    }
}
