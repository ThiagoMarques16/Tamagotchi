using Tamagotchi.Models;
using Tamagotchi.Services;
using Tamagotchi.View;
using AutoMapper;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        private TamagotchiServices tamagotchiServices {get ; set ;}
        private TamagotchiView tamagotchiView {get ; set ;}
        private List<PokemonSpeciesResult> especiesDisponiveis {get ; set ;}
        private List<TamagotchiDto> mascotesAdotados {get ; set ; }

        IMapper mapper { get; set; }

        public TamagotchiController(){
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });

            mapper = config.CreateMapper();
            tamagotchiView = new TamagotchiView();
            tamagotchiServices = new TamagotchiServices();
            especiesDisponiveis = tamagotchiServices.ObterEspeciesDisponiveis();
        }
        public void Jogar(){
            tamagotchiView.ApresentarBoasVindas();
            bool jogar = true;
            while(jogar){
                tamagotchiView.ApresentarMenu();
                int escolha = tamagotchiView.ObterOpcao(3);

                switch(escolha){
                    case 1:
                        bool adotarMascote = true;
                        while(adotarMascote){
                            tamagotchiView.ListarPokemonsDisponiveis(especiesDisponiveis);
                            int escolhaMascote = tamagotchiView.ObterOpcao(especiesDisponiveis.Count);
                            bool MenuMascote = true;

                            while(MenuMascote){
                                tamagotchiView.ApresentarMenuMascote();
                                int escolhaMenuMascote = tamagotchiView.ObterOpcao(especiesDisponiveis.Count);

                                switch(escolhaMenuMascote){
                                case 1:
                                var pokemonDatelhe = tamagotchiServices.ObterDatalhesDaEspecies(escolhaMascote);
                                tamagotchiView.ListarDescricaoDoPokemon(pokemonDatelhe);
                                break;
                                case 2:
                                if(tamagotchiView.ConfirmarAdocao()){
                                    tamagotchiView.MostrarNascimento();
                                    pokemonDatelhe = tamagotchiServices.ObterDatalhesDaEspecies(escolhaMascote);
                                    TamagotchiDto tamagotchi = mapper.Map<TamagotchiDto>(pokemonDatelhe);
                                    mascotesAdotados.Add(tamagotchi);

                                    
                                }
                                
                                break;
                                case 3:
                                MenuMascote = false;
                                adotarMascote = false;
                                break;
                                }
                            }     
                        }   
                    break;
                    case 2:
                        foreach(var mascotes in mascotesAdotados){
                            System.Console.WriteLine(mascotes.Nome);
                        }
                    break;
                    case 3:
                    System.Console.WriteLine("Obrigado por jogar, até a proxima!!");
                    jogar = false;
                    break;    
                }
            }
            
        }
    }
}