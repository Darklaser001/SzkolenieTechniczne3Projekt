using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos
{
    public class FitnessClubDto
    {
        public Guid Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        [Required]
        public string VATNumber { get; set; }
        public string RegistrationNumber { get; set; }

        [MaxLength(8)]
        public string PhonePrefix { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        public FitnessClubAddressDto? Address { get; set; }

    }
}