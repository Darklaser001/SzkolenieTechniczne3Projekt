using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Common.CrossCutting.Dtos
{
    public class LocalizedString : Dictionary<string, string>, IValidatableObject
    {
        public LocalizedString()
        {
        }

        public LocalizedString(IEnumerable<KeyValuePair<string, string>> items) : base(items)
        {
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Keys.Any(string.IsNullOrWhiteSpace))
            {
                yield return new ValidationResult("Language keys cannot be null nor white space");
            }
        }
    }
}
