using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;

namespace SzkoleniteTechniczne.FitnessClub.Extensions
{
    public static class FitnessClubAddressExtension
    {
        public static FitnessClubAddress ToEntity(this FitnessClubAddressDto dto)
        {
            return new FitnessClubAddress
            {
                Id = dto.Id,
                FitnessClubId = dto.FitnessClubId,
                CountryId = dto.CountryId,
                Post = dto.Post,
                Province = dto.Province,
                District = dto.District,
                Community = dto.Community,
                City = dto.City,
                Street = dto.Street,
                FlatNumber = dto.FlatNumber,
                HouseNumber = dto.HouseNumber
            };
        }
    }
}