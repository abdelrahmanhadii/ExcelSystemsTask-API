using AutoMapper;
using BL.Contracts;
using DAL;
using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services
{
    public class BookService:IBookService
    {
        IRepositoryWrapper RepoWrap;
        IMapper Mapper;
        public BookService(IRepositoryWrapper repoWrap, IMapper mapper)
        {
            RepoWrap = repoWrap;
            Mapper = mapper;
        }
        public int Create(CreateBookDTO newBook)
        {
            var x = AutoMapper.Mapper.Map<Book>(newBook);
            RepoWrap.BookRepo.Create(x);
            return RepoWrap.Save();
        }
        public int Update(CreateBookDTO newBook)
        {
            RepoWrap.BookRepo.Update(Mapper.Map<CreateBookDTO, Book>(newBook));
            return RepoWrap.Save();
        }
        public int Delete(int id)
        {
            RepoWrap.BookRepo.Delete(id);
            return RepoWrap.Save();
        }
        public IEnumerable<Book> ReadAll ()
        {
            return RepoWrap.BookRepo.ReadAll();
        }
    }
}
