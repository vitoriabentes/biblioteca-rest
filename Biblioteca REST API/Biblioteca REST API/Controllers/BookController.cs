using Asp.Versioning;
using Biblioteca_REST_API.Business;
using Biblioteca_REST_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_REST_API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult FindAll() 
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book is null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book is null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            if (book is null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }

    }
}
