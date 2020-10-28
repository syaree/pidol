using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pidol.Data;
using pidol.Dtos.Character;
using pidol.Models;

namespace pidol.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var chr = _mapper.Map<Character>(newCharacter);

            await _context.Characters.AddAsync(chr);
            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>
            {
                Data = await _context.Characters.Select(chr => _mapper.Map<GetCharacterDto>(chr)).ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var dbCharacters = await _context.Characters.ToListAsync();
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>
            {
                Data = _mapper.Map<List<GetCharacterDto>>(dbCharacters)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var selectedCharacter = await _context.Characters.FirstOrDefaultAsync(chr => chr.Id.Equals(id));
            var serviceResponse = new ServiceResponse<GetCharacterDto>
            {
                Data = _mapper.Map<GetCharacterDto>(selectedCharacter)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var selectedCharacter = await _context.Characters.FirstOrDefaultAsync(chr => chr.Id.Equals(updatedCharacter.Id));
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            if (selectedCharacter != null)
            {
                selectedCharacter.Class = updatedCharacter.Class;
                selectedCharacter.Defense = updatedCharacter.Defense;
                selectedCharacter.Intelligence = updatedCharacter.Intelligence;
                selectedCharacter.Name = updatedCharacter.Name;
                selectedCharacter.Strength = updatedCharacter.Strength;
                selectedCharacter.HitPoints = updatedCharacter.HitPoints;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(selectedCharacter);

                _context.Characters.Update(selectedCharacter);
                await _context.SaveChangesAsync();
            } else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var selectedCharacter = await _context.Characters.FirstOrDefaultAsync(chr => chr.Id.Equals(id));

                _context.Characters.Remove(selectedCharacter);
                await _context.SaveChangesAsync();

                serviceResponse.Success = true;
                serviceResponse.Data = _context.Characters.Select(chr => _mapper.Map<GetCharacterDto>(chr)).ToList();
            }
            catch (Exception err)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = err.Message;
            }

            return serviceResponse;
        }
    }
}