﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Dto.Disease
{
    public class DiseaseSearchResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SyndromeCount { get; set; }

        public List<SyndromeDto> Syndromes { get; set; }
    }
}
