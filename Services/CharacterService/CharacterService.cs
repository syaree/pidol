using System.Collections.Generic;
using System.Linq;

using pidol.Models;

namespace pidol.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> _characters = new List<Character> {
            new Character { Id = 1 },
            new Character { Id = 2, Name = "Jackie" }
        };

        public List<Character> AddCharacter(Character newCharacter)
        {
            _characters.Add(newCharacter);

            return _characters;
        }

        public List<Character> GetAllCharacters()
        {
            return _characters;
        }

        public Character GetCharacterById(int id)
        {
            return _characters.FirstOrDefault<Character>(chr => chr.Id.Equals(id));
        }
    }
}