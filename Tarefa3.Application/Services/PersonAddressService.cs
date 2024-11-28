using RestSharp;
using System.Linq;
using System.Threading.Tasks;
using Tarefa3.Domain.Models;

public class PersonAddressService
{
    private const string ViaCepBaseUrl = "https://viacep.com.br/ws/";
    private readonly List<Person> _people;

    public async Task<PersonAddress> GetAddressByPersonIdAsync(int personId)
    {
        // Buscar a pessoa pelo ID
        var person = _people.FirstOrDefault(p => p.Id == personId);
        if (person == null)
            throw new Exception("Usuário não encontrado.");

        if (string.IsNullOrWhiteSpace(person.Cep))
            throw new Exception("CEP do usuário está vazio.");

        // Fazer a chamada para o ViaCEP
        var client = new RestClient(ViaCepBaseUrl);
        var request = new RestRequest($"{person.Cep}/json/", Method.Get);

        var response = await client.ExecuteAsync<PersonAddress>(request);

        if (!response.IsSuccessful || response.Data == null)
            throw new Exception("Não foi possível obter o endereço no ViaCEP.");

        return response.Data;
    }
}
