using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public int NumberOfCopies { get; set; }
        public virtual ICollection<UserBook> UserBooks { get; set; }

    }
}
