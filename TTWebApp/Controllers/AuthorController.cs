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
    public class AuthorController : ControllerBase
    {
        IRepository<Author> authorRepository;

        public AuthorController(IRepository<Author> repository)
        {
            authorRepository = repository;
        }

        // GET: api/<PhotoController>
        [HttpGet(Name = "GetAuthors")]
        public IEnumerable<Author> Get()
        {
            return authorRepository.GetList();
        }

        // GET api/<PhotoController>/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            Author authorItem = authorRepository.Get(id);

            if (authorItem == null)
            {
                return NotFound();
            }

            return new ObjectResult(authorItem);
        }

        // POST api/<PhotoController>
        [HttpPost]
        public IActionResult Create([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            authorRepository.Create(author);
            return CreatedAtRoute("GetAuthor", new { id = author.Id }, author);
        }

        // PUT api/<PhotoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Author updatedAuthor)
        {
            if (updatedAuthor == null)
            {
                return BadRequest();
            }

            var todoItem = authorRepository.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            updatedAuthor.Id = id;
            authorRepository.Update(updatedAuthor);
            return CreatedAtRoute("GetAuthor", new { id = updatedAuthor.Id }, updatedAuthor);
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Author deletedItem = null;
            try
            {
                deletedItem = authorRepository.Delete(id);
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
