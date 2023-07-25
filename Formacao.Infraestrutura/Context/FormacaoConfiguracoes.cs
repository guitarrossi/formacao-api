using Formacao.Dominio.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Infraestrutura.Context
{
    internal static class FormacaoConfiguracoes
    {
        internal static EntityTypeBuilder AddIsDeletedFilter<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : EntidadeHistorico
        {
            entityTypeBuilder.HasQueryFilter(c => EF.Property<DateTime?>(c, "ExcluidoEm") == null);
            return entityTypeBuilder;
        }
    }
}
