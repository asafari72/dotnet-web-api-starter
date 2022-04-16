using Microsoft.AspNetCore.Mvc;
using WebApiStarter.Models;
using WebApiStarter.Services;

namespace WebApiStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BookController(BooksService booksService) =>
       _booksService = booksService;


        [HttpGet]
        public async Task<List<Book>> Get() => await _booksService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(Book newBook)
        {
            await _booksService.CreateAsync(newBook);
            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }



    }
}
