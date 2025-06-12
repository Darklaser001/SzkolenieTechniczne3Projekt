using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.GEO.Extensions;
using SzkolenieTechniczne.Common.API.Service;


namespace SzkolenieTechniczne.GEO.Services
{
    public class CityService : CrudServiceBase<GeoDbContext, City, CityDto>
    {
        private GeoDbContext _geoDbContext; 

        public CityService(GeoDbContext geoDbContext) : base(geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }


        public async Task<IEnumerable<CityDto>> Get()
        {

            var cities = await _geoDbContext.Cities
                                            .Include(c => c.Translations) 
                                            .ToListAsync();

            return cities.Select(x => x.ToDto());
        }


        public async Task<CityDto> GetById(Guid id)
        {
            var city = await _geoDbContext.Cities
                                          .Include(c => c.Translations) 
                                          .FirstOrDefaultAsync(c => c.Id == id);

            return city?.ToDto();
        }

        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();
 
            _geoDbContext.Cities.Add(entity);
            await _geoDbContext.SaveChangesAsync();

            var newDto = await GetById(entity.Id); 

            return new CrudOperationResult<CityDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CityDto>> Update(CityDto dto)
        {
            var existingEntity = await _geoDbContext.Cities
                                                    .Include(c => c.Translations) 
                                                    .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (existingEntity == null)
            {
                return new CrudOperationResult<CityDto>
                {
                    Status = CrudOperationResultStatus.Failure 
                };
            }


            _geoDbContext.CityTranslations.RemoveRange(existingEntity.Translations);
            existingEntity.Translations = dto.Name.Select(x => new CityTranslation
            {
                CityId = existingEntity.Id, 
                LanguageCode = x.Key,
                Name = x.Value
            }).ToList();

            await _geoDbContext.SaveChangesAsync();

            var updatedDto = await GetById(dto.Id); 

            return new CrudOperationResult<CityDto>
            {
                Result = updatedDto,
                Status = CrudOperationResultStatus.Success
            };
        }


        public async Task<CrudOperationResult<CityDto>> Delete(Guid id)
        {
            var entity = await _geoDbContext.Cities.FindAsync(id);
            if (entity == null)
            {
                return new CrudOperationResult<CityDto>
                {
                    Status = CrudOperationResultStatus.Failure
                };
            }

            _geoDbContext.Cities.Remove(entity);
            await _geoDbContext.SaveChangesAsync();

            return new CrudOperationResult<CityDto>
            {
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}