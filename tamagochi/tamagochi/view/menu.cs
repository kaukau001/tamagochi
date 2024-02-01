using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamagochi.dto;
namespace tamagochi.view
{
    public class Menu
    {
        public void WellcomeMessage()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Bem-vindo ao Tamagochi Pokémon!");
            Console.Write("Por favor, digite seu nome: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Olá, " + playerName + "! Vamos começar!");
        }

        public void PrincipalMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Adoção de Pokémons");
            Console.WriteLine("2. Ver Pokémons Adotados");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

        }

        public int GetPlayersChoice()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.Write("Escolha inválida. Por favor, escolha uma opção entre 1 e 4: ");
            }
            return escolha;
        }

        public void ShowAdoptionMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Adoção de Pokémon:");
            Console.WriteLine("1. Ver Pokemons Disponíveis");
            Console.WriteLine("2. Ver Detalhes do Pokémon");
            Console.WriteLine("3. Adotar um Pokémon");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
        }

        public void ShowPokemonNames(List<string> pokemonNames)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Pokémons Disponíveis para Adoção:");

            foreach (var (name, index) in pokemonNames.Select((name, index) => (name, index + 1)))
            {
                Console.WriteLine($"{index} - {name.ToUpper()}");
            }
        }




        public void ShowPokemonDetails(PokemonDTO pokemon)
        {
            if (pokemon != null)
            {
                Console.WriteLine($"\nDADOS DO POKÉMON" +
                    $"\n NOME: {pokemon.Name.ToUpper()}" +
                    $"\n ALTURA: {pokemon.Height}" +
                    $"\n ID: {pokemon.Id}" +
                    $"\n PESO: {pokemon.Weight}" +
                    $"\n ABILIDADES:");
                foreach (var ability in pokemon.Abilities)
                {
                    Console.WriteLine($"    {ability.Ability.Name.ToUpper()}");
                }
                Console.WriteLine(" STATS:");
                foreach (var stat in pokemon.Stats)
                {
                    Console.WriteLine($"    {stat.InnerStat.Name.ToUpper()}: {stat.BaseStat}");
                }
            }
        }

        public bool ConfirmAdoption()
        {
            Console.WriteLine("\n ──────────────");
            Console.Write("Você gostaria de adotar este Pokémon? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void ShowAdoptedPokemons(List<PokemonDTO> adoptedPokemons)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Pokémons Adotados:");
            if (adoptedPokemons.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum Pokémon.");
            }
            else
            {
                for (int i = 0; i < adoptedPokemons.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + adoptedPokemons[i].Name.ToUpper());
                }
            }
        }
        public int GetChosenPokemonNumber(List<string> pokemons)
        {
            Console.WriteLine("\n ──────────────");
            int choice;
            while (true)
            {
                Console.Write($"Escolha um Pokémon pelo número (1-{pokemons.Count}): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= pokemons.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }
            return choice;
        }
    }

}