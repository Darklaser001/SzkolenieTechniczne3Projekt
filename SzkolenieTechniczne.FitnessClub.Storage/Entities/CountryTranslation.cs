
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
    [Table("CountryTranslations", Schema = "Dictionaries")]
    public class CountryTranslation : BaseTranslation
    {
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        [MaxLength(64)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
