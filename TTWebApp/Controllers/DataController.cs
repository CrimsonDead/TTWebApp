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
    public class DataController : ControllerBase
    {
        IRepository<Author> authorRepository;
        IRepository<Photo> photoRepository;
        IRepository<Text> textRepository;

        public DataController(IRepository<Author> aRepository, IRepository<Photo> pRepository, IRepository<Text> tRepository)
        {
            authorRepository = aRepository;
            photoRepository = pRepository;
            textRepository = tRepository;
        }

        [HttpGet(Name = "GetAllItems")]
        public IEnumerable<object> Get()
        {
            List<object> items = new List<object>();
            items.AddRange(authorRepository.GetList());
            items.AddRange(photoRepository.GetList());
            items.AddRange(textRepository.GetList());
            return authorRepository.GetList();
        }
    }
}
