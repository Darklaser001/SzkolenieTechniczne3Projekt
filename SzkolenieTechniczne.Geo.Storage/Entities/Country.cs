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
    [Index(nameof(Alpha3Code),IsUnique =true)]
    [Table("Countries", Schema ="Geo")]
    public class Country : BaseEntity
    {
        [MaxLength(3)]
        [MinLength(2)]
        [Required]
        public string Alpha3Code { get; set; }
        public virtual ICollection<CountryTranslation> Translations { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
