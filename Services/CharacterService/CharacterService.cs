using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pidol.Models;

namespace pidol.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> _characters = new List<Character> {
            new Character { Id = 1 },
            new Character { Id = 2, Name = "Jackie" }
        };

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            _characters.Add(newCharacter);
            serviceResponse.Data = _characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = _characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = _characters.FirstOrDefault<Character>(chr => chr.Id.Equals(id));

            return serviceResponse;
        }
    }
}