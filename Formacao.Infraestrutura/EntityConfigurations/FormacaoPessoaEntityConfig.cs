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
    public class FormacaoPessoaEntityConfig : IEntityTypeConfiguration<FormacaoPessoa>
    {
        public void Configure(EntityTypeBuilder<FormacaoPessoa> builder)
        {
            builder.ToTable("FormacaoPessoa", "formacao")
              .AddIsDeletedFilter();

            builder.HasOne(p => p.Formacao)
                .WithMany(p => p.FormacaoPessoas)
                .HasForeignKey(p => p.IdFormacao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.IdFormacao);
                
        }
    }
}
