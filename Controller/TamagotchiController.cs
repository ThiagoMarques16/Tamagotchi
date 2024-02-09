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
                        foreach(var mascotes in mascotesAdotados){
                            System.Console.WriteLine($"{contador++} - {mascotes.Nome.ToUpper()}");
                        }
                    break;
                    case 3:
                        tamagotchiView.MenuDeInteracaoComMascote();
                        bool interagirComMascote = true;
                        
                        while(interagirComMascote){
                            var escolhaInteracao = tamagotchiView.ObterOpcao(5);
                            switch(escolhaInteracao){
                                case 1:
                                    foreach(var status in mascotesAdotados){
                                        System.Console.WriteLine($"----{status.Nome.ToUpper()}----");
                                        System.Console.WriteLine($"Saude: {status.Saude}");
                                        System.Console.WriteLine($"Humor: {status.Humor}");
                                        System.Console.WriteLine($"Energia: {status.Energia}");
                                        System.Console.WriteLine($"Alimentação: {status.Alimentacao}");

                                    }
                                    interagirComMascote = false;
                                break;

                                case 2:

                                    foreach(var mascote in mascotesAdotados){
                                        System.Console.WriteLine(mascote.Nome.ToUpper());
                                    }
                                    string nome = Console.ReadLine();
                                    var mascoteEncontrado = mascotesAdotados.Find(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

                                    if (mascoteEncontrado != null)
                                    {
                                        mascoteEncontrado.BrincarComMascote();

                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Mascote não encontrado.");
                                    }

                                    interagirComMascote = false;
                                break;
                                case 3:
                                    foreach(var mascote in mascotesAdotados){
                                        System.Console.WriteLine(mascote.Nome.ToUpper());
                                    }
                                    nome = Console.ReadLine();
                                    mascoteEncontrado = mascotesAdotados.Find(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                                    if (mascoteEncontrado != null)
                                    {
                                        mascoteEncontrado.AlimentarMascote();
                                        System.Console.WriteLine("Mascote alimentado");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Mascote não encontrado.");
                                    }
                                    interagirComMascote = false;
                                break;
                                case 4:
                                foreach(var mascote in mascotesAdotados){
                                        System.Console.WriteLine(mascote.Nome.ToUpper());
                                    }
                                    nome = Console.ReadLine();
                                    mascoteEncontrado = mascotesAdotados.Find(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                                    if (mascoteEncontrado != null)
                                    {
                                        mascoteEncontrado.BotarParaDormir();
                                        System.Console.WriteLine("Seu mascote está dormindo");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Mascote não encontrado.");
                                    }
                                    interagirComMascote = false;
                                break;
                                
                            }
                        }
                    break;

                    case 4:
                    System.Console.WriteLine("Obrigado por jogar, até a proxima!!");
                    jogar = false;
                    break;    
                }
            }
            
        }
    }
}