using AutoMapper;
using BookstoreApplication.Domain;
using BookstoreApplication.DTOs.Request;
using BookstoreApplication.DTOs.Response;

namespace BookstoreApplication.Settings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.YearsAfterPublished, opt => opt.MapFrom(src => DateTime.UtcNow.Year - src.PublishedDate.Year));

            CreateMap<Book, BookDetailsDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember (dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name));

            CreateMap<RegistrationDto, ApplicationUser>();
        }
    }
}
