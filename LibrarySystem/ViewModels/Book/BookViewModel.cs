using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int NumberOfCopies { get; set; }
        public IList<UserBookEditViewModel> UserBook { get; set; }
    }
}
