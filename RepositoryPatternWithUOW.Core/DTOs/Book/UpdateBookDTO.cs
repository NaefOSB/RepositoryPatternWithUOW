namespace RepositoryPatternWithUOW.Core.DTOs.Book
{
    public class UpdateBookDTO
    {
        public int id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
    }
}
