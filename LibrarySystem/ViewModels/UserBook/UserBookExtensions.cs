using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class UserBookExtensions
    {
        public static UserBookEditViewModel ToEditableViewModel(this UserBook model)
        {
            return new UserBookEditViewModel
            {
                ID = model.ID,
                BookID = model.BookID,
                UserID = model.UserID,
               NumberOfBorrowings = model.NumberOfBorrowings,
              
            };
        }
        public static UserBook ToModel(this UserBookEditViewModel model)
        {
            return new UserBook
            {
                ID = model.ID,

                BookID = model.BookID,
                UserID = model.UserID,
                NumberOfBorrowings = model.NumberOfBorrowings,
               
               

            };
        }
        public static UserBookViewModel ToViewModel(this UserBook model)
        {
            return new UserBookViewModel
            {
                ID = model.ID,
                BookID = model.Book.ID,
                UserID = model.User.ID,
                NumberOfBorrowings = model.NumberOfBorrowings,
                BookName = model.Book.Title,
                NumberOfCopies = model.Book.NumberOfCopies
            };
        }
        public static UserBookEditViewModel ToEditViewModel(this UserBookViewModel model)
        {
            return new UserBookEditViewModel
            {
                ID = model.ID,
                BookID = model.BookID,
                UserID = model.UserID,
                NumberOfBorrowings = model.NumberOfBorrowings,
                BookName = model.BookName,
                NumberOfCopies = model.NumberOfCopies

            };
        }
    }
}
