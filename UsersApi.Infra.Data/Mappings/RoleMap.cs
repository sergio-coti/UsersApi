using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Domain.Models;

namespace UsersApi.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade 'Role'
    /// </summary>
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //nome da tabela
            builder.ToTable("ROLES");

            //chave primária
            builder.HasKey(r => r.Id);

            //mapeamento dos campos
            builder.Property(r => r.Id)
                .HasColumnName("ID");

            builder.Property(r => r.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}
