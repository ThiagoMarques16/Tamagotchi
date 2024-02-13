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
            mascotesAdotados = new List<TamagotchiDto>();
            especiesDisponiveis = tamagotchiServices.ObterEspeciesDisponiveis();
        }
        public void Jogar(){
            tamagotchiView.ApresentarBoasVindas();
            string escolherMascote = "Escolha seu mascote: ";
            bool jogar = true;
            while(jogar){
                tamagotchiView.ApresentarMenu();
                int escolha = tamagotchiView.ObterOpcao(4);


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
                                var pokemonDetalhe = tamagotchiServices.ObterDatalhesDaEspecies(escolhaMascote);
                                tamagotchiView.ListarDescricaoDoPokemon(pokemonDetalhe);
                                break;
                                case 2:
                                if(tamagotchiView.ConfirmarAdocao()){
                                    tamagotchiView.MostrarNascimento();
                                    pokemonDetalhe = tamagotchiServices.ObterDatalhesDaEspecies(escolhaMascote);
                                    TamagotchiDto tamagotchi = mapper.Map<TamagotchiDto>(pokemonDetalhe);
                                    mascotesAdotados.Add(tamagotchi);          
                                }
                                MenuMascote = false;
                                adotarMascote = false;
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
                        var contador = 1;
                        if(!mascotesAdotados.Any()){
                            System.Console.WriteLine("Nenhum mascote encontrado");
                        }else{
                            System.Console.WriteLine("-----------LISTA DE MASCOTES ADOTADOS-----------");
                            foreach(var mascotes in mascotesAdotados){
                            System.Console.WriteLine($"{contador++} - {mascotes.Nome.ToUpper()}");
                            }
                        }
                    
                    break;
                    case 3:
                        if(!mascotesAdotados.Any()){
                            System.Console.WriteLine("Nenhum mascote encontrado");
                        }else{                 
                            bool interagirComMascote = true;
                            while(interagirComMascote){
                                tamagotchiView.MenuDeInteracaoComMascote();
                                var escolhaInteracao = tamagotchiView.ObterOpcao(6);
                                switch(escolhaInteracao){
                                    case 1:
                                            foreach(var status in mascotesAdotados){
                                            Console.WriteLine($"----{status.Nome.ToUpper()}----");
                                            Console.WriteLine($"Saude: {status.Saude}");
                                            Console.WriteLine($"Humor: {status.Humor}");
                                            Console.WriteLine($"Energia: {status.Energia}");
                                            Console.WriteLine($"Alimentação: {status.Alimentacao}");
                                            }
                                    break;

                                    case 2:
                                        
                                        tamagotchiView.ListarMascotesAdotados(mascotesAdotados);
                                        Console.Write(escolherMascote);
                                        var id = tamagotchiView.ObterOpcao(mascotesAdotados.Count);
                                        var mascoteEscolhido = mascotesAdotados[id - 1];
                                        Console.WriteLine($"Mascote escolhido: {mascoteEscolhido.Nome.ToUpper()}");
                                        mascoteEscolhido.BrincarComMascote();

                                    break;

                                    case 3:
                                       
                                        tamagotchiView.ListarMascotesAdotados(mascotesAdotados);
                                        Console.Write(escolherMascote);
                                        id = tamagotchiView.ObterOpcao(mascotesAdotados.Count);
                                        mascoteEscolhido = mascotesAdotados[id - 1];
                                        Console.WriteLine($"Mascote escolhido: {mascoteEscolhido.Nome.ToUpper()}");
                                        mascoteEscolhido.AlimentarMascote();
                                        
                                    break;
                                    case 4:
                                        
                                        tamagotchiView.ListarMascotesAdotados(mascotesAdotados);
                                        Console.Write(escolherMascote);
                                        id = tamagotchiView.ObterOpcao(mascotesAdotados.Count);
                                        mascoteEscolhido = mascotesAdotados[id - 1];
                                        Console.WriteLine($"Mascote escolhido: {mascoteEscolhido.Nome.ToUpper()}");
                                        mascoteEscolhido.BotarParaDormir();      
                                        
                                    break;

                                    case 5:
                                        
                                        tamagotchiView.ListarMascotesAdotados(mascotesAdotados);
                                        Console.Write(escolherMascote);
                                        id = tamagotchiView.ObterOpcao(mascotesAdotados.Count);
                                        mascoteEscolhido = mascotesAdotados[id - 1];
                                        Console.WriteLine($"Mascote escolhido: {mascoteEscolhido.Nome.ToUpper()}");
                                        mascoteEscolhido.LevarAoVeterinario();
                                        
                                    break;
                                    case 6:
                                        interagirComMascote = false;
                                    break;
                                    
                                }
                            }
                        }
                   
                    break;

                    case 4:
                    System.Console.WriteLine("Obrigado por jogar, até a próxima!!");
                    jogar = false;
                    break; 
                    default:
                     System.Console.WriteLine("Opção inválida");
                    break;

                }
            }
            
        }
    }
}