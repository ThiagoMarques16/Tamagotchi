using Tamagotchi.Models;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.View;
using _7DaysOfCodeTamagotchi.Models;
using _7DaysOfCodeTamagotchi.Controller;

namespace  Tamagotchi;

public class Program{
      static void Main(string[] args){
            
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            var pokemonsResponse = JsonConvert.DeserializeObject<Pokemon>(response.Content);
            
            TamagotchiView view = new TamagotchiView();
            TamagotchiController controller = new TamagotchiController();
            controller.BuscarPokemons();
            // view.ApresentarMenuMascote();
            // view.ObterOpcao(4);
            

            // int opcao;
            // if (!int.TryParse(Console.ReadLine(), out opcao))
            // {
            //     Console.WriteLine("Opção inválida.");
            //     return;
            // }

            // switch (opcao)
            // {
            //     case 1:
                  
            //       Console.WriteLine("-----------------ADOTAR UM TAMAGOTCHI--------------");
            //       for (int i = 0; i < pokemonsResponse.Results.Length; i++)
            //       {
            //             Console.WriteLine($"{i +1 } - {pokemonsResponse.Results[i].Name.ToUpper()}");
            //       }
            //       Console.WriteLine("Escolha um Tamagotchi: "); 
            //       int pokemonEscolhido = int.Parse(Console.ReadLine());

            //       client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
            //       request = new RestRequest("", Method.Get);
            //       response = client.Execute(request);
            //       var pokemonEscolhidoDetails = JsonConvert.DeserializeObject<PokemonDetails>(response.Content);
                  
            
            

            //       if(opcaoAdocao == 1){
            //             Console.WriteLine("-----------------INFORMACOES DO TAMAGOTCHI--------------");
            //             Console.WriteLine($"Tamagotchi escolhido: {pokemonEscolhidoDetails.Name.ToUpper()}");
            //             Console.WriteLine($"Tamanho: {pokemonEscolhidoDetails.Height}");
            //             Console.WriteLine($"Peso: {pokemonEscolhidoDetails.Weight}");
            //             Console.WriteLine($"Habilidades:");
            //             foreach(var ability in pokemonEscolhidoDetails.Abilities){
            //                   System.Console.WriteLine(ability.Ability.Name.ToUpper());
            //             }

            //             Console.WriteLine("---------------------------------------------------------");

            //             Console.WriteLine($"{nome}, informe a opção desejada");
            //             Console.WriteLine("1- Saber mais sobre o Tamagotchi");
            //             Console.WriteLine("2- Adotar Tamagotchi escolhido");
            //             Console.WriteLine("3- Voltar");
            //             Console.Write("Opcao desejada: ");
            //             opcaoAdocao = int.Parse(Console.ReadLine());
            //       }else if(opcaoAdocao == 2){
            //             System.Console.WriteLine("Parabens!!");
            //       }

            //       break;
            // }
      }
}

