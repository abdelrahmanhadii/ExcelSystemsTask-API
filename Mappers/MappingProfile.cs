using AutoMapper;
using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, CreateBookDTO>();
            CreateMap<CreateBookDTO, Book>();
        }
    }
}
