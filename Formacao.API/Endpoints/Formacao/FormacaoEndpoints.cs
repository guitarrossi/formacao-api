﻿using Formacao.API.Filters;
using Formacao.Application.CasosDeUso.Formacao.Criar;
using Formacao.Application.CasosDeUso.Formacao.Inciar;
using Formacao.Application.UseCases.Formacao.ListarFormacoes;
using Formacao.Dominio.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Formacao.API.Endpoints.Formacao
{
    public static class FormacaoEndpoints
    {
        public static void RegistrarEndpointsFormacao(this WebApplication app)
        {
            app.MapPost("/api/v2/Formacao", async (ISender _sender, [FromBody] CriarFormacao criarFormacao, CancellationToken ct) =>
            {
                var resultado = await _sender.Send(criarFormacao, ct);
                return RetornarOk(resultado);
            }
            ).WithOpenApi();

            app.MapGet("/api/v2/Formacao", async (ISender _sender, [FromQuery] string? nome, [FromQuery] FormacaoStatusEnum? status, [FromQuery] DateTime? dataInicio, [FromQuery] int? paginaAtual, [FromQuery] int? tamanhoPagina,  CancellationToken ct) =>
            {
                var resultado = await _sender.Send(new FiltrarFormacoes(nome, status, dataInicio, paginaAtual, tamanhoPagina), ct);
                return RetornarOk(resultado);
            }
            ).WithOpenApi();

            app.MapPut("api/v2/Formacao/{id}", async (ISender _sender, [FromRoute] Guid id) =>
            {
                var resultado = await _sender.Send(new IniciarFormacao(id));
                return RetornarAccepted("formacao/{id}", resultado);
            }).AddEndpointFilter<NotificationFilter>();


        }
    }
}
