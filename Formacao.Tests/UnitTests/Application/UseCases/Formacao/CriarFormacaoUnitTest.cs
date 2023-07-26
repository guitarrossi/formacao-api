using Formacao.Application.CasosDeUso.Formacao.Criar;
using Formacao.Application.Interfaces.Repositories;
using Formacao.Application.Models;
using Formacao.Dominio.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Tests.UnitTests.Application.CasosDeUso.Formacao
{
    public class CriarFormacaoUnitTest
    {
        private readonly Mock<IFormacaoRepository> _formacaoRepositoryMock;

        public CriarFormacaoUnitTest()
        {
            _formacaoRepositoryMock = new Mock<IFormacaoRepository>();
        }
        [Fact]
        public async Task CriarFormacao_Deve_RetornarResponseSucesso()
        {
            var criarFormacao = new CriarFormacao("Formacao1", "Descricao1", DateTime.Now);
            _formacaoRepositoryMock.Setup(x => x.Inserir(It.IsAny<Dominio.Entidades.Formacao>())).Returns(Task.CompletedTask);
            var criarFormacaoHandler = new CriarFormacaoHandler(_formacaoRepositoryMock.Object);

            var resultado = await criarFormacaoHandler.Handle(criarFormacao, new CancellationToken());

            _formacaoRepositoryMock.Verify(x => x.Inserir(It.IsAny<Dominio.Entidades.Formacao>()), Times.Once);
            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<Response>(resultado);
        }
    }
}
