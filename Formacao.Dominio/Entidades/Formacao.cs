using Formacao.Dominio.Entidades.Base;
using Formacao.Dominio.Enums;
using Formacao.Dominio.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Dominio.Entidades
{
    public class Formacao : EntidadeHistorico
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public FormacaoStatusEnum Status { get; private set; }

        protected Formacao()
        {
        }

        public Formacao(string nome, string descricao, DateTime? dataInicio) 
        {
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
        }

        public void IniciarFormacao()
        {
            DataInicio = DateTime.Now;
            Status = FormacaoStatusEnum.EmAndamento;
            AddDomainEvent(new FormacaoIniciadaEvent(Id));
        }

        public bool EstaEmAndamento()
        {
            return Status == FormacaoStatusEnum.EmAndamento;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public IEnumerable<FormacaoPessoa> FormacaoPessoas { get; private set; }

       
    }
}
