using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTWebApp.DBLayer;
using TTWebApp.Models;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        IRepository<Photo> photoRepository;

        public PhotoController(IRepository<Photo> repository)
        {
            photoRepository = repository;
        }

        // GET: api/<PhotoController>
        [HttpGet(Name = "GetItems")]
        public IEnumerable<Photo> Get()
        {
            return photoRepository.GetList();
        }

        // GET api/<PhotoController>/5
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult Get(int id)
        {
            Photo photoItem = photoRepository.Get(id);

            if (photoItem == null)
            {
                return NotFound();
            }

            return new ObjectResult(photoItem);
        }

        // POST api/<PhotoController>
        [HttpPost]
        public IActionResult Create([FromBody] Photo photo)
        {
            if (photo == null)
            {
                return BadRequest();
            }
            photoRepository.Create(photo);
            return CreatedAtRoute("GetItem", new { id = photo.Id }, photo);
        }

        // PUT api/<PhotoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Photo updatedPhoto)
        {
            if (updatedPhoto == null || updatedPhoto.Id != id)
            {
                return BadRequest();
            }

            var todoItem = photoRepository.Get(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            photoRepository.Update(updatedPhoto);
            return RedirectToRoute("GetAllItems");
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedItem = photoRepository.Delete(id);

            if (deletedItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedItem);
        }
    }
}
