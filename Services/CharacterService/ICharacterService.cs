using System.Collections.Generic;
using System.Threading.Tasks;

using pidol.Models;

namespace pidol.Services.CharacterServices
{
    public interface ICharacterService {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}