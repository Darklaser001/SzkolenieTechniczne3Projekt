using SzkolenieTechinczne.FitnessClub.Resolvers;
using SzkolenieTechniczne.FitnessClub.Services;
using SzkolenieTechniczne.Geo.Storage;

namespace SzkolenieTechinczne.FitnessClub.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFitnessClubServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<StaffMemberService>();
            serviceCollection.AddTransient<FitnessClubService>();
            serviceCollection.AddDbContext<FitnessClubDbContext, FitnessClubDbContext>();
            serviceCollection.AddTransient<CountryIntegrationDataResolver>();
            return serviceCollection;   
        }
    }
}
