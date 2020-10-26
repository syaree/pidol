using AutoMapper;
using pidol.Dtos.Character;
using pidol.Models;

namespace pidol
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}