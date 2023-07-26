using Formacao.Application.CasosDeUso.Formacao.Criar;
using Formacao.Application.Models;
using Formacao.Dominio.Entidades;
using Formacao.Infraestrutura.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Tests.IntegrationTests.Formacao.Criar
{
    public class CriarFormacaoIntegrationTest : BaseFixture, IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private readonly Dominio.Entidades.Formacao _formacao;
        private readonly DateTime _now;
        private readonly Guid _testGuid;
        private readonly WebApplicationFactory<Program> _factory;

        public CriarFormacaoIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
            _now = DateTime.UtcNow;
            _testGuid = Guid.NewGuid();
            _formacao = new Dominio.Entidades.Formacao($"[IntegrationTest].Formacao_{_testGuid}", "Descricao", _now);
        }

        [Fact]
        public async Task CriarFormacao_DeveRetornar_IdFormacao()
        {
            var criarFormacaoRequest = new CriarFormacao(_formacao.Nome, _formacao.Descricao, _now);
            var httpResponse = await _httpClient.PostAsync("api/v2/Formacao", GenerateStringContent(criarFormacaoRequest));
            var stringResultado = await httpResponse.Content.ReadAsStringAsync();

            httpResponse.EnsureSuccessStatusCode();
            var resultado = JsonConvert.DeserializeObject<CriarFormacaoResult>(stringResultado);
            Assert.NotNull(resultado);
            Assert.NotEqual(Guid.Empty, resultado.Id);
        }
    }
}
