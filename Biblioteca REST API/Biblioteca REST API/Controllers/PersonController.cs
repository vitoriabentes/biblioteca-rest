using Biblioteca_REST_API.Models;
using Biblioteca_REST_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_REST_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            var person = _personService.FindById(id);
            if (person is null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person is null) return BadRequest();
            return Ok(_personService.Update(person));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
   
    }
}
