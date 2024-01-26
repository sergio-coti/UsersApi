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
    /// Classe de mapeamento ORM para a entidade 'User'
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //nome da tabela
            builder.ToTable("USER");

            //chave primária
            builder.HasKey(u => u.Id);

            //mapeamento dos campos
            builder.Property(u => u.Id)
                .HasColumnName("ID");

            builder.Property(u => u.Name)
                .HasColumnName("NAME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Password)
                .HasColumnName("PASSWORD")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.RoleId)
                .HasColumnName("ROLEID")
                .IsRequired();

            builder.Ignore(u => u.AccessToken);

            #region Relacionamentos

            builder.HasOne(u => u.Role) //Usuário TEM 1 Perfil
                .WithMany(r => r.Users) //Perfil TEM Muitos Usuários
                .HasForeignKey(u => u.RoleId); //Chave estrangeira

            #endregion
        }
    }
}
