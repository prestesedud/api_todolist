using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api_todolist.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_todolist.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                   .IsRequired(true)
                   .HasMaxLength(70);

            builder.Property(u => u.Email)
                 .IsRequired(true);

            builder.Property(u => u.Password)
                .IsRequired(true);

            builder.Property(u => u.Status)
                   .HasConversion<int>()
                   .HasComment("0 =  Intivo,  1 = Ativo");
        }
    }
}
