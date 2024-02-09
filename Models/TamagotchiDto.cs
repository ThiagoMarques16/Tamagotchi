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

        public class Habilidade
        {
            public string Nome { get; set; }
        }
    }
}