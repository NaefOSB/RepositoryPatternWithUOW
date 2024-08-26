using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs.Book;
using RepositoryPatternWithUOW.Core.General.Constants;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetBooks")]
        public ActionResult GetBooks()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetBookById")]
        public ActionResult GetBookById(int id)
        {
            return Ok(_unitOfWork.Books.GetById(id));
        }

        [HttpGet("GetBookByIdWithRelationships")]
        public ActionResult GetBookByIdWithRelationships(int id)
        {
            return Ok(_unitOfWork.Books.Find(a => a.Id == id, ["Author"]));
        }

        [HttpGet("GetBookByTitle")]
        public ActionResult GetBookByTitle(string title)
        {
            return Ok(_unitOfWork.Books.Find(a => a.Title == title));
        }

        [HttpGet("GetBookByTitleWithRelationships")]
        public ActionResult GetBookByTitleWithRelationships(string title)
        {
            return Ok(_unitOfWork.Books.Find(a => a.Title == title, ["Author"]));
        }

        [HttpGet("GetBooksByTitle")]
        public ActionResult GetBooksByTitle(string title)
        {
            return Ok(_unitOfWork.Books.FindAll(a => a.Title.Contains(title)));
        }

        [HttpGet("GetBooksByTitleWithRelationships")]
        public ActionResult GetBooksByTitleWithRelationships(string title)
        {
            return Ok(_unitOfWork.Books.FindAll(a => a.Title.Contains(title), ["Author"]));
        }

        [HttpGet("GetBooksWithOrdering")]
        public IActionResult GetBooksWithOrdering(string searchText = "", string orderBy = OrderBy.Ascending)
        {
            if (orderBy != OrderBy.Ascending && orderBy != OrderBy.Descending)
                return BadRequest("The orderBy value not correct, must be one of the (ASC, DESC)");

            return Ok(_unitOfWork.Books.FindAll(a => a.Id.ToString().Contains(searchText) || a.Title.Contains(searchText), ["Author"], null, null, a => a.Id, orderBy));
        }

        [HttpGet("GetBooksSpecialMethod")]
        public IActionResult GetBooksSpecialMethod()
        {
            return Ok(_unitOfWork.Books.BookSpecialMethod());
        }

        [HttpPost("Add")]
        public ActionResult Add(AddBookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            _unitOfWork.Books.Add(book);
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpPost("AddRange")]
        public ActionResult AddRange(IEnumerable<AddBookDTO> booksDTO)
        {
            List<Book> books = _mapper.Map<List<Book>>(booksDTO);
            _unitOfWork.Books.AddRange(books);
            _unitOfWork.Complete();
            return Ok(books);
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateBookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            _unitOfWork.Books.Update(book);
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Books.Delete(id);
            return Ok(_unitOfWork.Complete());
        }
    }
}
