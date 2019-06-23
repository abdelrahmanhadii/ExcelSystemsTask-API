using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Contracts
{
    public interface IBookService
    {
        int Create(CreateBookDTO newBook);
        int Update(CreateBookDTO newBook);
        int Delete(int id);        
        IEnumerable<Book> ReadAll();
    }
}
