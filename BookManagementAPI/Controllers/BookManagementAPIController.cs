using Microsoft.AspNetCore.Mvc;
using BookManagementAPI.Models;
using BookManagementAPI.Models.Dto;
using BookManagementAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;

namespace BookManagementAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/BookManagementAPI")]
    [ApiController]
    public class BookManagementAPIController : ControllerBase
    {
        //GET ALL
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return Ok(BookStore.BookList);
        }

        //GET Certain Data using ID
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

        //Creating A New Data
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookDTO> CreateBook([FromBody]BookDTO bookDTO)
        {
            if(BookStore.BookList.FirstOrDefault(u => u.Title.ToLower() == bookDTO.Title.ToLower())!=null)
            {
                ModelState.AddModelError("Error","Same book Exists");
                return BadRequest(ModelState);
            }
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

        //Removal of Data using ID
        [HttpDelete("{id:int}", Name ="DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if( id == 0)
            {
                return BadRequest();
            }
            var book = BookStore.BookList.FirstOrDefault(u => u.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            BookStore.BookList.Remove(book);
            return NoContent();
        }

        //Update Whole Data
        [HttpPut("{id:int}", Name ="Update Book")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutBook(int id,[FromBody] BookDTO bookDTO)
        {
            if(bookDTO == null || id!=bookDTO.Id)
            {
                return BadRequest();
            } 
            var book = BookStore.BookList.FirstOrDefault(u => u.Id == id);
            book.Title = bookDTO.Title;
            book.Author = bookDTO.Author;
            book.Year = bookDTO.Year;
            book.Genre = bookDTO.Genre;
            return NoContent();
        }

        //Update Certain Data using JSON Patch
        [HttpPatch("{id:int}", Name = "Update Partial Book")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialBook(int id, JsonPatchDocument<BookDTO>patchDTO)
        {
            if(patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var book = BookStore.BookList.FirstOrDefault(u => u.Id==id );
            if(book == null)
            {
                return NotFound();
            }
            patchDTO.ApplyTo(book, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   
            return NoContent();
        }
    }
}