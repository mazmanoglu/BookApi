using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using BookApi.Data;
using Microsoft.AspNetCore.Http;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorservices;
        public AuthorController(AuthorService authorservices)
        {
            _authorservices = authorservices;
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var allBooks = _authorservices.GetAllAuthors();
            return Ok(allBooks);
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorservices.AddAuthor(author);
            return Ok(author);
        }

        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var book = _authorservices.GetAuthorById(id);
            return Ok(book);
        }

        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorservices.DeleteAuthorById(id);
            return Ok();
        }

        [HttpPut("update-author-by-id/{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorVM author)
        {
            var updatedAuthor = _authorservices.UpdateAuthorById(id, author);
            return Ok(updatedAuthor);
        }
    }
}
