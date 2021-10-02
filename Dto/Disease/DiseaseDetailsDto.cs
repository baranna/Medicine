using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Dto
{
    public class DiseaseDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SymptomDto> Symptoms { get; set; }

        public  string Description { get; set; }

        public List<string> Precautions { get; set; }
    }
}
