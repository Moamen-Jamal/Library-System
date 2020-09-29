using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserBookViewModel
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int UserID { get; set; }
        public int NumberOfBorrowings { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
