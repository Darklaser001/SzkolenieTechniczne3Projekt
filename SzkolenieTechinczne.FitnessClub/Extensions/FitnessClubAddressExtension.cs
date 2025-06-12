using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;

namespace SzkolenieTechniczne.FitnessClub.Extensions
{
    public static class FitnessClubAddressExtension
    {
        public static FitnessClubAddressDto ToDto(this FitnessClubAddress entity)
        {
            return new FitnessClubAddressDto
            {
                Id = entity.Id,
                FitnessClubId = entity.FitnessClubId,
                CountryId = entity.CountryId,
                Post = entity.Post,
                Province = entity.Province,
                District = entity.District,
                Community = entity.Community,
                City = entity.City,
                Street = entity.Street,
                FlatNumber = entity.FlatNumber,
                HouseNumber = entity.HouseNumber
            };
        }
    }
}