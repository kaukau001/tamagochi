using Newtonsoft.Json;
using RestSharp;
using tamagochi.dto;

namespace tamagochi.service
{
    public class PokemonApiService
    {
        public static List<String> GetAllPokemonsNames()
        {
            try
            {
                var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
                var request = new RestRequest("", Method.Get);
                RestResponse response = client.Execute(request);
                var pokemonSpeciesDTO = JsonConvert.DeserializeObject<PokemonSpeciesDTO>(response.Content);
                List<string> pokemonNames = pokemonSpeciesDTO.Results.Select(result => result.Name).ToList();

                foreach (var result in pokemonSpeciesDTO.Results)
                {
                    Console.WriteLine($"Nome: {result.Name.ToUpper()}");
                }

                return pokemonNames;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a obtenção dos nomes dos pokémons: {ex.Message}");
                return new List<string>();
            }
        }
        public static PokemonDTO GetPokemonDetails(string pokemonName)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}/";
            var client = new RestClient(apiUrl);
            var request = new RestRequest("", Method.Get);

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<PokemonDTO>(response.Content);
                }
                else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode} - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a obtenção dos dados do Pokémon: {ex.Message}");
            }

            return null;
        }
    }
}
