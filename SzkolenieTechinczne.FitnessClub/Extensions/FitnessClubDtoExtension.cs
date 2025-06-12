using System.Linq;
using System.Collections.Generic;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Extensions;

namespace SzkoleniteTechniczne.FitnessClub.Extensions
{
    public static class FitnessClubDtoExtension
    {
        public static SzkolenieTechniczne.FitnessClub.Storage.Entities.FitnessClub ToEntity(this FitnessClubDto entity)
        {
            var result = new SzkolenieTechniczne.FitnessClub.Storage.Entities.FitnessClub
            {
                Id = entity.Id,
                Name = entity.Name,
                VATNumber = entity.VATNumber, 
                RegistrationNumber = entity.RegistrationNumber, 
                PhonePrefix = entity.PhonePrefix, 
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address?.ToEntity(),

            };

            return result;
        }
    }
}