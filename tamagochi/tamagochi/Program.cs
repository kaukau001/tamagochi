using Newtonsoft.Json;
using RestSharp;

public class PokemonDTO
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Weight { get; set; }
    public List<Stat> Stats { get; set; }
}

public class Stat
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }

    [JsonProperty("effort")]
    public int Effort { get; set; }

    [JsonProperty("stat")]
    public InnerStat InnerStat { get; set; }
}

public class InnerStat
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Escolha um Pokémon entre os 20 abaixo:");

        List<string> pokemonList = new List<string>
        {
            "bulbasaur", "ivysaur", "venusaur", "charmander", "charmeleon",
            "charizard", "squirtle", "wartortle", "blastoise", "pikachu",
            "jigglypuff", "meowth", "psyduck", "growlithe", "poliwrath",
            "machop", "geodude", "magnemite", "doduo", "onix"
        };

        foreach (var pokemon in pokemonList)
        {
            Console.WriteLine(pokemon);
        }

        Console.Write("Digite o nome do Pokémon escolhido: ");
        string pokemonName = Console.ReadLine().ToLower();

        if (pokemonList.Contains(pokemonName))
        {
            PokemonDTO pokemonDTO = GetPokemonData(pokemonName);
            DisplayPokemonDTO(pokemonDTO);
        }
        else
        {
            Console.WriteLine("Pokemon não reconhecido. Certifique-se de digitar corretamente.");
        }
    }

    static PokemonDTO GetPokemonData(string pokemonName)
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
            Console.WriteLine($"Erro: {ex.Message}");
        }

        return null;
    }

    static void DisplayPokemonDTO(PokemonDTO pokemonDTO)
    {
        if (pokemonDTO != null)
        {
            Console.WriteLine($"Dados do Pokémon");
            Console.WriteLine($"Nome: {pokemonDTO.Name.ToString().ToUpper()}");
            Console.WriteLine($"ID: {pokemonDTO.Id}");
            Console.WriteLine($"Peso: {pokemonDTO.Weight}");

            Console.WriteLine("Stats:");
            foreach (var stat in pokemonDTO.Stats)
            {
                Console.WriteLine($"{stat.InnerStat.Name}:");
                Console.WriteLine($"  Base Stat: {stat.BaseStat}");
            }
        }
    }
}
