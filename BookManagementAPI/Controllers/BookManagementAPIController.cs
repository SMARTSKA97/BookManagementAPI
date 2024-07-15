using Microsoft.AspNetCore.Mvc;
using BookManagementAPI.Models;
using BookManagementAPI.Models.Dto;
using BookManagementAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookManagementAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/BookManagementAPI")]
    [ApiController]
    public class BookManagementAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return Ok(BookStore.BookList);
        }

        [HttpGet("{Id:int}", Name ="GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(200, Type = typeof(BookDTO))]
        public ActionResult<BookDTO> GetBook(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }

            var book = BookStore.BookList.FirstOrDefault(u => u.Id == Id);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookDTO> CreateBook([FromBody]BookDTO bookDTO)
        {
            if(bookDTO == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            if(bookDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            bookDTO.Id = BookStore.BookList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            BookStore.BookList.Add(bookDTO);
            return CreatedAtRoute("GetBook", new { Id = bookDTO.Id }, bookDTO); 
        }
    }
}