using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;
using SzkolenieTechniczne.Common.Storage.Entities;
namespace SzkolenieTechniczne.Geo.Storage 
{
    public class FitnessClubDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FitnessClubDbContext(IConfiguration configuration)
            : base()
        {
            _configuration = configuration;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }
        public DbSet<SzkolenieTechniczne.FitnessClub.Storage.Entities.FitnessClub> Companies { get; set; }
        public DbSet<FitnessClubAddress> FitnessClubAddresses { get; set; }
        public DbSet<StaffMember> JobPositions { get; set; }
        public DbSet<StaffMemberTranslation> JobPositionTranslations { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=FitnessClub-dev;trusted_connection=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "FitnessClub"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}