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

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"..\..\..\Src\tamagotchi.txt";
            string filePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }

            Console.WriteLine("---------------BEM VINDO-----------");
            Console.WriteLine("BEM VINDO ao Tamagotchi, qual é o seu nome?");
            string nome = Console.ReadLine();
            Console.WriteLine($"Olá {nome}, vamos Jogar :)");          
        }

        public void ApresentarMenu(){

            Console.WriteLine("-----------------MENU PRINCIPAL--------------");
            Console.WriteLine($"Menu principal: ");
            Console.WriteLine("1- Adotar um mascote virtual");
            Console.WriteLine("2- Ver seus mascotes virtuais");
            Console.WriteLine("3- Interagir com mascote");
            Console.WriteLine("4- Sair do jogo");
            Console.Write("Opcao desejada: ");
        }

        public void ApresentarMenuMascote(){
            Console.WriteLine("-------------OPÇÕES DO MASCOTE-------------");
            Console.WriteLine("1- Saber mais sobre o mascote");
            Console.WriteLine("2- Adotar mascote escolhido");
            Console.WriteLine("3- Ir para o menu principal");
            Console.Write("Opcao desejada: ");
        }

        public void ListarPokemonsDisponiveis(List<PokemonSpeciesResult> listaPokemons){
            Console.WriteLine("-------------ESPECIES DISPONIVEIS-------------");
            var i = 1;
            foreach(var pokemon in listaPokemons){
                
                System.Console.WriteLine($"{i ++} - {pokemon.Name.ToUpper()}");
            }

            Console.Write("Opcao desejada: ");
        }

        public void ListarDescricaoDoPokemon(PokemonDetails pokemonDetails){
            System.Console.WriteLine("-------------INFORMAÇÕES DO MASCOTE-------------");
            Console.WriteLine($"Nome - {pokemonDetails.Name.ToUpper()}");
            Console.WriteLine($"Peso - {pokemonDetails.Weight}");
            Console.WriteLine($"Altura - {pokemonDetails.Height}");
            Console.WriteLine($"Habilidades:");
            foreach(var habilidades in pokemonDetails.Abilities){
                System.Console.WriteLine(habilidades.Ability.Name.ToUpper());
            }
        }

        public void MenuDeInteracaoComMascote(){
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1- Saber como Mascote está");
            Console.WriteLine("2- Brincar com o mascote");
            Console.WriteLine("3- Alimentar o Mascote");
            Console.WriteLine("4- Botar mascote para dormir");
            Console.WriteLine("5- Levar mascote ao veterinario");
            Console.WriteLine("6- Voltar");
        }

        public void MostrarNascimento(){
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"..\..\..\Src\egg.txt";
            string filePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

            try
            {   
                System.Console.WriteLine("MASCOTE ADOTADO, SEU OVO ESTÁ CHOCANDO");
                foreach (string line in File.ReadLines(filePath))
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }
        }

        public bool ConfirmarAdocao(){
            System.Console.WriteLine("Deseja confirmar adoção (s/n)?");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
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