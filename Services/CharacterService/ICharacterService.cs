using System.Collections.Generic;

using pidol.Models;

namespace pidol.Services.CharacterServices
{
    public interface ICharacterService {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);
    }
}