using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.GEO.Services;

namespace SzkolenieTechniczne.GEO.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGeoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CountryService>();
            serviceCollection.AddTransient<CityService>();
            serviceCollection.AddDbContext<GeoDbContext, GeoDbContext>();
            return serviceCollection;
        }

    }
}
