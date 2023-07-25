using Formacao.Dominio.Enums;
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
    public class FormacaoEntityConfig : IEntityTypeConfiguration<Dominio.Entidades.Formacao>
    {
        public void Configure(EntityTypeBuilder<Dominio.Entidades.Formacao> builder)
        {

            builder.ToTable("Formacao", "formacao")
                .AddIsDeletedFilter();

            builder.Property(p => p.Nome)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Descricao)
               .HasMaxLength(500)
               .IsRequired();

            builder.Property(p => p.Status)
                .HasDefaultValue(FormacaoStatusEnum.Rascunho)
                .IsRequired();

            builder.HasMany(f => f.FormacaoPessoas)
                .WithOne(f => f.Formacao)
                .HasForeignKey(f => f.IdFormacao)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
