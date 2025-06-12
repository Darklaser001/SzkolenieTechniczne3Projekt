using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.GEO.Extensions
{
    public static class CountryDtoExtension
    {
        public static Country ToEntity(this CountryDto dto)
        {
            return new Country
            {
                Id = dto.Id,
                Alpha3Code = dto.Alpha3Code,
                Translations = dto.Name.Select(x => new CountryTranslation() 
                { CountryId = dto.Id, LanguageCode = x.Key, Name = x.Value }).ToList()
            };
        }
    }
}
