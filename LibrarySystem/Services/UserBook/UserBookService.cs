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
    public class UserBookService
    {
            UnitOfWork unitOfWork;
            Generic<UserBook> UserBookRepo;
            public UserBookService(UnitOfWork _unitOfWork)
            {
                unitOfWork = _unitOfWork;
                UserBookRepo = unitOfWork.UserBookRepo;
            }

            public UserBookEditViewModel Add(UserBookEditViewModel UserBook)
            {
                UserBook _UserBook = UserBookRepo.Add(UserBook.ToModel());
                unitOfWork.commit();
                return _UserBook.ToEditableViewModel();
            }
            public UserBookEditViewModel Update(UserBookEditViewModel UserBook)
            {
                UserBook _UserBook = UserBookRepo.Update(UserBook.ToModel());
                unitOfWork.commit();
                return _UserBook.ToEditableViewModel();
            }
            public void Remove(int id)
            {
                UserBookRepo.Remove(new UserBook { ID = id });
                unitOfWork.commit();
            }

            public UserBookViewModel GetByID(int id)
            {
                return UserBookRepo.GetByID(id).ToViewModel();
            }
            public IEnumerable<UserBookViewModel> GetAll()
            {
                var query =
                    UserBookRepo.GetAll();
                return query.ToList().Select(i => i.ToViewModel());
            }
            public IEnumerable<UserBookViewModel> Get(int id)
            {
                return UserBookRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
            }
        }
}
