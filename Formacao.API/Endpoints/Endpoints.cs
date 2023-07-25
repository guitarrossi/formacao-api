using Formacao.API.Endpoints.Formacao;

namespace Formacao.API.Endpoints
{
    public static class Endpoints
    {
        public static void MapearEndpoints(WebApplication app)
        {
            app.RegistrarEndpointsFormacao();
        }
    }
}
