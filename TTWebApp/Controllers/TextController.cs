using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTWebApp.DBLayer;
using TTWebApp.Models;

namespace TTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        IRepository<Text> textRepository;

        public TextController(IRepository<Text> repository)
        {
            textRepository = repository;
        }

        // GET: api/<PhotoController>
        [HttpGet(Name = "GetTexts")]
        public IEnumerable<Text> Get()
        {
            return textRepository.GetList();
        }

        // GET api/<PhotoController>/5
        [HttpGet("{id}", Name = "GetText")]
        public IActionResult Get(int id)
        {
            Text textItem = textRepository.Get(id);

            if (textItem == null)
            {
                return NotFound();
            }

            return new ObjectResult(textItem);
        }

        // POST api/<PhotoController>
        [HttpPost]
        public IActionResult Create([FromBody] Text text)
        {
            if (text == null)
            {
                return BadRequest();
            }
            textRepository.Create(text);
            return CreatedAtRoute("GetText", new { id = text.Id }, text);
        }

        // PUT api/<PhotoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Text updatedText)
        {
            if (updatedText == null)
            {
                return BadRequest();
            }

            var todoItem = textRepository.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            updatedText.Id = id;
            textRepository.Update(updatedText);
            return CreatedAtRoute("GetText", new { id = updatedText.Id }, updatedText);
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Text deletedItem = null;
            try
            {
                deletedItem = textRepository.Delete(id);
            }
            catch
            {
                return BadRequest();
            }
            if (deletedItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedItem);
        }
       
    }
}
