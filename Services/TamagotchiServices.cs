using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            try{
                var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
                var pokemonSpeciesResponse = JsonConvert.DeserializeObject<PokemonSpeciesResponse>(response.Content);
                return pokemonSpeciesResponse.Results;

            }catch(WebException e){

                Console.WriteLine($"Não foi possivel conectar à API: {e.Message}");
                return new List<PokemonSpeciesResult>();

            }catch(Exception e){

                Console.WriteLine($"Não foi possivel conectar à API: {e.Message}");
                return new List<PokemonSpeciesResult>();

            }

        }

        public PokemonDetails ObterDatalhesDaEspecies(int id){

            try{
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{id}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            var pokemonsDetailsResponse = JsonConvert.DeserializeObject<PokemonDetails>(response.Content);

            return pokemonsDetailsResponse;
            }catch(WebException e){

                Console.WriteLine($"Não foi possivel conectar à API: {e.Message}");
                return new PokemonDetails();
            }catch(Exception e){

                Console.WriteLine($"Não foi possivel conectar à API: {e.Message}");
                return new PokemonDetails();
            }
        }
    }
}