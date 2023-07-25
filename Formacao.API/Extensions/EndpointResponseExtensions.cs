using Formacao.Application.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Formacao.API.Extensions
{
    public static class EndpointResponseExtensions
    {
        public static IResult RetornarOk(Response response)
        {
            if (!response.Sucesso)
                return Results.BadRequest(new { Erros = response.Erros });

            if (response.Result is null)
                return Results.NoContent();

            return Results.Ok(new
            {
                response.Result
            });
        }


        public static IResult RetornarAccepted(string route, Response response)
        {
            if (!response.Sucesso)
                return Results.BadRequest(new { Erros = response.Erros});

            if (response.Result is null)
                return Results.NoContent();

            return Results.Accepted(route, new
            {
                response.Result
            });
        }

        public static IResult RetornarCreated(string route, Response response)
        {
            if (!response.Sucesso)
                return Results.BadRequest(new { Erros = response.Erros });

            if (response.Result is null)
                return Results.NoContent();

            return Results.Created(route, new
            {
                response.Result
            });
        }

    }
}
