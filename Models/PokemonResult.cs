using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tamagotchi.Models
{
    public class PokemonResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}