using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Dto.Disease
{
    public class SyndromeDto
    {
        public int Id { get; set; }

        public List<SymptomDto> Symptoms { get; set; }
    }
}
