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

        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            _characters.Add(newCharacter);

            return _characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return _characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return _characters.FirstOrDefault<Character>(chr => chr.Id.Equals(id));
        }
    }
}