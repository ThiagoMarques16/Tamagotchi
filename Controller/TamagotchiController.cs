using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Models;

namespace _7DaysOfCodeTamagotchi.Controller
{
    public class TamagotchiController
    {
        public void BuscarPokemons(){
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            var pokemonResult = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            for(int i = 0; i < pokemonResult.Results.Length; i++){
                System.Console.WriteLine($"{i + 1} - {pokemonResult.Results[i].Name.ToUpper()}");
            }
        }
    }
}