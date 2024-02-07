using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.View
{
    public class TamagotchiView
    {
        public void ApresentarBoasVindas(){
            Console.WriteLine("---------------BEM VINDO-----------");
            Console.WriteLine("BEM VINDO ao Tamagotchi, qual é o seu nome?");
            string nome = Console.ReadLine();
            Console.WriteLine($"Olá {nome}, vamos Jogar :)");          
        }

        public void ApresentarMenu(){
            Console.WriteLine("-----------------MENU--------------");
            Console.WriteLine($"Menu principal: ");
            Console.WriteLine("1- Adotar um mascote virtual");
            Console.WriteLine("2- Ver seus mascotes virtuais");
            Console.WriteLine("3- Sair do jogo");
            Console.Write("Opcao desejada: ");
        }

        public void ApresentarMenuMascote(){
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1- Saber mais sobre o Tamagotchi");
            Console.WriteLine("2- Adotar Tamagotchi escolhido");
            Console.WriteLine("3- Voltar");
            Console.Write("Opcao desejada: ");
        }

        public void ListarPokemonsDisponiveis(List<PokemonSpeciesResult> listaPokemons){

            var i = 1;
            foreach(var pokemon in listaPokemons){
                
                System.Console.WriteLine($"{i ++} - {pokemon.Name.ToUpper()}");
            }

            Console.Write("Opcao desejada: ");
        }

        
        public int ObterOpcao(int MaxOption){
            int option;
            while(!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > MaxOption){
                System.Console.WriteLine($"Opção invalida, selecione uma opçao entre 1 e {MaxOption}");
                Console.Write("Opcao desejada: ");
            }

            return option;
        }
    }
}