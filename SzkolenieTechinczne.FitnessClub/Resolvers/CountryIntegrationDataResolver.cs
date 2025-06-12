using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;

namespace SzkolenieTechinczne.FitnessClub.Resolvers
{
    public class CountryIntegrationDataResolver
    {
        private readonly FitnessClubDbContext _dbContext;

        public CountryIntegrationDataResolver(FitnessClubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ResolveFor(Guid countryId)
        {
            var exist = await _dbContext.Countries.AnyAsync(x => x.Id == countryId);
            if (!exist)
            {
                var countryDto = await ResolveFromExternalDictionary(countryId);
                await CreateOrUpdateCountries(countryDto);
            }
        }

        private async Task<CountryDto?> ResolveFromExternalDictionary(Guid countryId)
        {
            string apiUrl = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("countries");

                string responseData = await response.Content.ReadAsStringAsync();

                List<CountryDto> countries = JsonConvert.DeserializeObject<List<CountryDto>>(responseData);

                return countries.FirstOrDefault(x => x.Id == countryId);
            }

        }

        private async Task<Country> CreateOrUpdateCountries(CountryDto dto)
        {
            var country = new Country
            {
                Id = dto.Id,
                Alpha3Code = dto.Alpha3Code,
                ExternalId = dto.Id.ToString(),
                ExternalSourceName = "Geo"
            };


            country.Translations = new List<CountryTranslation>();
            foreach (var item in dto.Name)
            {
                country.Translations.Add(new CountryTranslation
                {
                    CountryId = dto.Id,
                    LanguageCode = item.Key,
                    Name = item.Value,
                    Id = Guid.NewGuid(),
                });
            }
            _dbContext.Countries.Add(country);
            return country;
        }
    }
}
