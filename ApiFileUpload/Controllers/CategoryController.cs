using ApiFileUpload.Dtos;
using ApiFileUpload.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromForm] CategoryDto categoryDto)
        {
            //ssv
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //transform dto to category
            MemoryStream stream = new MemoryStream();
            categoryDto.Image.CopyTo(stream);

            Category category = new Category
            {
                Name = categoryDto.Name,
                Image = stream.ToArray()
            };

            //add to db
            return Created("", category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
