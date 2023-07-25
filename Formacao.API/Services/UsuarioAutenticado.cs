using Formacao.Application.Interfaces.Services;
using System.Security.Claims;

namespace Formacao.API.Services
{
    public class UsuarioAutenticado : IUsuarioAutenticado
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioAutenticado(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
