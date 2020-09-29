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
    public class UserService
    {
        UnitOfWork unitOfWork;
        Generic<User> UserRepo;
        Generic<UserBook> UserBookRepo;
        public UserService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepo = unitOfWork.UserRepo;
            UserBookRepo = unitOfWork.UserBookRepo;
        }
        public UserEditViewModel Add(UserEditViewModel UserEditViewModel)
        {
            User User = UserRepo.Add(UserEditViewModel.ToModel());
            unitOfWork.commit();
            return User.ToEditableViewModel();
        }
        public UserEditViewModel Update(UserEditViewModel UserEditViewModel)
        {
            User User = UserRepo.Update(UserEditViewModel.ToModel());
            foreach (var u in UserEditViewModel.UserBook)
            {
                UserBookRepo.Update(u.ToModel());

            }
            unitOfWork.commit();
            return User.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            UserBook userBook = UserBookRepo.GetAll().Where(i => i.UserID == id).FirstOrDefault();
            UserBookRepo.Remove(new UserBook { ID = userBook.ID });
            UserRepo.Remove(new User { ID = id });
            unitOfWork.commit();
        }
        public IEnumerable<UserViewModel> Get(int id)
        {
            return UserRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> GetAll()
        {
            return UserRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public UserViewModel GetByID(int id)
        {
            return UserRepo.GetByID(id).ToViewModel(); ;
        }
        public UserEditViewModel GetDeleteByID(int id)
        {
            return UserRepo.GetByID(id).ToEditableViewModel();
        }
    }
}
