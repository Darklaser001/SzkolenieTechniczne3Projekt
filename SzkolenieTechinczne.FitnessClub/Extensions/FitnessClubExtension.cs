using System.Linq;
using System.Collections.Generic;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;

namespace SzkolenieTechniczne.FitnessClub.Extensions
{
    public static class FitnessClubExtension
    {
        public static CrossCutting.Dtos.FitnessClubDto ToDto(this SzkolenieTechniczne.FitnessClub.Storage.Entities.FitnessClub entity)
        {
            var result = new CrossCutting.Dtos.FitnessClubDto
            {
                Id = entity.Id,
                Name = entity.Name,
                VATNumber = entity.VATNumber,
                RegistrationNumber = entity.RegistrationNumber,
                PhonePrefix = entity.PhonePrefix,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address?.ToDto()

            };

            return result;
        }
    }
}