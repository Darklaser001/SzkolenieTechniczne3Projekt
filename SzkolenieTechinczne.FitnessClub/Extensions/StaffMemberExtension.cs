using System.Linq;
using System.Collections.Generic;
using SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos;
using SzkolenieTechniczne.FitnessClub.Storage.Entities;

namespace SzkoleniteTechniczne.FitnessClub.Extensions
{
    public static class StaffMemberExtension
    {
        public static StaffMember ToEntity(this StaffMemberDto dto)
        {
            return new StaffMember
            {
                Id = dto.Id,
                FitnessClubId = dto.FitnessClubId,
                GrossSalary = dto.GrossSalary,
                WorkingHours = dto.WorkingHours,
                WorkingWeekHours = dto.WorkingWeekHours,

                Translations = dto.Name?.ToDictionary()
                    .Select(kv => new StaffMemberTranslation
                    {
                        LanguageCode = kv.Key,
                        Name = kv.Value
                    }).ToList()
                    ?? new List<StaffMemberTranslation>()
            };
        }
    }
}
