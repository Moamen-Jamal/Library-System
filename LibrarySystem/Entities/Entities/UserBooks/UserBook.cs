using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserBook : BaseModel
    {
        public virtual Book Book { get; set; }
        public int BookID { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
        public int NumberOfBorrowings { get; set; }
    }
}
