using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Dto
{
    public class DiseaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SymptomDto> Symptoms { get; set; }
    }
}
