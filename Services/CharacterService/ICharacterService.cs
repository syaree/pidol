using System.Collections.Generic;
using System.Threading.Tasks;

using pidol.Dtos.Character;
using pidol.Models;

namespace pidol.Services.CharacterService
{
    public interface ICharacterService {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
    }
}