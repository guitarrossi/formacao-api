using Formacao.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Application.UseCases.Formacao.Filtrar
{
    public record FiltrarFormacoesResult
    {
        public Guid IdFormacao { get; set; }
        public string Nome  { get; set; }
        public string Descricao { get; set; }
        public FormacaoStatusEnum Status { get; set; }
        public DateTime? DataInicio { get; set; }
    }
}
