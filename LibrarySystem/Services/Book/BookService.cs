using Entities.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class BookService
    {
        UnitOfWork unitOfWork;
        Generic<Book> BookRepo;
        Generic<UserBook> UserBookRepo;
        public BookService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            BookRepo = unitOfWork.BookRepo;
            UserBookRepo = unitOfWork.UserBookRepo;
        }
        public BookEditViewModel Add(BookEditViewModel BookEditViewModel)
        {
            Book Book = BookRepo.Add(BookEditViewModel.ToModel());
            unitOfWork.commit();
            return Book.ToEditableViewModel();
        }
        public BookEditViewModel Update(BookEditViewModel BookEditViewModel)
        {
            Book Book = BookRepo.Update(BookEditViewModel.ToModel());
            foreach (var u in BookEditViewModel.UserBook)
            {
                UserBookRepo.Update(u.ToModel());

            }
            unitOfWork.commit();
            return Book.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            UserBook UserBook = UserBookRepo.GetAll().Where(i => i.BookID == id).FirstOrDefault();
            if(UserBook != null) {
                UserBookRepo.Remove(new UserBook { ID = UserBook.ID });
            }
            BookRepo.Remove(new Book { ID = id });
            unitOfWork.commit();
        }
        public IEnumerable<BookViewModel> Get(int id)
        {
            return BookRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<BookViewModel> GetAll()
        {
            return BookRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public BookViewModel GetByID(int id)
        {
            return BookRepo.GetByID(id).ToViewModel(); ;
        }
        public BookEditViewModel GetDeleteByID(int id)
        {
            return BookRepo.GetByID(id).ToEditableViewModel();
        }
    }
}
