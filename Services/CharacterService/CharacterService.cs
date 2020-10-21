using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using pidol.Dtos.Character;
using pidol.Models;

namespace pidol.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        private static List<GetCharacterDto> _characters = new List<GetCharacterDto> {
            new GetCharacterDto { Id = 1 },
            new GetCharacterDto { Id = 2, Name = "Jackie" }
        };

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var character = _mapper.Map<GetCharacterDto>(newCharacter);
            character.Id = _characters.Max(chr => chr.Id) + 1;

            _characters.Add(character);

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>()
            {
                Data = _mapper.Map<List<GetCharacterDto>>(_characters)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>
            {
                Data = _mapper.Map<List<GetCharacterDto>>(_characters)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>
            {
                Data = _mapper.Map<GetCharacterDto>(_characters.FirstOrDefault(chr => chr.Id.Equals(id)))
            };

            return serviceResponse;
        }
    }
}