using Tamagotchi.Models;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.View;
using Tamagotchi.Services;
using Tamagotchi.Controller;

namespace  Tamagotchi;

public class Program{
      static void Main(string[] args){
            
            TamagotchiController teste = new TamagotchiController();

            teste.Jogar();
      }
}

