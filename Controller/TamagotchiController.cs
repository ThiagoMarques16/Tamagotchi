using Tamagotchi.Models;
using Tamagotchi.Services;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        private TamagotchiServices tamagotchiServices {get ; set ;}
        private TamagotchiView tamagotchiView {get ; set ;}
        private List<PokemonSpeciesResult> especiesDisponiveis {get ; set ;}

        public TamagotchiController(){
            tamagotchiView = new TamagotchiView();
            tamagotchiServices = new TamagotchiServices();
            especiesDisponiveis = tamagotchiServices.ObterEspeciesDisponiveis();
        }
        public void Jogar(){
            tamagotchiView.ApresentarBoasVindas();

            while(true){
                tamagotchiView.ApresentarMenu();
                int escolha = tamagotchiView.ObterOpcao(3);

                switch(escolha){
                    case 1:
                        while(true){
                            tamagotchiView.ListarPokemonsDisponiveis(especiesDisponiveis);
                            int escolhaMascote = tamagotchiView.ObterOpcao(especiesDisponiveis.Count);
                            tamagotchiView.ApresentarMenuMascote();
                            int escolhaMenuMascote = tamagotchiView.ObterOpcao(especiesDisponiveis.Count);

                            switch(escolhaMenuMascote){
                                case 1:
                                System.Console.WriteLine("Habilidades");
                                break;
                            }
                        }   

                    case 2:
                        System.Console.WriteLine("Opção dois");
                    break;    
                }
            }
            
        }
    }
}