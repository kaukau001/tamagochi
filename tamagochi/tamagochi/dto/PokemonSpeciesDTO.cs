namespace tamagochi.dto
{

    public class PokemonSpeciesDTO
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResultDTO> Results { get; set; }
    }
}