using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _booksRepository;

        public BooksController(IBaseRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet("GetBooks")]
        public ActionResult GetBooks()
        {
            return Ok(_booksRepository.GetAll());
        }

        [HttpGet]
        public ActionResult GetBookById(int id)
        {
            return Ok(_booksRepository.GetById(id));
        }

        [HttpGet("GetBookByTitle")]
        public ActionResult GetBookByTitle(string title)
        {
            return Ok(_booksRepository.Find(a => a.Title == title, ["Author"]));
        }

        [HttpGet("GetBooksByTitle")]
        public ActionResult GetBooksByTitle(string title, int skip, int take)
        {
            return Ok(_booksRepository.FindAll(a => a.Title.Contains(title), ["Author"], skip, take));
        }
    }
}
