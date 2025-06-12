using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.FitnessClub.Storage.Entities
{
    [Table("StaffMembers", Schema = "Fitness")] 
    public class StaffMember : BaseEntity
    {
        public Guid FitnessClubId { get; set; }
        public FitnessClub FitnessClub { get; set; }

        [MaxLength(256)]
        public string? Name { get; set; } = null!;

        public short? WorkingHours { get; set; }

        [Required]
        public decimal GrossSalary { get; set; }

        [Required]
        public short WorkingWeekHours { get; set; }

        public ICollection<StaffMemberTranslation> Translations { get; set; } = new HashSet<StaffMemberTranslation>();

    }
}