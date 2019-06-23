using DAL.RepositoryContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepositoryClasses
{
    public class BookRepository : GenericRepository<Book>, BookIRepository
    {
        public BookRepository(BookContext bookContext) : base(bookContext) { }
    }
}
