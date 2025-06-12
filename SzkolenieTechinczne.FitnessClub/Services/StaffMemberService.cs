using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;
using SzkoleniteTechniczne.FitnessClub.Extensions;
using SzkolenieTechniczne.FitnessClub.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SzkolenieTechniczne.Geo.Storage;

namespace SzkolenieTechniczne.FitnessClub.Services
{
    public class StaffMemberService
    {
        private readonly FitnessClubDbContext _context;

        public StaffMemberService(FitnessClubDbContext context)
        {
            _context = context;
        }

        public async Task<List<StaffMemberDto>> GetAllAsync()
        {
            var entities = await _context.JobPositions
                .Include(j => j.Translations)
                .ToListAsync();

            return entities.Select(e => e.ToDto()).ToList();
        }

        public async Task<StaffMemberDto?> GetByIdAsync(Guid id)
        {
            var entity = await _context.JobPositions
                .Include(j => j.Translations)
                .FirstOrDefaultAsync(e => e.Id == id);

            return entity?.ToDto();
        }

        public async Task<StaffMemberDto> CreateAsync(StaffMemberDto dto)
        {
            var entity = dto.ToEntity();
            _context.JobPositions.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task<StaffMemberDto?> UpdateAsync(StaffMemberDto dto)
        {
            var existing = await _context.JobPositions
                .Include(j => j.Translations)
                .FirstOrDefaultAsync(e => e.Id == dto.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(dto.ToEntity());
            existing.Translations = dto.Name.ToDictionary()
                .Select(kv => new StaffMemberTranslation
                {
                    LanguageCode = kv.Key,
                    Name = kv.Value
                }).ToList();

            await _context.SaveChangesAsync();
            return existing.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.JobPositions.FindAsync(id);
            if (entity == null) return false;

            _context.JobPositions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
