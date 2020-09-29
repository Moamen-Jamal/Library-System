using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class BookExtensions
    {
        public static BookEditViewModel ToEditableViewModel(this Book model)
        {
            return new BookEditViewModel
            {
                ID = model.ID,
                Title = model.Title,
                NumberOfCopies = model.NumberOfCopies
            };
        }
        public static Book ToModel(this BookEditViewModel model)
        {
            return new Book
            {
                ID = model.ID,
                Title = model.Title,
                NumberOfCopies = model.NumberOfCopies

            };
        }
        public static BookViewModel ToViewModel(this Book model)
        {
            return new BookViewModel
            {
                ID = model.ID,
                Title = model.Title,
                NumberOfCopies = model.NumberOfCopies
            };
        }
        public static BookEditViewModel ToEditViewModel(this BookViewModel model)
        {
            return new BookEditViewModel
            {
                ID = model.ID,
                Title = model.Title,
                NumberOfCopies = model.NumberOfCopies
            };
        }
    }
}
