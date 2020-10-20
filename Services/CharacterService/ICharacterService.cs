using System.Collections.Generic;
using System.Threading.Tasks;

using pidol.Models;

namespace pidol.Services.CharacterServices
{
    public interface ICharacterService {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    }
}