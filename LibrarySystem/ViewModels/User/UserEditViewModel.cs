﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Name must be less than 25 character")]
        public string Name { get; set; }

        public IList<UserBookEditViewModel> UserBook { get; set; }
    }
}
