using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorsRepository;

        public AuthorsController(IBaseRepository<Author> authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_authorsRepository.GetAll());
        }

        [HttpGet]
        public ActionResult GetAuthorById(int id)
        {
            return Ok(_authorsRepository.GetById(id));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _authorsRepository.GetByIdAsync(id));
        }

        [HttpGet("GetByName")]
        public IActionResult GetAuthorByName(string name)
        {
            return Ok(_authorsRepository.Find(a => a.Name.Contains(name)));
        }

        [HttpGet("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            return Ok(_authorsRepository.FindAll(a => a.Name.Contains(name)));
        }
    }
}
