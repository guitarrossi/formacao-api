using Formacao.Application.CasosDeUso.Formacao.Criar;
using Formacao.Application.Modelos;
using Formacao.Application.UseCases.Formacao.Filtrar;
using Formacao.Application.UseCases.Formacao.ListarFormacoes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Tests.IntegrationTests.Formacao.Filtrar
{
    public class FiltrarFormacaoIntegrationTest : BaseFixture, IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _factory;

        public FiltrarFormacaoIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task FiltrarFormacoes_Deve_RetornarResultadoPaginado()
        {
            var queryString = new StringBuilder();
            queryString.Append("nome=&");

            var httpResponse = await _httpClient.GetAsync($"/api/v2/Formacao?{queryString}");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            var resultado = JsonConvert.DeserializeObject<ResultadoPaginado<FiltrarFormacoesResult>>(stringResponse);
            Assert.NotNull(resultado);
        }
    }
}
