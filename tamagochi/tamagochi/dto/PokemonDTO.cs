using Newtonsoft.Json;

namespace tamagochi.dto
{
    public class PokemonDTO
    {
        public required string Name { get; set; }
        public int Id { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public required List<Stat> Stats { get; set; }

        public required List<AbilityDetail> Abilities { get; set; }
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

    public class AbilityDetail
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}