using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserBookConfiguration : EntityTypeConfiguration<UserBook>
    {
        public UserBookConfiguration()
        {
            ToTable("UserBook");
            Property(i => i.BookID).IsRequired();
            Property(i => i.UserID).IsRequired();
            Property(i => i.NumberOfBorrowings).IsRequired();
            HasRequired(i => i.User).WithMany(i => i.UserBooks).
                HasForeignKey(i => i.UserID);
            HasRequired(i => i.Book).WithMany(i => i.UserBooks).
                HasForeignKey(i => i.BookID);
        }
    }
}
