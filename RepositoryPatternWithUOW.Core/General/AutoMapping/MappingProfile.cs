using AutoMapper;
using RepositoryPatternWithUOW.Core.DTOs.Author;
using RepositoryPatternWithUOW.Core.DTOs.Book;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Core.General.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Author Mapper

            CreateMap<AddAuthorDTO, Author>();
            CreateMap<UpdateAuthorDTO, Author>();
            #endregion

            #region Book Mapper

            CreateMap<AddBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();
            #endregion
        }
    }
}
