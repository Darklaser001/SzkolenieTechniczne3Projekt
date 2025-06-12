using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SzkolenieTechinczne.FitnessClub.Resolvers;
using SzkolenieTechniczne.Common.API.Service;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Extensions;
using SzkolenieTechniczne.FitnessClub.Storage;
using SzkolenieTechniczne.Geo.Storage;
using SzkoleniteTechniczne.FitnessClub.Extensions;

namespace SzkolenieTechniczne.FitnessClub.Services
{
    public class FitnessClubService : CrudServiceBase<FitnessClubDbContext, SzkolenieTechniczne.FitnessClub.Storage.Entities.FitnessClub, FitnessClubDto>
    {
        private readonly CountryIntegrationDataResolver _countryResolver;
        private readonly FitnessClubDbContext _context;

        public FitnessClubService(FitnessClubDbContext context, CountryIntegrationDataResolver countryResolver) : base(context)
        {
            _countryResolver = countryResolver;
            _context = context;
        }

        public async Task<IEnumerable<FitnessClubDto>> GetAllAsync()
        {
            var companies = await base.Get();

            return companies.Select(e => e.ToDto());
        }

        public async Task<FitnessClubDto?> GetByIdAsync(Guid id)
        {
            var city = await base.GetById(id);
            return city.ToDto();
        }

        public async Task<FitnessClubDto> CreateAsync(FitnessClubDto dto)
        {
            var entity = dto.ToEntity();
            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return false;

            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        protected override IQueryable<Storage.Entities.FitnessClub> ConfigureFromIncludes(IQueryable<Storage.Entities.FitnessClub> linq)
        {
            return linq
                .Include(c => c.Address)
                .Include(c => c.StaffMembers)
                .ThenInclude(j => j.Translations);
        }

        protected override async Task OnBeforeRecordCreateAsync(FitnessClubDbContext context, SzkolenieTechniczne.FitnessClub.Storage.Entities.FitnessClub entity)
        {
            if (entity.Address != null)
            {
                await _countryResolver.ResolveFor(entity.Address.CountryId);
            }
        }

    }
}