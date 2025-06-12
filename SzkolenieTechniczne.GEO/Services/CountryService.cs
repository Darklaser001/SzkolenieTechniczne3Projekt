using Microsoft.EntityFrameworkCore; 
using SzkolenieTechniczne.Common.API.Service;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.GEO.Extensions;
using System.Linq; 

namespace SzkolenieTechniczne.GEO.Services
{
    public class CountryService : CrudServiceBase<GeoDbContext, Country, CountryDto>
    {
        private GeoDbContext _geoDbContext; 

        public CountryService(GeoDbContext geoDbContext) : base(geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CountryDto?> GetById(Guid id) 
        {
            var country = await _geoDbContext.Countries
                                             .Include(c => c.Translations) 
                                             .FirstOrDefaultAsync(c => c.Id == id);


            return country?.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {

            var countries = await _geoDbContext.Countries
                                               .Include(c => c.Translations) 
                                               .ToListAsync();

            return countries.Select(c => c.ToDto());
        }


        public async Task<CrudOperationResult<CountryDto>> Create(CountryDto dto)
        {
            var entity = dto.ToEntity(); 

            _geoDbContext.Countries.Add(entity);
            await _geoDbContext.SaveChangesAsync();


            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CountryDto>> Update(CountryDto dto)
        {
            var existingEntity = await _geoDbContext.Countries
                                                    .Include(c => c.Translations) 
                                                    .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (existingEntity == null)
            {
                return new CrudOperationResult<CountryDto>
                {
                    Status = CrudOperationResultStatus.Failure 
                };
            }

            existingEntity.Alpha3Code = dto.Alpha3Code;

            _geoDbContext.CountryTranslations.RemoveRange(existingEntity.Translations);

            existingEntity.Translations = dto.Name.Select(x => new CountryTranslation
            {
                CountryId = existingEntity.Id, 
                LanguageCode = x.Key,
                Name = x.Value
            }).ToList();

            await _geoDbContext.SaveChangesAsync();

            var updatedDto = await GetById(dto.Id); 

            return new CrudOperationResult<CountryDto>
            {
                Result = updatedDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CountryDto>> Delete(Guid id)
        {
            var entity = await _geoDbContext.Countries.FindAsync(id);
            if (entity == null)
            {
                return new CrudOperationResult<CountryDto>
                {
                    Status = CrudOperationResultStatus.Failure
                };
            }

            _geoDbContext.Countries.Remove(entity);
            await _geoDbContext.SaveChangesAsync();

            return new CrudOperationResult<CountryDto>
            {
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}