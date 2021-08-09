using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APILibary.Services;
using APILibary.Models;
using System.Threading.Tasks;

namespace APILibary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            this._bookService = bookService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<Book[]> Get()
        {
            try
            {
                return this._bookService.getBooks();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            try
            {
                await this._bookService.addBook(book);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] Book book)
        {
            try
            {
                await this._bookService.updateBook(book);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] int[] ids)
        {
            try
            {
                await this._bookService.deleteBook(ids);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

    }
}
