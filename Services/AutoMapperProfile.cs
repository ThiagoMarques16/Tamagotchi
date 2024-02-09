using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;
using AutoMapper;


namespace Tamagotchi.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonDetails, TamagotchiDto>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities.Select(a => new TamagotchiDto.Habilidade { Nome = a.Ability.Name })));
        }
    }

    public class MascoteService
    {
        private readonly IMapper _mapper;

        public MascoteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TamagotchiDto CriarMascote(PokemonDetails pokemon)
        {
            return _mapper.Map<TamagotchiDto>(pokemon);
        }
    }
}