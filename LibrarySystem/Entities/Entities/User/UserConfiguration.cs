using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            Property(i => i.Name).HasMaxLength(100).IsRequired();
            HasMany(i => i.UserBooks).WithRequired(i => i.User);
        }
    }
}
