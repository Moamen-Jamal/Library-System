using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            ToTable("Book");
            Property(i => i.Title).HasMaxLength(100).IsRequired();
            Property(i => i.NumberOfCopies).IsRequired();
            HasMany(i => i.UserBooks).WithRequired(i => i.Book);
        }
    }
}
