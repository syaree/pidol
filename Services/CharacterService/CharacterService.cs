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
        
        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var selectedCharacter = _characters.FirstOrDefault(chr => chr.Id.Equals(updatedCharacter.Id));
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            if (selectedCharacter != null)
            {
                selectedCharacter.Class = updatedCharacter.Class;
                selectedCharacter.Defense = updatedCharacter.Defense;
                selectedCharacter.Intelligence = updatedCharacter.Intelligence;
                selectedCharacter.Name = updatedCharacter.Name;
                selectedCharacter.Strength = updatedCharacter.Strength;
                selectedCharacter.HitPoints = updatedCharacter.HitPoints;

                serviceResponse.Data = selectedCharacter;
            } else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var deletedCharacter = _characters.RemoveAll(chr => chr.Id.Equals(id));
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            if (deletedCharacter > 0)
            {
                serviceResponse.Success = true;
                serviceResponse.Data = _characters;
            }
            else
            {
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}