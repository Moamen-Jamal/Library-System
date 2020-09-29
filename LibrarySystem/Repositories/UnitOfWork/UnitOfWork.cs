using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork
    {
        private EntitiesContext context;
        public Generic<Book> BookRepo { get; set; }
        public Generic<User> UserRepo { get; set; }
        public Generic<UserBook> UserBookRepo { get; set; }

        ////////////////////////////////

        public UnitOfWork(
            EntitiesContext _context,
            Generic<Book> bookRepo,
            Generic<User> userRepo,
            Generic<UserBook> userBookRepo
            )
        {
            context = _context;
            UserRepo = userRepo;
            UserRepo.Context = context;

            BookRepo = bookRepo;
            BookRepo.Context = context;

            UserBookRepo = userBookRepo;
            UserBookRepo.Context = context;

        }

        public int commit()
        {
            return context.SaveChanges();
        }
    }
}
