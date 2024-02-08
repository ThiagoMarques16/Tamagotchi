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
            Console.WriteLine("-----------------MENU PRINCIPAL--------------");
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
            Console.WriteLine("3- Ir para o menu principal");
            Console.WriteLine("4- Voltar");
            Console.Write("Opcao desejada: ");
        }

        public void ListarPokemonsDisponiveis(List<PokemonSpeciesResult> listaPokemons){

            var i = 1;
            foreach(var pokemon in listaPokemons){
                
                System.Console.WriteLine($"{i ++} - {pokemon.Name.ToUpper()}");
            }

            Console.Write("Opcao desejada: ");
        }

        public void ListarDescricaoDoPokemon(PokemonDetails pokemonDetails){
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
            Console.WriteLine("4- Voltar");
        }

        public void MostrarNascimento(){
            string caminhoDoArquivo = "C:\\Users\\User\\Documents\\7DaysOfCodeTamagotchi\\Tamagotchi\\Src\\egg.txt";

            // Verifica se o arquivo existe para evitar erros
            if (File.Exists(caminhoDoArquivo))
            {
                // Ler todas as linhas do arquivo
                string[] linhas = File.ReadAllLines(caminhoDoArquivo);

                // Iterar sobre cada linha e imprimir no console
                System.Console.WriteLine("MASCOTE ADOTADO COM SUCESSO!! SEU OVO ESTÁ CHOCANDO");
                foreach (string linha in linhas)
                {
                    Console.WriteLine($"{linha.Replace("\"", "\\\"")}");
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
                System.Console.WriteLine("");
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