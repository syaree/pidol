using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pidol.Dtos.Character;
using pidol.Models;

namespace pidol.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<GetCharacterDto> _characters = new List<GetCharacterDto> {
            new GetCharacterDto { Id = 1 },
            new GetCharacterDto { Id = 2, Name = "Jackie" }
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            _characters.Add(newCharacter);
            serviceResponse.Data = _characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>
            {
                Data = _characters.FirstOrDefault<GetCharacterDto>(chr => chr.Id.Equals(id))
            };

            return serviceResponse;
        }
    }
}