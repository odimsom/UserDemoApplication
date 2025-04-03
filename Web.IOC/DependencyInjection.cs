using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory; // Para AddMemoryCache()
using System.Net.Http; // Para HttpClient

using Web.Aplication;
using Web.Infraestructura;

namespace Web.IOC
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddMemoryCache(); // Registro correcto de MemoryCache

            //services.AddHttpClient(); // Registro correcto de HttpClient

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioApi>(); // Repositorio
            services.AddScoped<AutenticacionService>(); // Servicio de autenticación
        }

    }
}
