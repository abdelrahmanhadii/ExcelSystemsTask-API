using DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRepositoryWrapper
    {
        BookIRepository BookRepo { get; }
        UserIRepository UserRepo { get; }
        int Save();
    }
}
