using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.CrossCutting.Enums;

namespace SzkolenieTechniczne.Common.CrossCutting.Dtos
{

    
    public class CrudOperationResult<TDto>
    {
        public CrudOperationResultStatus Status { get; set; }
        public TDto? Result { get; set; }

    }
}
