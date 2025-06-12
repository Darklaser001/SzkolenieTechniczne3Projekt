using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Common.CrossCutting.Interface;
namespace SzkolenieTechniczne.Common.Storage.Entities
{
    [Index(nameof(LanguageCode), IsUnique = false)]
    public class BaseTranslation : BaseEntity, IEntityTranslation
    {

        [MaxLength(16)]
        [Required]  
        public string LanguageCode { get; set; } = null!;
    }
}
