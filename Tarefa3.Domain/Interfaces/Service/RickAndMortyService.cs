using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefa3.Domain.Models;
using Tarefa3.Data.Rest.Repository;
using System.Text.Json;

namespace Tarefa3.Domain.Interfaces.Service
{
    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CharacterResponse> GetCharacterByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/character/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao chamar a API do Rick and Morty.");
            }

            var content = await response.Content.ReadAsStringAsync();

            // Confirma o JSON recebido
            Console.WriteLine(content);

            return JsonSerializer.Deserialize<CharacterResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

    }

}
