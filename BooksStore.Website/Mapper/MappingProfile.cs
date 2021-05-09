using AutoMapper;
using BooksStore.Website.Data.Entity;
using BooksStore.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Website.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Liked, src => src.MapFrom(src => src.FavoriteBooks.Any()))
                .ReverseMap();
        }
    }
}
