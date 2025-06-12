using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage.Entities
{
    [Index(nameof(Name), IsUnique = false)]
    [Table("CountryTransaltions", Schema = "Geo")]
    public class CountryTranslation : BaseTranslation
    {
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        [MaxLength(64)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
    }
}
