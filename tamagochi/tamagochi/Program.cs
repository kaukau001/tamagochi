using tamagochi.service;
using tamagochi.dto;

public class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Escolha um Pokémon entre os 20 abaixo:");

            var pokemonListNames = PokemonApiService.GetAllPokemonsNames();

            while (true)
            {
                Console.Write("Digite o nome do Pokémon escolhido ('exit' para sair): ");
                string pokemonName = Console.ReadLine().ToLower();

                if (pokemonName == "exit")
                {
                    Console.WriteLine("Programa encerrado. Até logo!");
                    return;
                }

                if (pokemonListNames.Contains(pokemonName))
                {
                    PokemonDTO pokemonDTO = PokemonApiService.GetPokemonDetails(pokemonName);
                    DisplayPokemonDTO(pokemonDTO);
                    break;
                }
                else
                {
                    Console.WriteLine("Pokemon não reconhecido. Certifique-se de digitar corretamente.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Programa encerrado. Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }

    static void DisplayPokemonDTO(PokemonDTO pokemonDTO)
    {
        if (pokemonDTO != null)
        {
            Console.WriteLine($"\nDADOS DO POKEMON" +
                $"\n NOME: {pokemonDTO.Name.ToUpper()}" +
                $"\n ALTURA: {pokemonDTO.Height}" +
                $"\n ID: {pokemonDTO.Id}" +
                $"\n PESO: {pokemonDTO.Weight}" +
                $"\n ABILIDADES:");
            foreach (var ability in pokemonDTO.Abilities)
            {
                Console.WriteLine($"    {ability.Ability.Name.ToUpper()}");
            }
            Console.WriteLine(" STATS:");
            foreach (var stat in pokemonDTO.Stats)
            {
                Console.WriteLine($"    {stat.InnerStat.Name.ToUpper()}: {stat.BaseStat}");
            }
        }
    }
}
