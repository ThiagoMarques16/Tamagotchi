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
            string caminhoDoArquivo = "C:\\Users\\thiia\\OneDrive\\Documentos\\7DaysOfCodeTamagotchi\\Tamagotchi\\Tamagotchi\\Src\\tamagotchi.txt";

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
            Console.WriteLine("4- Voltar");
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
            string caminhoDoArquivo = "C:\\Users\\thiia\\OneDrive\\Documentos\\7DaysOfCodeTamagotchi\\Tamagotchi\\Tamagotchi\\Src\\egg.txt";

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