using Formacao.Dominio.Entidades;
using Formacao.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Infraestrutura.EntityConfigurations
{
    public class PessoaEntityConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa", "formacao")
                .AddIsDeletedFilter();

            builder.Property(p => p.Nome)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasMany(p => p.FormacaoPessoas)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(p => p.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
