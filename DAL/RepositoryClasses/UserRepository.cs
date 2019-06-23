using DAL.RepositoryContracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepositoryClasses
{
    public class UserRepository: GenericRepository<User>, UserIRepository
    {
        public UserRepository(BookContext db) : base(db) { }
    }
}
