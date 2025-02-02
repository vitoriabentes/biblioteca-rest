using Asp.Versioning;
using Biblioteca_REST_API.Business;
using Microsoft.AspNetCore.Mvc;
using Biblioteca_REST_API.Data.VO;
using Biblioteca_REST_API.Hypermedia.Filters;

namespace Biblioteca_REST_API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindAll()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindById(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person is null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] PersonVO person)
        {
            if (person is null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
        
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update([FromBody] PersonVO person)
        {
            if (person is null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
   
    }
}
