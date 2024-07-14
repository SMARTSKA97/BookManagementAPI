using Microsoft.AspNetCore.Mvc;
using BookManagementAPI.Models;

namespace BookManagementAPI.Controllers
{
    [Route("api/[BookManagementAPI]")]
    [ApiController]
    public class BookManagementAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
                {
                    new Book { Id = 1,Title = "Macbeth", Author = "William Shakespeare", Year=1890, Genre = "Novel"},
                    new Book  { Id = 2, Title = "Happy Prince", Author = "Oscar Wilde", Year=1940, Genre="Story"},
                    new Book {Id = 3, Title = "Hound of Baskerville", Author = "Sir Arthur Conan Doyle", Year=1890, Genre="Mystery"}
                };
        }
    }
}