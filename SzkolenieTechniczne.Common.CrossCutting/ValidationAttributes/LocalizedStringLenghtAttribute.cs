using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes
{
    public class LocalizedStringLenghtAttribute : StringLengthAttribute
    {
        public LocalizedStringLenghtAttribute(int maximumLenght): base (maximumLenght) { }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is LocalizedString localizedString)
            {
                return localizedString.Values.All(languageText => base.IsValid(languageText));
            }
            return false;
        }
    }
}
