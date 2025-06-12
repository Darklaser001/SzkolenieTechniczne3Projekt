using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;

namespace SzkoleniteTechniczne.FitnessClub.Extensions
{
    public static class JobPositionDtoExtension
    {
        public static StaffMemberDto ToDto(this StaffMember entity)
        {
            return new StaffMemberDto
            {
                Id = entity.Id,
                FitnessClubId = entity.FitnessClubId,
                GrossSalary = entity.GrossSalary,
                WorkingHours = entity.WorkingHours,
                WorkingWeekHours = entity.WorkingWeekHours,

                Name = new LocalizedString(
                    entity.Translations?
                        .ToDictionary(t => t.LanguageCode, t => t.Name)
                    ?? new Dictionary<string, string>()
                )
            };
        }
    }
}