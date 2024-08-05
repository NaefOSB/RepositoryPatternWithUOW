using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        [ForeignKey("Author")] public int AuthorId { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }

        public Author Author { get; set; }
    }
}
