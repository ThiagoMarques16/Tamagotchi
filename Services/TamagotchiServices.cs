using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Models;

namespace Tamagotchi.Services
{
    public class TamagotchiServices
    {
        
        public List<PokemonSpeciesResult> ObterEspeciesDisponiveis()
        {
            // Obter a lista de espécies de Pokémons

            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            var pokemonSpeciesResponse = JsonConvert.DeserializeObject<PokemonSpeciesResponse>(response.Content);

            return pokemonSpeciesResponse.Results;;
        }
    }
}