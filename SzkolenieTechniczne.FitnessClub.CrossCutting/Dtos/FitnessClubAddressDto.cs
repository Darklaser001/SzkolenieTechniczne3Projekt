using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.FitnessClub.CrossCutting.Dtos
{
    public class FitnessClubAddressDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid FitnessClubId { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [StringLength(256)]
        public string? Post { get; set; }

        [StringLength(256)]
        public string? Province { get; set; }

        [StringLength(256)]
        public string? District { get; set; }

        [StringLength(256)]
        public string? Community { get; set; }

        [StringLength(256)]
        public string? City { get; set; }

        [StringLength(256)]
        public string? Street { get; set; }

        [StringLength(16)]
        public string? FlatNumber { get; set; }

        [StringLength(16)]
        public string? HouseNumber { get; set; }
    }
}
