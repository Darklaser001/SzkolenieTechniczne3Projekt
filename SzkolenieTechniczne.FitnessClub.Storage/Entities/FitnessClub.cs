using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.FitnessClub.Storage.Entities
{
    [Table("FitnessClubs", Schema = "Fitness")]
    public class FitnessClub : BaseEntity
    {
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        public FitnessClubAddress Address { get; set; }

        [MaxLength(8)]
        public string PhonePrefix { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        [MaxLength(32)]
        public string VATNumber { get; set; } = null!;

        [MaxLength(16)]
        public string RegistrationNumber { get; set; }

        public ICollection<StaffMember> StaffMembers { get; set; } = new HashSet<StaffMember>();
    }
}