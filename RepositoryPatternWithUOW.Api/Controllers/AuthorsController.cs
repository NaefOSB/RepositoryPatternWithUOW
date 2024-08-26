using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.DTOs.Author;
using RepositoryPatternWithUOW.Core.General.Constants;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAuthors")]
        public ActionResult GetAuthors()
        {
            return Ok(_unitOfWork.Authors.GetAll());
        }

        [HttpGet("GetAuthorById")]
        public ActionResult GetAuthorById(int id)
        {
            return Ok(_unitOfWork.Authors.GetById(id));
        }

        [HttpGet("GetAuthorByName")]
        public ActionResult GetAuthorByName(string name)
        {
            return Ok(_unitOfWork.Authors.Find(a => a.Name == name));
        }

        [HttpGet("GetAuthorsByName")]
        public ActionResult GetAuthorsByName(string name)
        {
            return Ok(_unitOfWork.Authors.FindAll(a => a.Name.Contains(name)));
        }

        [HttpGet("GetAuthorsWithOrdering")]
        public IActionResult GetAuthorsWithOrdering(string searchText = "", string orderBy = OrderBy.Ascending)
        {
            if (orderBy != OrderBy.Ascending && orderBy != OrderBy.Descending)
                return BadRequest("The orderBy value not correct, must be one of the (ASC, DESC)");

            return Ok(_unitOfWork.Authors.FindAll(a => a.Id.ToString().Contains(searchText) || a.Name.Contains(searchText), null, null, null, a => a.Id, orderBy));
        }

        [HttpGet("GetAuthorSpecialMethod")]
        public IActionResult GetAuthorSpecialMethod()
        {
            return Ok(_unitOfWork.Authors.AuthorSpecialMethod());
        }

        [HttpPost("Add")]
        public ActionResult Add(AddAuthorDTO AuthorDTO)
        {
            Author author = _mapper.Map<Author>(AuthorDTO);
            _unitOfWork.Authors.Add(author);
            _unitOfWork.Complete();
            return Ok(author);
        }

        [HttpPost("AddRange")]
        public ActionResult AddRange(IEnumerable<AddAuthorDTO> AuthorsDTO)
        {
            List<Author> authors = _mapper.Map<List<Author>>(AuthorsDTO);
            _unitOfWork.Authors.AddRange(authors);
            _unitOfWork.Complete();
            return Ok(authors);
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateAuthorDTO AuthorDTO)
        {
            Author author = _mapper.Map<Author>(AuthorDTO);
            _unitOfWork.Authors.Update(author);
            _unitOfWork.Complete();
            return Ok(author);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Authors.Delete(id);
            return Ok(_unitOfWork.Complete());
        }
    }
}
