using DAL.RepositoryClasses;
using DAL.RepositoryContracts;

namespace DAL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BookContext BookContext;
        private BookIRepository BookIRepository;
        private UserIRepository UserIRepository;
        public RepositoryWrapper(BookContext bookContext)
        {
            BookContext = bookContext;
        }
        public BookIRepository BookRepo
        {
            get
            {
                if (BookIRepository == null)
                {
                    BookIRepository = new BookRepository(BookContext);
                }

                return BookIRepository;
            }
        }
        public UserIRepository UserRepo
        {
            get
            {
                if (UserIRepository == null)
                {
                    UserIRepository = new UserRepository(BookContext);
                }

                return UserIRepository;
            }
        }
        public int Save()
        {
            return BookContext.SaveChanges();
        }
    }
}
