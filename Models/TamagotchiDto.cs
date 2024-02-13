using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Models
{
    public class TamagotchiDto
    {
        public int Alimentacao {get ; set ;}
        public int Saude { get; set; }
        public int Humor { get; set; }
        public int Energia { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public string Nome { get; set; }
        public List<Habilidade> Habilidades { get; set; }

        public TamagotchiDto()
        {
            var rand = new Random();
            Alimentacao = rand.Next(10);
            Saude = rand.Next(10);
            Humor = rand.Next(10);
            Energia = rand.Next(10);
        }

        public void AtualizacaoDeInformacoes(PokemonDetails pokemonDetails){
            Nome = pokemonDetails.Name;
            Altura = pokemonDetails.Height;
            Peso = pokemonDetails.Weight;
            Habilidades = pokemonDetails.Abilities.Select(a => new Habilidade { Nome = a.Ability.Name }).ToList();
        }

        public void BrincarComMascote(){

            if (Energia <= 0)
            {
                System.Console.WriteLine("Seu mascote está muito cansado para brincar.");
                return; 
            }
            if (Saude <= 0)
            {
                System.Console.WriteLine("Seu mascote está muito doente para brincar.");
                return; 
            }
            if (Alimentacao <= 0)
            {
                System.Console.WriteLine("Seu mascote está com muita fome para brincar.");
                return; 
            }
            if (Humor < 10)
            {
                Humor++;
                Energia = Math.Max(0, Energia - 1);
                Saude = Math.Max(0, Saude - 1);
                Alimentacao = Math.Max(0, Alimentacao - 1);

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\..\Src\bola.txt";
                string filePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

            try
            {   
                System.Console.WriteLine("SEU MASCOTE É O ARTILHEIRO DO TIME");
                foreach (string line in File.ReadLines(filePath))
                {
                    Console.WriteLine(line);
                }

                System.Console.WriteLine("");
                System.Console.WriteLine("GOOOOOLLLLLL");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }
            }
            else
            {
                System.Console.WriteLine("O Humor do seu mascote chegou ao limite");
            } 
        }

        public void AlimentarMascote(){

            if (Alimentacao < 10)
            {
                Alimentacao = Math.Min(10, Alimentacao + 2);
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\..\Src\cereja.txt";
                string filePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

                try
                {   
                    System.Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("SEU MASCOTE ESTÁ ALIMENTADO");
                    foreach (string line in File.ReadLines(filePath))
                    {
                        Console.WriteLine(line);
                    }

                    System.Console.WriteLine("");
                }
                catch (Exception ex)
                {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }

                if (Energia < 10)
                {
                    Energia = Math.Min(10, Energia + 1);
                }
    
                if (Humor < 10)
                {
                    Humor = Math.Min(10, Humor + 1);
                }
            }
                else
                {
                    System.Console.WriteLine("SEU MASCOTE ESTÁ CHEIO");
                }
        }

        public void BotarParaDormir(){
            if(Energia < 10){
                Energia = Math.Min(10, Energia + 2);
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\..\Src\cama.txt";
                string filePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

                try
                {   
                    System.Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("A MIMIR Zzz");
                    foreach (string line in File.ReadLines(filePath))
                    {
                        Console.WriteLine(line);
                    }

                    System.Console.WriteLine("");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
                }


                if(Alimentacao < 10){
                    Alimentacao = Math.Max(0, -1);
                }
                if(Humor < 10){
                    Humor = Math.Min(10, Humor + 1);
                }
            }else{
                System.Console.WriteLine("SEU MASCOTE ESTÁ SEM SONO");
            }
        }

        public void LevarAoVeterinario(){
            if(Saude < 10){
                Saude ++;

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\..\Src\hospital.txt";
                string filePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

                try
                {   
                    System.Console.WriteLine("-------------------------------");
                    System.Console.WriteLine("");
                    foreach (string line in File.ReadLines(filePath))
                    {
                        Console.WriteLine(line);
                    }

                    System.Console.WriteLine("");
                    System.Console.WriteLine("SEU MASCOTE ESTÁ SENDO BEM ATENDIDO");
               

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
                }
            }
        }
        public class Habilidade
        {
            public string Nome { get; set; }
        }
    }
}