using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class UserExtensions
    {
        public static UserEditViewModel ToEditableViewModel(this User model)
        {
            return new UserEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
         
            };
        }
        public static User ToModel(this UserEditViewModel model)
        {
            return new User
            {
                ID = model.ID,
                Name = model.Name,
                

            };
        }
        public static UserViewModel ToViewModel(this User model)
        {
            return new UserViewModel
            {
                ID = model.ID,
                Name = model.Name,
           
            };
        }
        public static UserEditViewModel ToEditViewModel(this UserViewModel model)
        {
            return new UserEditViewModel
            {
                ID = model.ID,
                Name = model.Name,

            };
        }
    }
}
