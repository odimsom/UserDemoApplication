using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Aplication;
using Web.Domain;

namespace Web.Infraestructura
{
    public class UsuarioRepositorioApi : IUsuarioRepositorio
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;

        public UsuarioRepositorioApi(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            if (_cache.TryGetValue($"usuario_{id}", out Usuario usuario))
            {
                return usuario;
            }

            var respuesta = await _httpClient.GetFromJsonAsync<Usuario>($"https://localhost:7208/api/User/ById?id={id}");
            _cache.Set($"usuario_{id}", respuesta, TimeSpan.FromMinutes(10));

            return respuesta;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            var response = await _httpClient.GetAsync("https://localhost:7208/api/User");
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("JSON Recibido: " + json);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<OperationResult<IEnumerable<Usuario>>>(json, options);

            return result?.Data ?? new List<Usuario>(); // Extraer la lista de usuarios
        }


        public async Task<Usuario> Crear(Usuario usuario)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("https://localhost:7208/api/User", usuario);
            return await respuesta.Content.ReadFromJsonAsync<Usuario>();
        }
    }
}
