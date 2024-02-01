using tamagochi.service;
using tamagochi.dto;
using tamagochi.view;
using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        try
        {
            Menu menu = new Menu();

            menu.WellcomeMessage();
            List<string> pokemonListNames = PokemonApiService.GetAllPokemonsNames();
            List<PokemonDTO> adoptedPokemons = new List<PokemonDTO>();
            int mainChoice;

            do
            {
                menu.PrincipalMenu();
                mainChoice = menu.GetPlayersChoice();

                switch (mainChoice)
                {
                    case 1:
                        int adoptionChoice;
                        do
                        {
                            menu.ShowAdoptionMenu();
                            adoptionChoice = menu.GetPlayersChoice();

                            switch (adoptionChoice)
                            {
                                case 1:
                                    menu.ShowPokemonNames(pokemonListNames);
                                    break;
                                case 2:
                                    menu.ShowPokemonNames(pokemonListNames);
                                    int chosenPokemonNumber = menu.GetChosenPokemonNumber(pokemonListNames);
                                    PokemonDTO pokemonDTO = PokemonApiService.GetPokemonDetails(chosenPokemonNumber);
                                    menu.ShowPokemonDetails(pokemonDTO);
                                    break;
                                case 3:
                                    menu.ShowPokemonNames(pokemonListNames);
                                    chosenPokemonNumber = menu.GetChosenPokemonNumber(pokemonListNames);
                                    pokemonDTO = PokemonApiService.GetPokemonDetails(chosenPokemonNumber);
                                    menu.ShowPokemonDetails(pokemonDTO);

                                    if (menu.ConfirmAdoption())
                                    {
                                        adoptedPokemons.Add(pokemonDTO);
                                        Console.WriteLine("Parabéns! Você adotou um " + pokemonDTO.Name + "!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────");
                                    }
                                    break;
                                case 4:
                                    break;
                            }
                        } while (adoptionChoice != 4);
                        break;
                    case 2:
                        menu.ShowAdoptedPokemons(adoptedPokemons);
                        break;
                    case 3:
                        Console.WriteLine("Safoda!");
                        break;
                }
            } while (mainChoice != 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
