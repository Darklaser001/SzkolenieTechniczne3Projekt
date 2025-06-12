using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SzkolenieTechniczne.GEO.Extensions
{
    public static class CountryExtension
    {
        public static CountryDto ToDto(this Country entity)
        {
            var result = new CountryDto
            {
                Id = entity.Id,
                Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                Alpha3Code = entity.Alpha3Code
            };
            return result;
        }
    }
}
